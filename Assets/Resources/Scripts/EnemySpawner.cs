using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Enemigo a spawnear")] public GameObject enemy;
    private Vector3 whereToSpawn;
    private float spawnRate = 500f;
    private float nextSpawn = 0.0f;
    private float randX;
    private float randZ;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-270, -370);
            randZ = Random.Range(130, -40);
            whereToSpawn = new Vector3(randX, 5,randZ);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
        }
        
    }
}
