using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class TekiVanish : MonoBehaviour
{
    [SerializeField] TekiState state = null;
    [SerializeField] DropWeapon drop = null;
    [SerializeField] EffectDealer effector = null;
    void Start()
    {
        if (state == null) state = GetComponent<TekiState>();

        state.tekiMode.Subscribe(mode =>
        {
            if (mode == TekiMode.dead)
            {
                if (drop != null)
                {
                    DropWeapon d = Instantiate(drop, state.rb.position, Quaternion.identity);
                    d.ChangeWeapon(state.weapon.Value);
                    d.ChangeEffector(effector);
                }
                if (state != null) effector.SparkScatt(state.rb.position);
                this.gameObject.SetActive(false);
            }
        }
        );
    }
}
