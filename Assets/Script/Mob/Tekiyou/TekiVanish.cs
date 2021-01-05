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
                //なんか知らんけど参照渡しのあれで変数置かんといけない
                var x = state.weapon.Value;
                Instantiate(drop, this.transform.position, Quaternion.identity).ChangeWeapon(ref x);
                this.gameObject.SetActive(false);
            }
        }
        );
    }
}
