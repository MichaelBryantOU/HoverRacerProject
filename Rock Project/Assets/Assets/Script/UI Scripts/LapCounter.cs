using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapCounter : MonoBehaviour
{
    public float lapCount = 1;
    public float checkpointCount = 0;

    public Text lapNumber;

    public GameObject checkpointOne;
    public GameObject checkpointTwo;
    public GameObject checkpointThree;
    public GameObject checkpointFour;

    void Update()
    {
        lapNumber.text = lapCount.ToString();
    }

    private void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "checkpoint")
        {
            if (checkpointCount < 3)
            {
                checkpointCount++;
                hit.gameObject.SetActive(false);
                checkpointFour.gameObject.SetActive(true);
                Debug.Log("Checkpoint hit!");
            }
            else
            {
                checkpointCount = 0;
                checkpointOne.gameObject.SetActive(true);
                checkpointTwo.gameObject.SetActive(true);
                checkpointThree.gameObject.SetActive(true);
                checkpointFour.gameObject.SetActive(false);
                lapCount++;
            }

            if ((lapCount == 3) && (checkpointCount == 3))
            {
                
            }
        }
    }
}
