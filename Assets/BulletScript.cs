using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Vector3 velocity;
    Rigidbody2D rb;
    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate(){
        rb.velocity = velocity;
    }
    void OnCollisionEnter2D(Collision2D c){
        if(c.gameObject.tag != "It") {
            gameObject.SetActive(false);
        }
    }
}
