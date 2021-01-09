using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class HPbar : MonoBehaviour
{
    [SerializeField] TekiState state;
    [SerializeField] Slider bar;
    void Start()
    {
        if (state == null) state = GetComponent<TekiState>();
        if (state != null)
        {
            bar.maxValue = state.hp.Value;
            state.hp.Subscribe(n =>
            {
                bar.value = n;
            }
            );
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
