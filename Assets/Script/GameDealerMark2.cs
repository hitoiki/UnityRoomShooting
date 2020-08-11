using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameDealerMark2 : MonoBehaviour
{

    //共有する変数
    public int test;

    //データの共有に使うインスタンス
    private static GameDealerMark2 instance;

    //インスタンスを取得できる唯一のプロパティ
    public static GameDealerMark2 Instance
    {
        get
        {
            //nullチェック
            if (null == instance)
            {
                instance = (GameDealerMark2)FindObjectOfType(typeof(GameDealerMark2));
                if (null == instance)
                {
                    Debug.Log(" DataManager Instance Error ");
                }
            }
            return instance;
        }
    }

    //シーン間でもインスタンスのオブジェクトが1つになるようにする
    void Awake()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("DataManager");
        if (1 < obj.Length)
        {
            // 既に存在しているなら削除
            Destroy(gameObject);
        }
        else
        {
            // シーン遷移では破棄させない
            DontDestroyOnLoad(gameObject);
        }
    }
}
