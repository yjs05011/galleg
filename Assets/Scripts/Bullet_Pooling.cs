using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Pooling : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyBullet = null;

    public GameObject playerBullet = null;
   

    public GameObject[] enemyBulletPooling = new GameObject[100];

    public GameObject[] playerBulletPooling = new GameObject [30];


    public static Bullet_Pooling instance = null;

    void Awake(){
                 if(null == instance){
            instance = this; 
        }else{
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        for (int i = 0; i < enemyBulletPooling.Length; i++)
        {
            GameObject bullet = Instantiate(enemyBullet);
            bullet.SetActive(false);
            enemyBulletPooling[i] = bullet;
        }
        for (int i = 0; i < playerBulletPooling.Length; i++)
        {
            GameObject bullet = Instantiate(playerBullet);
            bullet.SetActive(false);
            playerBulletPooling[i] = bullet;
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
      
    
}
