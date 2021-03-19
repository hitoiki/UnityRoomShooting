using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherDealer : MonoBehaviour
{
    // 天気を気分で切り替える

    private float timer;
    [SerializeField] private float changeTime = 10;
    [SerializeField] private float changeTimeBure = 5;
    [SerializeField] GameState state = null;
    void Update()
    {
        if (timer >= changeTime)
        {
            int w = Random.Range(0, 3);
            if (w == 0) state.nowWeather.Value = weather.carm;
            if (w == 1) state.nowWeather.Value = weather.rain;
            if (w == 2) state.nowWeather.Value = weather.storm;

            timer -= changeTime;
            timer -= Random.Range(-changeTimeBure, changeTimeBure);
        }
        timer += Time.deltaTime;

    }
}
