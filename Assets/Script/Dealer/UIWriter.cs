using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class UIWriter : MonoBehaviour
{
    public Text hpText;
    public Text scoreText;
    public GameObject gameoverScreen;

    public GameDataLog datalog;

    private void Start()
    {
        datalog.score.Subscribe(x => { scoreText.text = "Score " + x.ToString(); });
        datalog.state.hp.Subscribe(x => { hpText.text = "HP " + x.ToString(); });
        datalog.nowGameMode.Subscribe(x => { if (x == GameDataLog.GameMode.gameover) gameoverScreen.SetActive(true); });
    }
}
