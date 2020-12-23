using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLMenu : MonoBehaviour
{
    bool isPose = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPose)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
            Debug.Log("Called");
            isPose = !isPose;
        }

    }
}
