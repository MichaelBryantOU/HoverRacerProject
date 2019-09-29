using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public void Start()
    {
        SceneManager.LoadScene(2);
    }

    // Update is called once per frame
}
