using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teki : MonoBehaviour, ITouchable
{
    // 敵としてもつ基本的な性質を記述していく
    // インスペクタにアクセサリみたいな感じで振る舞いを追加していく感じにしたい
    Rigidbody2D rb;

    public int dealDamage;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }


    public void touchPlayer(PlayerState p)
    {
        Debug.Log("PlayerTouch");
        p.hp.Value -= dealDamage;
    }
    public void touchBullet()
    {
        Debug.Log("bulletTouch");
    }
    public void subEffect()
    {
        Debug.Log("subed");
        Destroy(this.gameObject);
    }

}
