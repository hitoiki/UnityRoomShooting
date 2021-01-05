using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;
public class TekiMove : MonoBehaviour
{
    //PLMoveを流用する感じ
    //仮想のIKeyPadを弄るプログラムをおいて、それを弄る感じか？
    //せっかく作り直すのだから、知覚できる情報を渡して、keypadを返す関数が良いか?
    //Observerを活かせ…
    /*
    知覚するクラス
    判断するクラス
    実行するクラス
    の三つにする
    知覚情報を渡して、行動情報を渡すAI
    関数を考えているけどObserverで勝手に監視し合うのがいいのか？
    そんな気がしてきた
    */
    [SerializeField] private KeyPad keyPad;
    [SerializeField] private Rigidbody2D tekiRb;
    [SerializeField] private Effecter sparker;
    [SerializeField] private GameDataLog DataLog;
    [SerializeField] private TekiState state;
    private ObjectFlyer<Bullet> magazine;
    private Vector2 latestInput;
    private bool shotable;
    private float cooltime;
    private void Awake()
    {
        Init();
        keyPad = GetComponent<KeyPad>();
        if (state == null) state = GetComponent<TekiState>();
        tekiRb = state.rb;
        magazine = new ObjectFlyer<Bullet>(state.weapon.Value.GetEnemyBullet());
        //変化時の処理
        keyPad.InputVector.Subscribe(x =>
        {
            latestInput = x * state.speed.Value;
        });
        //弾丸を撃つ処理…の許可を出す処理
        //今までの流れからだとこうなるやん？
        keyPad.Shot.Subscribe(boo =>
        {
            shotable = boo;
        });

        //方向転換
        keyPad.AimDirection.Subscribe(x =>
        {
            if (state.tekiMode.Value == TekiMode.alive) tekiRb.transform.rotation = Quaternion.FromToRotation(Vector3.up, keyPad.AimDirection.Value);
        }
        );
        //武器が変わった時の処理
        state.weapon.Subscribe(weapon =>
        {
            magazine = new ObjectFlyer<Bullet>(state.weapon.Value.GetEnemyBullet());
            cooltime = state.weapon.Value.weaponState.shotInterval;
        }
        );
    }

    private void Update()
    {
        //ボタンを押している間は撃つ、なのでこのような処理に
        //一応外のブールを介してkeypadへのアクセス回数を減らしてはいる 
        //…冗長になってきたなぁ
        if (cooltime > 0) cooltime -= Time.deltaTime;
        else
        {
            if (shotable)
            {
                /*ここにbulletの具現化処理*/
                Bullet shootBullet = magazine.GetMob(
                    tekiRb.position,
                    x => { x.Init(state.weapon.Value.weaponState); x.shoot(keyPad.AimDirection.Value); },
                    x => { x.shoot(keyPad.AimDirection.Value); });
                cooltime = state.weapon.Value.weaponState.shotInterval;
            }
        }
    }

    private void FixedUpdate()
    {
        if (state.tekiMode.Value == TekiMode.alive) tekiRb.velocity = latestInput;
    }

    void Init()
    {
        tekiRb = this.GetComponent<Rigidbody2D>();
    }


}
