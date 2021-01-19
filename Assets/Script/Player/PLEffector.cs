using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PLEffector : MonoBehaviour
{
    PlayerState state = null;
    [SerializeField] float area = 0;

    private void Start()
    {
        state = GetComponent<PlayerState>();
    }
    void Update()
    {
        IEnumerable<ItemGem> gems = Physics2D.CircleCastAll(state.rb.position, area, Vector2.zero).Select(x => x.collider.GetComponent<ItemGem>()).Where(x => x != null);
        if (gems.Any(x => x != null))
        {
            foreach (ItemGem x in gems)
            {
                x.CallItemGem(state);
            }
        }
    }
}
