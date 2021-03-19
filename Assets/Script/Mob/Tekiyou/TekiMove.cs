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
    [SerializeField] private GameState DataLog;
    [SerializeField] private TekiState state;
    private Vector2 latestInput;

    private void Start()
    {
        Init();
        tekiRb = state.rb;
        //変化時の処理
        keyPad.InputVector.Subscribe(x =>
        {
            latestInput = x * state.speed.Value;
        });
        //方向転換
        keyPad.AimDirection.Subscribe(x =>
        {
            if (state.tekiMode.Value == TekiMode.alive) tekiRb.transform.rotation = Quaternion.FromToRotation(Vector3.up, keyPad.AimDirection.Value);
        }
        );
    }

    private void FixedUpdate()
    {
        if (state.tekiMode.Value == TekiMode.alive) tekiRb.velocity = latestInput;
    }

    void Init()
    {
        if (state == null) state = GetComponent<TekiState>();
        keyPad = GetComponent<KeyPad>();
    }


}
