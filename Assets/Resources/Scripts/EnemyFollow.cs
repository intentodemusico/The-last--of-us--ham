using Invector.CharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public static float salud = 100f;
    public GameObject player;
    NavMeshAgent enemy;
    Animator enemy2;
    vThirdPersonController hola = new vThirdPersonController();
    // Start is called before the first frame update
    void Start()
    {
        enemy=GetComponent<NavMeshAgent>();
        enemy2 = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
       if( collision.gameObject.CompareTag("Player"))
            {
            enemy2.SetBool("Attack", true);
            vThirdPersonController.salud -= 1;



        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            enemy2.SetBool("Attack", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemy.destination = player.transform.position;
        enemy2.SetFloat("Speed", Mathf.Abs(player.transform.position.x));
        if (salud == 0)
        {
            DestroyObject(gameObject);
        }
    }
}
