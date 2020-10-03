using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PatrolMode { Idle, Attention, Battle }

public class Report
{
    public Vector2 reportPoint;
    public PatrolMode reportMode;
}
/*敵に情報を送るクラス
なんか似ているので、Enemyのこなすタスクと合わせたい
Enemyのこなすタスク
・ある点に向かうこと
・ある点の周りを探索する事


*/
interface IReportReceive
{
    void Reported(Report r);
}
