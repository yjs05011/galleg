using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goei : Monster
{
    // Start is called before the first frame update

    void Start()
    {
        base.Start();
        this.Enemy_hp =3;
        this.enemy_score = 50;
        this.enemy_name ="GOEI";
        this.Distance = 11; ;
    }

    // Update is called once per frame
    void Update()
    {
        Enenmy_Move();
        if(gameObject.transform.position.z<=Distance+1){
        Enemy_shoot();
        }
        
        if (Enemy_hp <= 0)
        {
            gameObject.SetActive(false);
            Player.instance.playerScore+=enemy_score;
            Enemy_hp = 3;
            Enemy_Pooling.instance.Goei_Count ++;
            isShoot = false;
        }
    }
}
