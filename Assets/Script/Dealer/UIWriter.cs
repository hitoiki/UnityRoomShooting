using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWriter : MonoBehaviour
{
    public Text hpText;
    public Text scoreText;
    public GameObject gameoverScreen;


    public void Write(int s, string x)
    {
        switch (x)
        {
            case "Hp":
                hpText.text = "HP" + s.ToString();
                break;
            case "Score":
                scoreText.text = "Score " + s.ToString();
                break;
            default: break;
        }
    }
    public void gameover()
    {
        gameoverScreen.SetActive(true);
    }
}
