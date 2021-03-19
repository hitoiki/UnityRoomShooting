using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class UIWriter : MonoBehaviour
{
    public Text hpText;
    public Text ammoText;
    public Text scoreText;
    public GameObject alertAmmo;
    public GameObject gameoverScreen;

    public GameObject menuScreen;

    public GameState datalog;
    public PlayerState state;

    private void Start()
    {
        datalog.score.Subscribe(x => { scoreText.text = "Score " + x.ToString(); });
        state.hp.Subscribe(x => { hpText.text = "HP " + x.ToString(); });
        state.ammo.Subscribe(x => { ammoText.text = "Ammo " + x.ToString(); alertAmmo.SetActive(x <= 0); });
        datalog.nowGameMode.Subscribe(x => { if (x == modeEnum.gameover) gameoverScreen.SetActive(true); });
        datalog.nowGameMode.Subscribe(x => { menuScreen.SetActive(x == modeEnum.menu); });
    }
}
