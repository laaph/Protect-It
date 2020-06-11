using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadItCleanup : MonoBehaviour
{
    public Sprite sadPlayer;
    AudioSource audioData;
    Text directionsText;
    bool dead = false;
    void Start()
    {
        directionsText = FindObjectsOfType(typeof(Text))[0] as Text;
        audioData = GetComponent<AudioSource>();
    }
    void Update(){
        if(dead){
            if(Input.GetButtonDown("Fire1") || Input.GetKeyDown("space") || Input.GetKeyDown("enter")){
                UnityEngine.SceneManagement.SceneManager.LoadScene(
                    UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
                );
            }
        }
    }    
    public void Dead()
    {
        GetComponent<SpriteRenderer>().sprite = sadPlayer;
        audioData.Play();
        directionsText.text = "Press Fire1 to restart level";
        dead = true;
    }
}
