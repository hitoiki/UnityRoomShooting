using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GameModeDealer : MonoBehaviour
{

    public PlayerState state;
    public KeyPad keyPad;
    public GameState gameMode;
    public float scoreRate;
    private float timer;
    private modeEnum modeBeforePose;
    private void Start()
    {
        gameMode.score.Value = 0;
        gameMode.nowGameMode.Value = modeEnum.alive;

        keyPad.MenuKey.Where(x => { return x == true; }).Subscribe(_ =>
          {
              if (gameMode.nowGameMode.Value != modeEnum.menu)
              {
                  modeBeforePose = gameMode.nowGameMode.Value;
                  gameMode.nowGameMode.Value = modeEnum.menu;
              }
              else
              {
                  gameMode.nowGameMode.Value = modeBeforePose;
              }
          });

    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= scoreRate && scoreRate > 0)
        {
            gameMode.score.Value += 1;
            timer -= scoreRate;
        }

        if (state.playerMode == PlayerMode.dead && gameMode.nowGameMode.Value != modeEnum.gameover)
        {
            /*ゲームオーバー状態を示す*/
            gameMode.nowGameMode.Value = modeEnum.gameover;
        }

    }

}

