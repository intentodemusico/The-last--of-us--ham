using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Killzone : MonoBehaviour
{
    AudioClip sonido;
    AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Cayó al mar");
            StartCoroutine(waiting());
        }
    }
    private IEnumerator waiting()
    {
        sonido = (AudioClip)Resources.Load("Audio/PlayerDied", typeof(AudioClip));
        sound.PlayOneShot(sonido, 2f);
        yield return new WaitWhile(() => sound.isPlaying);
        Scene escena = SceneManager.GetActiveScene();
        SceneManager.LoadScene(escena.name);

        // Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
