using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
     Rigidbody targetRb;
     private float minSpeed = 12; 
     private float maxSpeed = 16;
     private float maxTorque = 10;
     private float xRange = 4;
     private float ySpawnPos = -6; 
     private GameManager gameManager;
     public int pointValue;
     public ParticleSystem explosionParticle;
     private float spawnRate = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
       
        targetRb=GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(Randomtorque(), Randomtorque(), Randomtorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float Randomtorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }    
   
    private void OnMouseDown()
     {
        if (gameManager.isGameActive)
        {
             Destroy(gameObject);
             Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
             gameManager.UpdateScore(pointValue);
        }
      

    }
   private void OnTriggerEnter(Collider other)
   {
     Destroy(gameObject);
     if (!gameObject.CompareTag("Bad"))
     {
        gameManager.UpdateLives(1);
     }
   }

   public void DestroyTarget()
  {
    if (gameManager.isGameActive)
    {
        Destroy(gameObject);
        Instantiate(explosionParticle, transform.position,
        explosionParticle.transform.rotation);
        gameManager.UpdateScore(pointValue);
    }
  }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
