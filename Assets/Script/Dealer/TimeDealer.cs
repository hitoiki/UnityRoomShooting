using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class TimeDealer : MonoBehaviour
{
    public GameState datalog;

    private void Start()
    {
        datalog.nowGameMode.Subscribe(x =>
        {
            if (x != modeEnum.alive)
            {
                Time.timeScale = 0;
            }
            else Time.timeScale = 1;
        });
    }
}
