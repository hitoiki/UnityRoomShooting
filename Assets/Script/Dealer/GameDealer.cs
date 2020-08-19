using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Gamemode { title, play, gameover };
public class GameDealer : MonoBehaviour
{

    //共有する変数
    private Gamemode mode;
    public Gamemode Mode { get { return mode; } }
    //public UIWriter uiWriter;

    private float time;
    public int score;
    public int scoreRate;

    public UIWriter uiWriter;


    //データの共有に使うインスタンス
    private static GameDealer instance;

    //インスタンスを取得できる唯一のプロパティ
    public static GameDealer Instance
    {
        get
        {
            //nullチェック
            if (null == instance)
            {
                instance = (GameDealer)FindObjectOfType(typeof(GameDealer));
                if (null == instance)
                {
                    Debug.Log(" DataManager Instance Error ");
                }
            }
            return instance;
        }
    }

    private void Update()
    {
        if (Mode != Gamemode.gameover)
        {
            time += Time.deltaTime;
            if (time >= scoreRate)
            {
                score += 1;
                time -= scoreRate;
                uiWriter.Write(score, "Score");
            }
        }
    }

    public void PlayerLoad(Player s)
    {
        if (s.hp <= 0)
        {
            GameOver();
        }
        uiWriter.Write(s.hp, "Hp");
    }

    public void ScoreAdd(int n)
    {
        score += n;
        uiWriter.Write(score, "Score");
    }

    public void GameOver()
    {
        if (Mode != Gamemode.gameover)
        {
            uiWriter.gameover();
            Debug.Log("gameover");
            mode = Gamemode.gameover;
        }
    }

    public void GameStart()
    {
        if (Mode != Gamemode.play)
        {
            mode = Gamemode.play;
        }
    }
    //シーン間でもインスタンスのオブジェクトが1つになるようにする
    void Awake()
    {
        mode = Gamemode.play;
        GameObject[] obj = GameObject.FindGameObjectsWithTag("GameController");
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
