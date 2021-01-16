using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敵のPlayerStateに対する操作をinterfaceで定義
//したかったが、インスペクタで扱う為にabstractでクラスを定義
//Scriptableで個々にインスタンスを生成する、という若干面倒な手続きに
//まじでOdin導入すべきかもしんない

/*
public interface ITactics
{
    void tactics(Vector3 playerPositipn, Vector3 MyPosition, KeyPad keyPad);
}*/
public abstract class Tactics : ScriptableObject
{
    public abstract void tactics(Vector3 playerPositipn, Vector3 MyPosition, KeyPad keyPad);
}





