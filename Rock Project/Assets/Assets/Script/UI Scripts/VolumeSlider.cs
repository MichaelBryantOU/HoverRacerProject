using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSlider : MonoBehaviour
{

    private AudioSource Audio1;

    private float musicVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Audio1 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Audio1.volume = musicVolume;
    }

    public void setVolume(float vol)
    {
        musicVolume = vol;
    }
}
