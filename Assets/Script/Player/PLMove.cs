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
    //値の取得はStart
    private void Start()
    {
        keyPad = GetComponent<KeyPad>();
        if (state == null) state = GetComponent<PlayerState>();
        playerRb = state.rb;
        //変化時の処理
        keyPad.InputVector.Subscribe(x =>
        {
            latestInput = x * state.speed.Value;
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
