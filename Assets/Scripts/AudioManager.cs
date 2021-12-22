using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Singleton
    protected static AudioManager instance;
    public static AudioManager Instance {
        get
        {
            if(instance == null)
            {
                var gO = new GameObject();
                instance = gO.AddComponent<AudioManager>();
            }
            return instance;
        }      
    }
    #endregion

    public AudioSource audioSource;
    public AudioClip audioClip;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }


    public void PlayAudio(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    private void OnDestroy()
    {
        instance = null;
    }
}
