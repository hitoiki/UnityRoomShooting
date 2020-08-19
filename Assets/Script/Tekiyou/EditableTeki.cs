﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditableTeki : MonoBehaviour, ITouchable
{
    // 敵としてもつ基本的な性質を記述していく
    // インスペクタにアクセサリみたいな感じで振る舞いを追加していく感じにしたい
    // 旧式のTekiは置いてきた。はっきり言ってこの先のコーデイングには付いていけない

    /* FlyWeightに関して
        FlyWeightってのはクラスの共通部分は親クラスで括って、メモリを節約する設計
        子クラスにITouchableの処理を書くと、インスタンス毎にその処理が複製される
        子クラスに実装するのでなく、参照だけ持たせる事
    */
    Rigidbody2D rb;

    public int dealDamage = 0;
    public int dealBullet = 0;
    public bool shotDown;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame

    public void touchPlayer(Player p)
    {
        Debug.Log("PlayerTouch");
        //Destroy(this.gameObject);
        this.gameObject.SetActive(false);
        p.hp -= dealDamage;
        p.ammo += dealBullet;

    }
    public void touchBullet()
    {
        Debug.Log("bulletTouch");
        if (shotDown) this.gameObject.SetActive(false); //Destroy(this.gameObject);

    }
    public void subEffect()
    {
        Debug.Log("subed");
    }

}
