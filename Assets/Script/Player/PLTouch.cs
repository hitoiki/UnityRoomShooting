using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;

public class PLTouch : MonoBehaviour
{
    [SerializeField] private PlayerState state;
    [SerializeField] private Rigidbody2D rb;
    //値の取得はStart
    private void Start()
    {
        if (state == null) state = GetComponent<PlayerState>();
        rb = state.rb;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        var touchable = col.gameObject.GetComponent<IPlayerTouchable>();
        if (touchable != null)
        {
            touchable.touchPlayer(state);
        }
    }
}
