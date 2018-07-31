using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour {

    [SerializeField] GameObject explosion;
    [SerializeField] Transform parent;
    [SerializeField] int enemyScore;
    private ScoreBoard scoreBoard;
   

	void Start () {
        AddBoxCollider();
        scoreBoard = GameObject.FindObjectOfType<ScoreBoard>();
	}


    private void OnParticleCollision(GameObject other)
    {
        GameObject explosionInstance = Instantiate(explosion, transform.position, Quaternion.identity);
        explosionInstance.transform.parent = parent;
        scoreBoard.ScoreHit(enemyScore);
        Destroy(gameObject);
    }

    void AddBoxCollider()
    {
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();      
        boxCollider.isTrigger = false;
    }
}
