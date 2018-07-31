
using UnityEngine;

public class SelfDestruct : MonoBehaviour {
	
	void Start () {
        Destroy(this.gameObject, 2f);
	}	
}
