using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

    [SerializeField] private AudioClip splashMusic;
    private AudioSource audioSource;

    private void Awake()
    {    
        if(FindObjectsOfType<MusicPlayer>().Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }             
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = splashMusic;
        audioSource.Play();       
    }

   

    
}
