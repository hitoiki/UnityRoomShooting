using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TekiTouch : MonoBehaviour, IBulletTouchable, IPlayerTouchable
{
    [SerializeField] private TekiState state;
    [SerializeField] private Rigidbody2D rb;

    //値の取得はStart
    private void Start()
    {
        if (state == null) state = GetComponent<TekiState>();
        rb = state.rb;
    }
    public void touchPlayer(PlayerState p)
    {
        p.Damage(state.touchDamage.Value);
    }

    public void touchBullet(Bullet b)
    {
        //Debug.Log(b.weaponState.weaponName);
        state.Damage(b.weaponState.damage);
        b.gameObject.SetActive(false);
    }
}
