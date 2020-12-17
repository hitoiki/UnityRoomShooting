using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    /*
    Weaponは武器のステータスと、発射する二種の弾丸からなる
    基本的に処理せず、inspector,コードで扱うためのデータとしての役割
    Bulletは発射される弾丸のGameObjectであり、
    弾丸の情報はweaponStateから受け取る。 

    Bulletは混同を防ぐ為に派生クラスを持つようにした
    それぞれのBulletで属するクラスの感じがだいぶ違うけど、まあいい感じになったと思う
    
    若干面倒だが、これもPlayerStateみたいに上手いこと読み取り専用にしたほうが良いかも

    課題:
    いつplayerBulletにweaponStateを入れるんや
    ここで扱ってるBulletはPrefabの状態なので、
    Weaponをインスタンス化しないとBulletの変更は上手くいかなそう
    →Objectflyerの初期化処理で、Initの他にCastStateを渡す
    最初はWeaponの仕事をPLMoveが担うのはどうかと感じたが、
    PLMoveがWeaponを読みまくって仕事をするので、これもまあOKってことにする
    敵の弾丸と自身の弾丸がぶつかるのはどうなのか
    →Layer分けて接触しないように
    弾道変えるのにわざわざ派生クラス作るのは面倒そう
    着弾時も色々変えたいし…
    */
    [SerializeField] public WeaponState weaponState;
    [SerializeField] private PlayerBullet playerBullet;
    [SerializeField] private EnemyBullet enemyBullet;

    public PlayerBullet GetPlayerBullet()
    {
        return playerBullet;
    }

    public EnemyBullet GetEnemyBullet()
    {
        return enemyBullet;
    }
}