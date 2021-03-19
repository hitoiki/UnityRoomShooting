using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class TekiVanish : MonoBehaviour
{

    //汎用性が無さすぎるので改造しなおしたい
    [SerializeField] TekiState state = null;
    [SerializeField] DropWeapon drop = null;
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
                }
                this.gameObject.SetActive(false);
            }
        }
        );
    }
}
