using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzikKontrol : MonoBehaviour
{
    public static MuzikKontrol instance;

    AudioSource audio;

    // Start is called before the first frame update
    void Awake()
    {
        SingleTon();
        audio = GetComponent<AudioSource>();
    }

    void SingleTon()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }

    public void MüzikCal(bool play)
    {
        if (play)
        {
            if (!audio.isPlaying)
            {
                audio.Play();
            }
        } else
        {
            if (audio.isPlaying)
            {
                audio.Stop();
            }
        }
    }
  
}
