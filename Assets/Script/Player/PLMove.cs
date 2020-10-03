using System.Collections;
using System.Collections.Generic;
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
        magazine = new ObjectFlyer<Bullet>(state.bullet);
        //変化時の処理
        keypad.InputVector.Subscribe(x =>
        {
            latestInput = x * state.speed.Value;
        });
        keypad.Shot.Subscribe(boo =>
        {
            if (boo && state.hp.Value > 0 && state.ammo.Value != 0)
            {
                /*ここにbulletの具現化処理*/
                state.ammo.Value -= 1;
                Bullet shootBullet = magazine.GetMob(playerRb.position);
                Debug.Log("instantiate");
                shootBullet.Init();
                shootBullet.rb.angularVelocity = -100f;
                Debug.Log("go shoot");
            }
        });
    }

    private void FixedUpdate()
    {
        if (state.hp.Value > 0) playerRb.velocity = latestInput;
    }
}
