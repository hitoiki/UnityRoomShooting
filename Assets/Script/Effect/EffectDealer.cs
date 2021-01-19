using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDealer : MonoBehaviour
{
    public Rigidbody2D Spark;
    public Rigidbody2D itemGem;
    public float power;

    public int maxAmount;
    public int minAmount;
    ObjectFlyer<Rigidbody2D> sparkFlyer;
    ObjectFlyer<Rigidbody2D> itemGemsFlyer;

    private void Start()
    {
        sparkFlyer = new ObjectFlyer<Rigidbody2D>(Spark);
        itemGemsFlyer = new ObjectFlyer<Rigidbody2D>(itemGem);
    }

    // Update is called once per frame
    public void SparkScatt(Vector3 pos)
    {
        int amount_buf = Random.Range(minAmount, maxAmount);
        if (amount_buf < 0) amount_buf = 0;
        for (int i = 0; i <= amount_buf; i++)
        {
            Rigidbody2D debris = sparkFlyer.GetMob(pos,
            x => { x.AddForce(Random.insideUnitCircle.normalized * power, ForceMode2D.Impulse); },
            x => { x.AddForce(Random.insideUnitCircle.normalized * power, ForceMode2D.Impulse); });

        }
    }

    public void GemScatt(Vector3 pos, int amount)
    {
        if (amount < 0) amount = 0;
        for (int i = 0; i <= amount; i++)
        {
            Rigidbody2D item = itemGemsFlyer.GetMob(pos,
            x => { x.AddForce(Random.insideUnitCircle.normalized * power, ForceMode2D.Impulse); },
            x => { x.AddForce(Random.insideUnitCircle.normalized * power, ForceMode2D.Impulse); });

        }
    }
}
