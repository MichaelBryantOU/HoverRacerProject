using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartRace : MonoBehaviour
{
    public void Start()
    {
        StartCoroutine(loadAnotherScene());
    }

    // Update is called once per frame
    public IEnumerator loadAnotherScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
    }

}
