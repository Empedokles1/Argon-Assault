using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float xClampRange = 5f;
    [SerializeField] float yClampRange = 3f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float vertical = CrossPlatformInputManager.GetAxis("Vertical");       
        float xOffset = horizontal * Time.deltaTime * moveSpeed;
        float yOffset = vertical * Time.deltaTime * moveSpeed;
        
        Vector3 movement = new Vector3(Mathf.Clamp(transform.localPosition.x + xOffset,-xClampRange, xClampRange) , Mathf.Clamp(transform.localPosition.y + yOffset, -yClampRange, yClampRange), transform.localPosition.z);
        transform.localPosition = movement;
	}
}
