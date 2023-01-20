using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zico : Monster
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        this.enemy_name = "ZICO";
        this.Enemy_hp = 1;
        this.enemy_score = 100;
        this.Distance= 15;
    }

    // Update is called once per frame
    void Update()
    {
        Enenmy_Move();
        if (gameObject.transform.position.z <= Distance+1)
        {
            Enemy_shoot();
        }
        if (Enemy_hp <= 0)
        {
            gameObject.SetActive(false);
            Player.instance.playerScore += enemy_score;
            Enemy_hp = 1;
            Enemy_Pooling.instance.Zico_Count++;
            isShoot = false;
        }
    }
}
