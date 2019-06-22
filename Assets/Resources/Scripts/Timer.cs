using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    [Header("Texto:")]
    public Text text;
    
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string second = (t % 60).ToString("f2");

        text.text = minutes+":"+second;
    }
}
