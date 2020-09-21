using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class TimeDealer : MonoBehaviour
{
    public GameDataLog datalog;

    private void Start()
    {
        datalog.nowGameMode.Subscribe(x =>
        {
            if (x == GameDataLog.GameMode.gameover)
            {
                Time.timeScale = 0;
            }
            else Time.timeScale = 1;
        });
    }
}
