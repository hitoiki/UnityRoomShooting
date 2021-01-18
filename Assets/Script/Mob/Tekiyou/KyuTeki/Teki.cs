﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teki : MonoBehaviour, IBulletTouchable, IPlayerTouchable
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
        //p.hp -= dealDamage;
    }
    public void touchBullet(Bullet b)
    {
        Debug.Log("bulletTouch");
    }
    public void subEffect()
    {
        Debug.Log("subed");
        Destroy(this.gameObject);
    }

}
