﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {
    [Header("General")]
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject[] guns;
    
    [Tooltip("Ship maneuvering speed")] [SerializeField] float moveSpeed = 10f;
    [Tooltip("Horizontal movement range")] [SerializeField] float xClampRange = 6f;
    [Tooltip("Vertical movement range")] [SerializeField] float yClampRange = 3f;  
    
    [Header("Screen Position Control")]
    [Tooltip("Degrres the ship pitches for every unit moved up/down")] [SerializeField] float positionPitchFactor = -5f;
    [Tooltip("Degrres the ship yaws for every unit moved left/right")] [SerializeField] float positionYawFactor = 5f;

    [Header("Controlthrow")]
    [Tooltip("Nose dipping uo/down while controls pressed")] [SerializeField] float pitchThrow = -25f;    
    [Tooltip("Banking while controls pressed")] [SerializeField] float bankThrow = -45f;

    
    float horizontal, vertical;
    float yOffset;

    bool inputEnabled = true;

    void Start () {
        yOffset = transform.localRotation.y;
	}
		
	void Update ()
    {
        if (inputEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
    }

    private void ProcessTranslation()
    {
        horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        vertical = CrossPlatformInputManager.GetAxis("Vertical");
        float xOffset = horizontal * Time.deltaTime * moveSpeed;
        float yOffset = vertical * Time.deltaTime * moveSpeed;
        Vector3 movement = new Vector3(Mathf.Clamp(transform.localPosition.x + xOffset, -xClampRange, xClampRange), Mathf.Clamp(transform.localPosition.y + yOffset, -yClampRange, yClampRange), transform.localPosition.z);
        transform.localPosition = movement;
    }

    void ProcessRotation()
    {
        float yaw = transform.localPosition.x * positionYawFactor;
        float pitch = (transform.localPosition.y - yOffset) * positionPitchFactor + vertical * pitchThrow ;
        float roll = horizontal * bankThrow;
        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }

    void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            SetGunsActive(true);
        }
        else
        {
            SetGunsActive(false);
        }
    }

    public void OnPlayerDeath()
    {
        inputEnabled = false;
        deathFX.SetActive(true);
    }

    void SetGunsActive(bool setActive)
    {
        foreach(GameObject gun in guns)
        { 
            var emissionModule = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = setActive;                 
        }
    }


}
