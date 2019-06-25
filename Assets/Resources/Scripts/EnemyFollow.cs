using Invector.CharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public static float salud = 100f;
    public GameObject player;
    private AudioSource sound;
    public AudioClip sonido;
    NavMeshAgent enemy;
    Animator enemy2;
    vThirdPersonController hola = new vThirdPersonController();
    // Start is called before the first frame update
    void Start()
    {
        enemy=GetComponent<NavMeshAgent>();
        enemy2 = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
       if( collision.gameObject.CompareTag("Player"))
            {
            enemy2.SetBool("Attack", true);
            vThirdPersonController.salud -= 1;
            sonido = (AudioClip)Resources.Load("Audio/ZombieAttack", typeof(AudioClip));
            sound.PlayOneShot(sonido);

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
        sonido = (AudioClip)Resources.Load("Audio/ZombieWalking", typeof(AudioClip));
        sound.PlayOneShot(sonido);
        if (salud == 0)
        {
            DestroyObject(gameObject);
        }
    }
}
