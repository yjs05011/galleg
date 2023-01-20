using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    public Rigidbody BulletRigideBody = null;
    private float bulletSpeed = 8f;
    // Start is called before the first frame update
    void Start()
    {
        BulletRigideBody = gameObject.GetComponent<Rigidbody>();
        gameObject.transform.LookAt(Player.instance.transform.position);
        BulletRigideBody.velocity = transform.forward * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        if(gameObject.transform.position.z <-16){
            gameObject.SetActive(false);
        }
        
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            Player.instance.player_hp --;
            gameObject.SetActive(false);
        }
    }   
}
