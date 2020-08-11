using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jiki : MonoBehaviour
{
    public GameDealer dealer;
    public Bullet bullet;
    public Player state;
    private Rigidbody2D rb;
    public IKeyPad Key;
    public float speed;
    public int firsthp;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        state = new Player(firsthp, 0);
        state.bullet = bullet;
        dealer.PlayerLoad(state);
    }


    // Update is called once per frame
    private void Update()
    {
        Key.KeyPadUpdate();
        if (Key.Shot)
        {
            if (state.ammo > 0) Instantiate(bullet, rb.transform.position, Quaternion.identity);
        };
        dealer.PlayerLoad(state);
    }
    void FixedUpdate()
    {
        //操作の反映と、移動処理
        Key.KeyPadUpdate();
        if (state.hp > 0) rb.velocity = Key.KeyVector * speed;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        var touchable = col.gameObject.GetComponent<ITouchable>();
        if (touchable != null)
        {
            touchable.touchPlayer(state);
            touchable.subEffect();
        }
        dealer.PlayerLoad(state);
    }
}
