using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Dealable : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameDealerMark2.Instance.test = 2;
    }
}
