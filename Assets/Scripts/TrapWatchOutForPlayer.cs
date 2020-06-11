using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapWatchOutForPlayer : MonoBehaviour
{
    public GameObject trap;
    TrapScript trapScript;
    // Start is called before the first frame update
    void Start()
    {
        trapScript = trap.GetComponent<TrapScript>();   
    }

    void OnCollisionEnter2D(Collision2D c){
        if(c.gameObject.tag == "Player"){
            trapScript.gettingBigger = false;
        }
    }
}
