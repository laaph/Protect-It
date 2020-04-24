using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Rigidbody2D))]
public class SimplePlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;

    [SerializeField]
    #pragma warning disable CS0649
    private float speedMultiplier; // This needs to be set in the inspector
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Assert.IsTrue(speedMultiplier > 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * speedMultiplier, 0.8f),
            Mathf.Lerp(0, Input.GetAxis("Vertical") * speedMultiplier, 0.8f));
    }

    void OnCollisionEnter2D(Collision2D c){
        if(c.gameObject.tag == "It"){
            SimpleSphereMovement ssm = c.gameObject.GetComponent<SimpleSphereMovement>();
            // First figure out which axis is faster 
            float v = Input.GetAxis("Vertical");
            float h = Input.GetAxis("Horizontal");
            if(Mathf.Abs(v) > Mathf.Abs(h)) {
                if(v > 0) {
                    ssm.velocity = Vector2.up;
                } else { // v < 0 
                    ssm.velocity = Vector2.down;
                }
            } else {  // abs(h) > abs(v)
                if(h > 0){
                    ssm.velocity = Vector2.right;
                } else { // h < 0
                    ssm.velocity = Vector2.left;
                }
            }
        }
    }
}
