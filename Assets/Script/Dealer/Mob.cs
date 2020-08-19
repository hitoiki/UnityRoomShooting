using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mob : MonoBehaviour
{
    // Flow + TekiGeneのFlyWeight + Itouchable

    //TekiGeneは多くのMobを持っていて、召喚する際にTekiGeneに要請する感じ
    //だから(できればStaticな)MobDealerも一緒に定義して差し上げる

    public string category;
    public Rigidbody2D rb;


}

public class MobDealer
{
    //一種類毎に扱う感じ
    public Mob DealMob;
    private List<Mob> MobList;


    Mob GetMob()
    {
        foreach (var obj in MobList)
        {
            Debug.Log(obj.name + ";" + obj.gameObject.activeSelf.ToString());
            if (obj.gameObject.activeSelf == false)
            {
                Debug.Log("aa");
                obj.gameObject.SetActive(true);
                return obj;
            }
        }


        var newMob = DealMob;
        MobList.Add(MonoBehaviour.Instantiate(newMob));
        return newMob;
    }
}

