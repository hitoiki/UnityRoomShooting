using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;

public class PLMove : MonoBehaviour
{
    [SerializeField] private KeyPad keyPad;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private PlayerState state;

    private Vector2 latestInput;
    private bool shotable;
    private float cooltime;
    private ObjectFlyer<Bullet> magazine;
    private void Start()
    {
        keyPad = GetComponent<KeyPad>();
        if (state == null) state = GetComponent<PlayerState>();
        playerRb = state.rb;
        magazine = new ObjectFlyer<Bullet>(state.weapon.Value.GetPlayerBullet());
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
            if (state.playerMode == PlayerMode.alive) playerRb.transform.rotation = Quaternion.FromToRotation(Vector3.up, keyPad.AimDirection.Value);
        }
        );
        //物にアクションする処理
        keyPad.Action.Subscribe(boo =>
        {
            if (boo && state.playerMode == PlayerMode.alive)
            {
                var inTheHands = Physics2D.CircleCastAll(playerRb.position, state.hands.Value, Vector2.zero).Select(x => x.collider.GetComponent<IActionable>());
                if (inTheHands.Any(x => x != null)) inTheHands.Where(x => x != null).First().actionPlayer(state);
            }
        }
        );
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
                cooltime = cooltime = state.weapon.Value.weaponState.shotInterval;
                Bullet shootBullet = magazine.GetMob(
                    playerRb.position,
                    x => { x.Init(state.weapon.Value.weaponState); x.shoot(keyPad.AimDirection.Value); },
                    x => { x.shoot(keyPad.AimDirection.Value); });
                Debug.Log("go shoot");
                cooltime = state.weapon.Value.weaponState.shotInterval;
            }
        }
    }

    private void FixedUpdate()
    {
        if (state.playerMode == PlayerMode.alive) playerRb.velocity = latestInput;
    }

    private void OnDrawGizmos()
    {
        if (playerRb != null) Gizmos.DrawWireSphere(playerRb.position, state.hands.Value);
    }
}
