using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectFlyer<T> where T : MonoBehaviour
{
    //一種類毎に扱う感じ
    //コイツを介してObject生成をする事で、処理が軽くなる魔法のコード

    //飛ばし方にバリエーションが出せるようにして差し上げよう
    public T DealMob;
    private List<T> MobList;

    public ObjectFlyer(T mob)
    {
        DealMob = mob;
        MobList = new List<T>();
    }

    //Objectを渡す。
    public T GetMob(Vector3 pos)
    {
        foreach (var obj in MobList)
        {
            //Debug.Log(obj.name + ";" + obj.gameObject.activeSelf.ToString());
            if (obj.gameObject.activeSelf == false)
            {
                //Debug.Log("aa");
                obj.transform.position = pos;
                obj.gameObject.SetActive(true);
                return obj;
            }
        }


        var newMob = DealMob;
        MobList.Add(MonoBehaviour.Instantiate(newMob, pos, Quaternion.identity));
        return newMob;
    }
}

