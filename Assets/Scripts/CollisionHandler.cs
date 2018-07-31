using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

    [SerializeField] float levelLoadDelay = 1f;
    void Start () {
		
	}
	
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered!");
        StartDeathSequence();
        Invoke("ReloadScene", levelLoadDelay);
    }

    private void StartDeathSequence()
    {
        Debug.Log("Player Died");
        SendMessage("OnPlayerDeath");
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
