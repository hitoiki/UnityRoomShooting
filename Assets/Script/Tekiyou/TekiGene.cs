using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TekiGene : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> follower;
    public float spownTime;
    public float spownBure;
    private float timer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= spownTime)
        {
            Instantiate(follower[Random.Range(0, follower.Count)], new Vector3(10f, Random.Range(-5f, 5f), 0f), Quaternion.identity);
            timer -= spownTime;
            timer -= Random.Range(-spownBure, spownBure);
        }
        timer += Time.deltaTime;
    }
}
