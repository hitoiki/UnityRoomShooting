using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GameDataLog : MonoBehaviour
{
    public PlayerState state;

    public ReactiveProperty<int> score = new ReactiveProperty<int>();

    public float scoreRate;
    private float timer;


    public enum GameMode { play, gameover, menu };
    public ReactiveProperty<GameMode> nowGameMode = new ReactiveProperty<GameMode>();


    private void Start()
    {
        //state.hp.Subscribe(x => {})
        score.Value = 0;
        nowGameMode.Value = GameMode.play;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= scoreRate)
        {
            score.Value += 1;
            timer -= scoreRate;
        }

        if (state.hp.Value <= 0 && nowGameMode.Value != GameMode.gameover)
        {
            /*ゲームオーバー状態を示す*/
            nowGameMode.Value = GameMode.gameover;


        }

    }
}
