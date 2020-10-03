using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkEffecter : MonoBehaviour
{
    public Rigidbody2D Spark;
    public float power;

    public int maxAmount;
    public int minAmount;
    ObjectFlyer<Rigidbody2D> Scatter;

    private void Start()
    {
        Scatter = new ObjectFlyer<Rigidbody2D>(Spark);
    }

    // Update is called once per frame
    public void Scatt(Vector3 pos)
    {
        int amount_buf = Random.Range(minAmount, maxAmount);
        if (amount_buf < 0) amount_buf = 0;
        for (int i = 0; i <= amount_buf; i++)
        {
            Rigidbody2D debris = Scatter.GetMob(pos);
            debris.AddForce(Random.insideUnitCircle.normalized * power, ForceMode2D.Impulse);
        }
    }
}
