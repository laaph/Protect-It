using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameScript : MonoBehaviour
{
    // Start is called before the first frame update
    SimpleSphereMovement it;
    public bool creditsScene;
    void Start()
    {
        it = GameObject.FindWithTag("It").GetComponent<SimpleSphereMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")|| Input.GetKeyDown("space") || Input.GetKeyDown("enter")) {
            it.speed = 10;
            it.wrapX = false;
        }
        if(creditsScene){
            if(Input.GetButtonDown("Fire2")){
                UnityEngine.SceneManagement.SceneManager.LoadScene(11);
            }
        }
    }
}
