using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Control : MonoBehaviour
{
    public float bulletSpeed = 8.0f; 
    Player_Controll Controll = default;
    private Rigidbody BulletRg = default;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(BulletRg.transform.position.z >100){
            gameObject.SetActive(false);
        }
    }
    void Awake(){
        BulletRg = gameObject.GetComponent<Rigidbody>();
        BulletRg.velocity = -transform.forward * bulletSpeed;

    }
}
