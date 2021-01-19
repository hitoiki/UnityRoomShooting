using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TekiGene : MonoBehaviour
{
    // Start is called before the first frame update
    public List<EditableTeki> follower;
    public float spownTime;
    public float spownBure;
    private float timer;

    public EffectDealer effecter;

    public GameDataLog dataLog;

    public List<EditableTeki> objPool;
    EditableTeki GetObject()
    {

        foreach (var obj in objPool)
        {
            //Debug.Log(obj.name + ";" + obj.activeSelf.ToString());
            if (obj.gameObject.activeSelf == false)
            {
                //Debug.Log("aa");
                obj.gameObject.SetActive(true);
                return obj;
            }
        }

        EditableTeki newobj = follower[Random.Range(0, follower.Count)];
        newobj.DataLog = dataLog;
        newobj.sparker = effecter;
        objPool.Add(Instantiate(newobj));
        return newobj;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= spownTime)
        {
            //Instantiate(follower[Random.Range(0, follower.Count)], new Vector3(10f, Random.Range(-5f, 5f), 0f), Quaternion.identity);
            var newTeki = GetObject();

            newTeki.transform.position = new Vector3(10f, Random.Range(-5f, 5f), 0f);
            timer -= spownTime;
            timer -= Random.Range(-spownBure, spownBure);
        }
        timer += Time.deltaTime;
    }
}
