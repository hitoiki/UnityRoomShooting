using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, ITouchable
{
    // Start is called before the first frame update
    public void touchPlayer(Player p)
    {
    }
    public void touchBullet()
    {
        Debug.Log("bulletTouch");
    }
    public void subEffect()
    {
    }
}
