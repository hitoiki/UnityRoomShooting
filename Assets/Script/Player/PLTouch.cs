using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;

public class PLTouch : MonoBehaviour
{
    [SerializeField] private PlayerState state;
    [SerializeField] private Rigidbody2D rb;
    private void Awake()
    {
        if (state == null) state = GetComponent<PlayerState>();
        rb = state.rb;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        var touchable = col.gameObject.GetComponent<ITouchable>();
        if (touchable != null)
        {
            touchable.touchPlayer(state);
        }
    }
}
