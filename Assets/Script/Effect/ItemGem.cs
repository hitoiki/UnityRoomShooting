using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGem : MonoBehaviour
{
    //PLEffectorかなんかでレイを飛ばして、PLStateを受け取る
    //そのPLStateのposition目掛けて一定時間後に必ず当たるように飛び、一定時間後にPLに何かアクションする
    //弾薬、金などの受け渡しに用いる
    //現在は試作段階のためカスタム要素はまだ実装しない

    [SerializeField] Rigidbody2D rb = null;
    private bool aiming = false;
    [SerializeField] private float period = 0;
    [SerializeField] private int ammoAmount = 1;
    private PlayerState target = null;

    public void CallItemGem(PlayerState p)
    {
        target = p;
        aiming = true;
    }
    private void Update()
    {
        if (aiming)
        {
            //Vector3 acceleration = (target.transform.position - myPosition - velocity * period) * 2f / (period * period);
            rb.AddForce((target.rb.position - rb.position - rb.velocity * period) * 2f / (period * period));

            period -= Time.deltaTime;
            if (period <= 0)
            {
                target.AddAmmo(ammoAmount);
                aiming = false;
                this.gameObject.SetActive(false);
            }
        }
    }
}
