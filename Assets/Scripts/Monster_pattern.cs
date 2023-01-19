using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_pattern : MonoBehaviour
{
    private Rigidbody Monster_Rigidbody = default;
    public float monster_speed = 2.0f;


    public GameObject playerBullet = default;
    public GameObject[] playerBulletPools = new GameObject[30];

    public GameObject enemyBullet = default;
    public GameObject[] enemyBulletPools = new GameObject[100];

    public  static Monster_pattern instance = null;
    
    public static Player_Controll player = null;
    // Start is called before the first frame update
    void Awake()
    {
         if(null == instance){
            instance = this; 
        }else{
            Destroy(this.gameObject);
            
        }
    }
    void Start()
    {
        for (int i = 0; i < playerBulletPools.Length; i++)
        {
            GameObject Bullet = Instantiate(playerBullet);
            Bullet.SetActive(false);
            playerBulletPools[i] = Bullet;
        }

        for(int i = 0; i< enemyBulletPools.Length; i++){
            GameObject Bullet = Instantiate(enemyBullet);
            Bullet.SetActive(false);
            enemyBulletPools[i] = Bullet;
        }


    }


    // Update is called once per frame
    void Update()
    {

    }

}
