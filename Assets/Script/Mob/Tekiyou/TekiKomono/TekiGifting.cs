using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TekiGifting : MonoBehaviour, IPlayerTouchable
{
    // HPボックスや弾薬を渡す敵を作るためのクラス
    // TekiGeneratorがふがいないのでこういうクラスを作ることに
    // ドヤ顔で武器作ったけどいざシューティング作ると扱いづらいのなんの…
    // 結構作り直ししよう

    [SerializeField] int healing = 0;
    [SerializeField] int ammo = 0;

    [SerializeField] private TekiState state;
    [SerializeField] private Rigidbody2D rb;

    //値の取得はStart
    private void Start()
    {
        if (state == null) state = GetComponent<TekiState>();
        rb = state.rb;
    }

    public void touchPlayer(PlayerState p)
    {
        //Debug.Log("Moving");
        p.Damage(-healing);
        p.AddAmmo(ammo);
        this.gameObject.SetActive(false);
    }
}
