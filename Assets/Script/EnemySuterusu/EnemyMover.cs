using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour, IReportReceive
{

    [SerializeField] private Rigidbody2D rb;


    public List<Report> patrolPoint;
    //Vectorより"する事クラス"の方がいいかも
    //ていうかReportクラスのリストでは？
    public PatrolMode mode { get; set; }
    private ObjectFlyer<Bullet> magazine;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        rb.velocity = Moving(patrolPoint[0]).normalized;
    }

    public void Reported(Report r)
    {
        mode = r.reportMode;

    }

    Vector2 Moving(Report r)
    {
        return rb.position - r.reportPoint;
    }

}
/*Enemyは状態と知覚を持つ
知覚はコード短いけどReportクラスとIReportableのセットで取り扱う
状態に応じて、向かうべき位置を決定し、そこに向かって移動する
状態は主に三つ。
決められた位置を徘徊する待機状態。
聴覚で捉えた物に近寄り、そこを探す警戒状態。
敵を発見し、そこに向かって撃ちまくる戦闘状態。
待機状態なら、Listで向かうべき場所へ移動するのを繰り返す。
（最短距離とかAIを後でやる）
警戒は、reportが距離を伝えるので、そこへ向かう
戦闘はリアルタイムでPLを追い続ける

この時shotもオートで行う
移動はAIが絡むので関数を分けておく

Reportを受け取って、Listに保存
それを適宜適宜する
*/