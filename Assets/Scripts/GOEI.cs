using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOEI : enemy_Status
{
    public float time1 = 0;
    
    float GOEIMovetime = -8;
    float LoopTime = 0;
    bool GOEIArrow = false;
    float GOEIturn = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.Enemy_hp =3;
        this.enemy_score = 50;
        this.enemy_name ="GOEI";
        this.Distance= 11;
        base.Start();
    }
 void Update()
    {
        //Debug.Log(GameManager.instance.enemyBulletCount);
        if (LoopTime > 5f)
        {
            GOEIturn++;
            LoopTime = 0;
        }
        ////debug.Log(GOEIturn);
        if (deltaSpeed > -1)
        {
            deltaSpeed -= 0.4f;


        }

        LoopTime += Time.deltaTime;
        Enenmy_Move(LoopTime);
        if (GOEIturn >= 2)
        {
          
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 1);
            GOEIturn= 0;

            

        }
        if(base.CoroutineCheck ==false){
            StartCoroutine(shot());
        }else{

        }
        
    
    }        

        public void  Enenmy_Move(float GOEIMovetime)
    {

            if (gameObject.activeSelf == true)
            {

                if (gameObject.transform.position.z > Distance)
                {
                    // ////debug.Log( );
                    float MonsterMovedZ = deltaSpeed;
                    float zSpeed = MonsterMovedZ * monster_speed;

                    Vector3 MonsterVelo = new Vector3(0, 0, zSpeed);

                    //////debug.Log($"{Monster_Rigidbody.name}, before Rigid velo: {Monster_Rigidbody.velocity}, Velo: {MonsterVelo}");
                    Monster_Rigidbody.velocity = MonsterVelo;
                    ////debug.Log($"{Monster_Rigidbody.name}, after Rigid velo: {Monster_Rigidbody.velocity}, Velo: {MonsterVelo}");
                    ////debug.Log($"{Monster_Rigidbody.name}, {Monster_Rigidbody.transform.position.z}, Moved: {zSpeed}, Velo: {MonsterVelo}");
            }
            else
            {


                if (LoopTime <2.5f)
                {
                    GOEIArrow = true;



                }
                else
                {
                    GOEIArrow = false;

                }
                if (GOEIArrow)
                {
                    Vector3 MonsterVelo = new Vector3(1, 0, 0);
                    Monster_Rigidbody.velocity = MonsterVelo;
                }
                else
                {
                    Vector3 MonsterVelo = new Vector3(-1, 0, 0);
                    Monster_Rigidbody.velocity = MonsterVelo;
                }






                //////debug.Log($"{Monster_Rigidbody.name}, before Rigid velo: {Monster_Rigidbody.velocity}, Velo: {MonsterVelo}");

            }

            }
            else
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, Distance+10);
            }


            
        

    }
}