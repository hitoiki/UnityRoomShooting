using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PLShot : MonoBehaviour
{
    //大きくなったので分離
    [SerializeField] private KeyPad keyPad;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private PlayerState state;
    private bool shotable;
    private float cooltime;
    private ObjectFlyer<Bullet> magazine;
    //値の取得はStart
    private void Start()
    {
        keyPad = GetComponent<KeyPad>();
        if (state == null) state = GetComponent<PlayerState>();
        playerRb = state.rb;
        magazine = new ObjectFlyer<Bullet>(state.weapon.Value.GetPlayerBullet());
        //弾丸を撃つ処理…の許可を出す処理
        //今までの流れからだとこうなるやん？
        keyPad.Shot.Subscribe(boo =>
        {
            shotable = boo;
        });
        //武器が変わった時の処理
        state.weapon.Subscribe(weapon =>
        {
            magazine = new ObjectFlyer<Bullet>(state.weapon.Value.GetPlayerBullet());
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
            if (shotable && state.playerMode == PlayerMode.alive && state.ammo.Value != 0)
            {
                /*ここにbulletの具現化処理*/
                state.UseAmmo(1);
                Bullet shootBullet = magazine.GetMob(
                    playerRb.position,
                    x => { x.Init(state.weapon.Value.weaponState); x.shoot(keyPad.AimDirection.Value); },
                    x => { x.shoot(keyPad.AimDirection.Value); });
                //Debug.Log("go shoot");
                cooltime = state.weapon.Value.weaponState.shotInterval;
            }
        }
    }


}
