using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class TekiVanish : MonoBehaviour
{
    [SerializeField] TekiState state;
    [SerializeField] DropWeapon drop;
    void Start()
    {
        if (state == null) state = GetComponent<TekiState>();
        state.tekiMode.Subscribe(mode =>
        {
            if (mode == TekiMode.dead)
            {
                Instantiate(drop, this.transform.position, Quaternion.identity).ChangeWeapon(state.weapon.Value);
                this.gameObject.SetActive(false);
            }
        }
        );
    }
}
