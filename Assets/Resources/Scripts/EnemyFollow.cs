using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    
    public GameObject player;
    NavMeshAgent enemy;
    Animator enemy2;
    // Start is called before the first frame update
    void Start()
    {
        enemy=GetComponent<NavMeshAgent>();
        enemy2 = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy.destination = player.transform.position;
        enemy2.SetFloat("Speed", Mathf.Abs(player.transform.position.x));
    }
}
