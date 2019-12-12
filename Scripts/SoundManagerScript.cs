using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip antSquishSound, buttonClickSound, antSpawnSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        antSquishSound = Resources.Load<AudioClip>("AntSquishify");
        buttonClickSound = Resources.Load<AudioClip>("ButtonClick");
        antSpawnSound = Resources.Load<AudioClip>("Energy");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "AntSquishify":
                audioSrc.PlayOneShot(antSquishSound);
                break;
            case "ButtonClick":
                audioSrc.PlayOneShot(buttonClickSound);
                break;
            case "Energy":
                audioSrc.PlayOneShot(antSpawnSound);
                break;
        }
    }
}

