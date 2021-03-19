using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TekiPoison : MonoBehaviour
{
    // 継続的に自傷する用
    // こういうのを追加できるのがState型の強みなのだろう
    // ただ敵はマジで作り直すからな
    [SerializeField] private TekiState state;
    private float timer;
    private void Start()
    {
        if (state == null) state = GetComponent<TekiState>();
    }

    private void Update()
    {
        if (timer > 1)
        {
            state.Damage(1);
            timer -= 1;
        }
        timer += Time.deltaTime;

        if (state.tekiMode.Value == TekiMode.dead) this.gameObject.SetActive(false);

    }
}
