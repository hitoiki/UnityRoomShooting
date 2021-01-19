using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class TekiShot : MonoBehaviour
{
    [SerializeField] private KeyPad keyPad;
    [SerializeField] private Rigidbody2D tekiRb;
    [SerializeField] private EffectDealer sparker;
    [SerializeField] private GameDataLog DataLog;
    [SerializeField] private TekiState state;
    private ObjectFlyer<Bullet> magazine;
    private Vector2 latestInput;
    private bool shotable;
    private float cooltime;
    //値の取得はStart
    private void Start()
    {
        Init();
        tekiRb = state.rb;
        magazine = new ObjectFlyer<Bullet>(state.weapon.Value.GetEnemyBullet());
        //弾丸を撃つ処理…の許可を出す処理
        keyPad.Shot.Subscribe(boo =>
        {
            shotable = boo;
        });
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
    void Init()
    {
        if (state == null) state = GetComponent<TekiState>();
        keyPad = GetComponent<KeyPad>();
    }

}
