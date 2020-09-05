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
            if (boo)
            {
                /*ここにbulletの具現化処理*/
                Bullet shootBullet = magazine.GetMob(playerRb.position);
            }
        });
    }

    private void FixedUpdate()
    {
        playerRb.velocity = latestInput;
    }
}
