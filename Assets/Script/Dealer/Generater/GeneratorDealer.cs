using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GeneratorDealer : MonoBehaviour
{
    //DataLogを読んで、TekiGeneratorを交換する
    //本当はEnumでは無くそういったクラスを作るべき
    [SerializeField] private GameState state = null;
    [SerializeField] private TekiGenerator calmGene = null;
    [SerializeField] private TekiGenerator rainGene = null;
    [SerializeField] private TekiGenerator stormGene = null;

    private void Start()
    {
        state.nowWeather.Subscribe(x =>
        {
            switch (x)
            {
                case weather.carm:
                    calmGene.gameObject.SetActive(true);
                    rainGene.gameObject.SetActive(false);
                    stormGene.gameObject.SetActive(false);
                    break;
                case weather.rain:
                    calmGene.gameObject.SetActive(false);
                    rainGene.gameObject.SetActive(true);
                    stormGene.gameObject.SetActive(false);
                    break;
                case weather.storm:
                    calmGene.gameObject.SetActive(false);
                    rainGene.gameObject.SetActive(false);
                    stormGene.gameObject.SetActive(true);
                    break;
                default: break;

            }

        });
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q)) Debug.Log(state.nowWeather);
    }

}
