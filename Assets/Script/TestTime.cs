using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTime : MonoBehaviour
{
    // Start is called before the first frame update
    public float time;
    public void OnClick()
    {
        Time.timeScale = time;
        Debug.Log("pushed");
    }
}
