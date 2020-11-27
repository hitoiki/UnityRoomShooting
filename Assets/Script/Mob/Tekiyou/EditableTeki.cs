using System.Collections;
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
    public SparkEffecter sparker;
    public GameDataLog DataLog;
    public int id;

    public int dealDamage = 0;
    public int dealBullet = 0;
    public int dealScore = 0;
    public bool shotDown;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame

    public void touchPlayer(PlayerState p)
    {
        //Debug.Log("PlayerTouch");
        //Destroy(this.gameObject);
        this.gameObject.SetActive(false);
        p.Damage(dealDamage);
        p.UseAmmo(-dealBullet);

    }
    public void touchBullet(Bullet b)
    {
        //Debug.Log("bulletTouch");
        if (DataLog != null) DataLog.score.Value += dealScore;
        if (sparker != null) sparker.Scatt(rb.position);
        if (shotDown) this.gameObject.SetActive(false); //Destroy(this.gameObject);

    }

}
