using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;

public class PLMove : MonoBehaviour
{


    [SerializeField] private IKeyPad keypad;
    [SerializeField] private Rigidbody2D playerRb;

    [SerializeField] private PlayerState state;

    private Vector2 latestInput;
    private ObjectFlyer<Bullet> magazine;
    private void Awake()
    {
        keypad = GetComponent<IKeyPad>();
        if (state == null) state = GetComponent<PlayerState>();
        playerRb = state.rb;
        magazine = new ObjectFlyer<Bullet>(state.weapon.Value.bullet);
        //変化時の処理
        keypad.InputVector.Subscribe(x =>
        {
            latestInput = x * state.speed.Value;
        });
        keypad.Shot.Subscribe(boo =>
        {
            if (boo && !state.IsDead && state.ammo.Value != 0)
            {
                /*ここにbulletの具現化処理*/
                state.UseAmmo(1);
                Bullet shootBullet = magazine.GetMob(
                    playerRb.position,
                    x => { x.Init(); x.shoot(keypad.AimDirection.Value); x.rb.angularVelocity = -100f; },
                    x => { x.shoot(keypad.AimDirection.Value); x.rb.angularVelocity = -100f; });
                Debug.Log("go shoot");
            }
        });
        //方向転換
        keypad.AimDirection.Subscribe(x =>
        {
            playerRb.transform.rotation = Quaternion.FromToRotation(Vector3.up, keypad.AimDirection.Value);
        }
        );
        //物にアクションする処理
        keypad.Action.Subscribe(boo =>
        {
            if (boo)
            {
                var inTheHands = Physics2D.CircleCastAll(playerRb.position, state.hands.Value, Vector2.zero).Select(x => x.collider.GetComponent<IActionable>());
                if (inTheHands.Any(x => x != null)) inTheHands.Where(x => x != null).First().actionPlayer(state);
            }
        }
        );
        state.weapon.Subscribe(weapon =>
        {
            magazine = new ObjectFlyer<Bullet>(state.weapon.Value.bullet);
        }
        );
    }

    private void FixedUpdate()
    {
        if (!state.IsDead) playerRb.velocity = latestInput;
    }

    private void OnDrawGizmos()
    {
        if (playerRb != null) Gizmos.DrawWireSphere(playerRb.position, state.hands.Value);
    }
}
