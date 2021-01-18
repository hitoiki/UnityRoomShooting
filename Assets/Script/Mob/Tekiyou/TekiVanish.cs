using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class TekiVanish : MonoBehaviour
{
    [SerializeField] TekiState state = null;
    [SerializeField] DropWeapon drop = null;
    [SerializeField] Effecter effecter = null;
    void Start()
    {
        if (state == null) state = GetComponent<TekiState>();

        state.tekiMode.Subscribe(mode =>
        {
            if (mode == TekiMode.dead)
            {
                if (drop != null) Instantiate(drop, state.rb.position, Quaternion.identity).ChangeWeapon(state.weapon.Value);
                if (state != null) effecter.SparkScatt(state.rb.position);
                this.gameObject.SetActive(false);
            }
        }
        );
    }
}
