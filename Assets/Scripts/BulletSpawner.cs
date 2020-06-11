using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bullet;
    public Vector3 direction;
    public float speed;
    public int maxBullets;
    public float timeBetweenBullets;
    GameObject[] bullets;
    WaitForSeconds wfs;
    AudioSource audioSource;
    // Start is called before the first frame update
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        bullets = new GameObject[maxBullets];
        for(int i = 0; i < maxBullets; i++){
            bullets[i] = Instantiate(bullet);
            bullets[i].GetComponent<BulletScript>().velocity = speed * direction;
            bullets[i].SetActive(false);
        }
        wfs = new WaitForSeconds(timeBetweenBullets);
        StartCoroutine(BulletManager());
    }
    IEnumerator BulletManager(){
        int bulletNum = 0;
        while(true) {
            GameObject b = bullets[bulletNum];
            b.transform.position = transform.position;
            b.GetComponent<Rigidbody2D>().velocity = direction;
            b.SetActive(true);
            audioSource.Play();
            yield return wfs;
            bulletNum = bulletNum + 1; 
            if(bulletNum >= maxBullets) {
                bulletNum = 0;
            }
        }
    }
}
