using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour {

    [SerializeField] GameObject explosion;
    [SerializeField] Transform parent;
    [SerializeField] int enemyScore;
    [SerializeField] int maxHits = 1;
    private ScoreBoard scoreBoard;
   

	void Start () {
        AddBoxCollider();
        scoreBoard = GameObject.FindObjectOfType<ScoreBoard>();
	}


    private void OnParticleCollision(GameObject other)
    {
        maxHits--;
        if(maxHits <= 0)
        {
            scoreBoard.ScoreHit(enemyScore);
            KillEnemy();
        }       
    }

    private void KillEnemy()
    {
        GameObject explosionInstance = Instantiate(explosion, transform.position, Quaternion.identity);
        explosionInstance.transform.parent = parent;
        Destroy(gameObject);
    }

    void AddBoxCollider()
    {
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();      
        boxCollider.isTrigger = false;
    }
}
