using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZICO : enemy_Status
{
    public float time1 = 0;
    
    float ZICOMovetime = -8;
    float LoopTime = 0;
    bool ZICOArrow = false;
    int ZICOturn =0;
    // Start is called before the first frame update
    void Start()
    {
        this.enemy_name = "ZICO";
        this.Enemy_hp = 1;
        this.enemy_score = 100;
        this.Distance= 15;
        base.Start();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (LoopTime > 5f)
        {
            ZICOturn++;
            LoopTime = 0;
        }
        //debug.Log(ZICOturn);
        if (deltaSpeed > -1)
        {
            deltaSpeed -= 0.4f;


        }

        LoopTime += Time.deltaTime;
        Enenmy_Move(LoopTime);
        if (ZICOturn>=2)
        {
          
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 1);
            ZICOturn = 0;
        }
    }

    public void Enenmy_Move(float ZICOMovetime)
    {

        if (gameObject.activeSelf == true)
        {

            if (gameObject.transform.position.z > Distance)
            {
                // //debug.Log( );
                float MonsterMovedZ = deltaSpeed;
                float zSpeed = MonsterMovedZ * monster_speed;

                Vector3 MonsterVelo = new Vector3(0, 0, zSpeed);

                ////debug.Log($"{Monster_Rigidbody.name}, before Rigid velo: {Monster_Rigidbody.velocity}, Velo: {MonsterVelo}");
                Monster_Rigidbody.velocity = MonsterVelo;
                    //debug.Log($"{Monster_Rigidbody.name}, after Rigid velo: {Monster_Rigidbody.velocity}, Velo: {MonsterVelo}");
                    //debug.Log($"{Monster_Rigidbody.name}, {Monster_Rigidbody.transform.position.z}, Moved: {zSpeed}, Velo: {MonsterVelo}");
            }
            else
            {


                if (LoopTime <2.5f )
                {
                    ZICOArrow = true;



                }
                else
                {
                    ZICOArrow = false;

                }
                if (ZICOArrow)
                {
                    Vector3 MonsterVelo = new Vector3(1, 0, 0);
                    Monster_Rigidbody.velocity = MonsterVelo;
                }
                else
                {
                    Vector3 MonsterVelo = new Vector3(-1, 0, 0);
                    Monster_Rigidbody.velocity = MonsterVelo;
                }






                ////debug.Log($"{Monster_Rigidbody.name}, before Rigid velo: {Monster_Rigidbody.velocity}, Velo: {MonsterVelo}");

            }

            }
            else
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, Distance+10);
            }


            
        

    }

}
