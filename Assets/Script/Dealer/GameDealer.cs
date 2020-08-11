using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDealer : MonoBehaviour
{

    public UIWriter uiWriter;

    private float time;
    public int score;
    public int scoreRate;

    public bool gameover = false;

    private void Update()
    {
        if (!gameover)
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
        if (!gameover)
        {
            uiWriter.gameover();
            Debug.Log("gameover");
            gameover = true;
        }
    }
}