using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject topBlack;
    public GameObject bottomBlack;
    public bool gettingBigger = false;
    public float changerate = 0.05f;
    float scaleX;
    float scaleY;
    AudioSource audioSource;

    void Start()
    {
        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(gettingBigger){
            scaleY = scaleY + changerate;
        } else {
            scaleY = scaleY - changerate;
        }
        if(scaleY < 0.0f) {
            scaleY = 0f;
            gettingBigger = true;
            audioSource.Play();
        }
        if(scaleY > 1.0f) {
            scaleY = 1.0f;
            gettingBigger = false;
        }
        Vector3 s = new Vector3(scaleX, scaleY, 1);
        topBlack.transform.localScale = s;
        bottomBlack.transform.localScale = s;
    }
}
