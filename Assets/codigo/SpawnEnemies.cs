using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    
    public GameObject enemy;
    private Vector3 coordinates = new Vector3(0f,0.1f,10f);
    public int limites = 50;
    public int enemycaunt;
    public int ActualEnemys;
    void Start()
    {
       spawnEnemies ()  ;     
    }
    void spawnEnemies ()
    {
        for (int i = 0; i < enemycaunt; i++ )
        {
           float xzRPosition = Random.Range(-limites, limites);

        Vector3 randomSpawn = new Vector3(xzRPosition, 0.1f, xzRPosition);
            
        Instantiate(enemy, randomSpawn, enemy.transform.rotation);
        ActualEnemys ++;
        }    
    }
    public void Enemy_dead ()
    {
        ActualEnemys --;
        if (ActualEnemys <= 0)
        spawnEnemies ();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
