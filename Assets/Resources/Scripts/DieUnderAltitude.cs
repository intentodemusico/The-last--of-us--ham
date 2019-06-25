using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieUnderAltitude : MonoBehaviour
{
    // Start is called before the first frame update
    AudioClip sonido;
    AudioSource sound;
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if(gameObject.transform.position.y<43)
            
    }

    void Cmuere()
    {
        sonido = (AudioClip)Resources.Load("Audio/PlayerDied", typeof(AudioClip));
        sound.PlayOneShot(sonido, 2f);
        //yield return new WaitWhile(() => sound.isPlaying);
        //Scene escena = SceneManager.GetActiveScene();
        //SceneManager.LoadScene(escena.name);
    }
}
