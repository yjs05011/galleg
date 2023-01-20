using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Monster
{
    public bool isPattern = false;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        this.enemy_name = "Boss";
        this.Enemy_hp = 3;
        this.enemy_score = 10000;
        this.Distance= 13;
    }

    // Update is called once per frame
    void Update()
    {
        BossMove();
        if (gameObject.transform.position.z <= Distance + 1)
        {
            Enemy_shoot();
            BossPattern();
        }
        if( Enemy_hp <=0){
            Enemy_Pooling.instance.BossCount--;
            Destroy(gameObject);
            Player.instance.playerScore += enemy_score;
        }
    }

    void BossPattern(){
         if(isPattern == false){
            Debug.Log(GameManager.instance.enemyBulletCount);
            if(GameManager.instance.enemyBulletCount >=99){
                GameManager.instance.enemyBulletCount =0;
            }
        
            Bullet_Pooling.instance.enemyBulletPooling[GameManager.instance.enemyBulletCount].transform.position = gameObject.transform.position;
            Bullet_Pooling.instance.enemyBulletPooling[GameManager.instance.enemyBulletCount].SetActive(true);
           
            GameManager.instance.enemyBulletCount++;
            StartCoroutine(PatternRate());
        }
    }
    void BossMove()
    {
        if (gameObject.transform.position.z > Distance)
        {
            // ////debug.Log( );
            float zSpeed = monster_speed;

            Vector3 MonsterVelo = new Vector3(0, 0, zSpeed);

            Monster_Rigidbody.velocity = MonsterVelo;
            ////debug.Log($"{Monster_Rigidbody.name}, after Rigid velo: {Monster_Rigidbody.velocity}, Velo: {MonsterVelo}");
            ////debug.Log($"{Monster_Rigidbody.name}, {Monster_Rigidbody.transform.position.z}, Moved: {zSpeed}, Velo: {MonsterVelo}");

        }
        else
        {
           Vector3 MonsterVelo = new Vector3(0, 0, 0);

            Monster_Rigidbody.velocity = MonsterVelo;
        }
    }
        protected IEnumerator PatternRate()
    {
        isPattern = true;
        yield return new WaitForSeconds(0.5f);
        isPattern = false;
    }
    protected IEnumerator Delay(){
        yield return new WaitForSeconds(0.2f);
    }
}
