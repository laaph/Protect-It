using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleSphereMovement : MonoBehaviour
{
    public Vector3 velocity;
    public float speed;
    public bool wrapX;
    public int nextScene;
    Rigidbody2D rb;
    Transform t;
    public GameObject bit;
    public GameObject player;
    AudioSource audioSource;
    GameObject preventOverBouncing; // we have this started with any object to prevent testing against null

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        preventOverBouncing = this.gameObject;
        rb = GetComponent<Rigidbody2D>();
        t = GetComponent<Transform>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = velocity * speed;
        if(wrapX) {
            if(t.position.x > 7f){
                t.position = new Vector3(-7f, t.position.y, t.position.z);
            } 
        } else {
            if(Mathf.Abs(t.position.x) > 7f || Mathf.Abs(t.position.y) > 5.4f){
                UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D c){
        if(c.gameObject.tag == "Wall" || c.gameObject.tag == "Bullet") {

            for(int i = 0; i < 10; i++){
                // Probably should make these in Start(), but what the hell
                GameObject b = Instantiate(bit);
                b.transform.position = t.position;
                b.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
            }

            // By moving things we care about in to DeadItCleanup, attached to the player, we can not start a
            // Coroutine to take care of things
            player.GetComponent<DeadItCleanup>().Dead();

            gameObject.SetActive(false);
            // Do UI changes here too
        }
        if(preventOverBouncing == c.gameObject) {
            return;
        }
        if(c.gameObject.tag == "Bounce-45") {
            if(velocity.x < -0.9) { // Moving left
                velocity = new Vector3(0f, 1f, 0f);
                audioSource.Play();
                return;
            }
            if(velocity.x > 0.9) { // Moving right
                velocity = new Vector3(0f, -1f, 0f);
                audioSource.Play();
                return;
            }
            if(velocity.y < -0.9) { // Moving down
                velocity = new Vector3(1f, 0f, 0f);
                audioSource.Play();
                return;
            }
            if(velocity.y > 0.9) { // Moving right
                audioSource.Play();
                velocity = new Vector3(-1f, -0f, 0f);
                return;
            }
        }
        if(c.gameObject.tag == "Bounce+45") {  // For this, it is exactly the opposite.  There is probably some algorithm to do this quickly.
            if(velocity.x < -0.9) { // Moving left
                velocity = new Vector3(0f, -1f, 0f);
                audioSource.Play();
                return;
            }
            if(velocity.x > 0.9) { // Moving right
                velocity = new Vector3(0f, 1f, 0f);
                audioSource.Play();
                return;
            }
            if(velocity.y < -0.9) { // Moving down
                velocity = new Vector3(-1f, 0f, 0f);
                audioSource.Play();
                return;
            }
            if(velocity.y > 0.9) { // Moving right
                velocity = new Vector3(1f, -0f, 0f);
                audioSource.Play();
                return;
            }
        }
    }
}
