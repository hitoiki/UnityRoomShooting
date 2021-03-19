using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GameState : MonoBehaviour
{
    public ReactiveProperty<int> score = new ReactiveProperty<int>();
    public ReactiveProperty<modeEnum> nowGameMode = new ReactiveProperty<modeEnum>();
    public ReactiveProperty<weather> nowWeather = new ReactiveProperty<weather>();
}

public enum modeEnum { alive, gameover, menu };
public enum weather { carm, rain, storm };