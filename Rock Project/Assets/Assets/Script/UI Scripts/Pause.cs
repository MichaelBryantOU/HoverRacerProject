using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pause : MonoBehaviour
{
    public GameObject PauseScreen;
    public GameObject DrivingUI;

    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (PauseScreen.activeInHierarchy)
                   {
                PauseScreen.SetActive(false);
                Time.timeScale = 1;
                }
            else
            {
                PauseScreen.SetActive(true);
                Time.timeScale = 0;
            }
        }

        if (PauseScreen.activeInHierarchy)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

}