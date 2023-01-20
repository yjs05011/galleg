using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private float enemy_hp;
    public float enemy_score;
    public string enemy_name;
    public float Enemy_hp
    {
        get; set;
    }
    public float Enemy_score
    {
        get; set;
    }
    public float Distance
    {
        get; set;
    }

    protected float monster_speed = -2.0f;

    protected float LoopTime = 0f; 
    protected int bulletCount =0;
    protected Rigidbody Monster_Rigidbody = null;
    protected bool LoopCheck = false;
    protected bool isShoot =false;
    // Start is called before the first frame update

    protected void Start()
    {
        Monster_Rigidbody = gameObject.GetComponent<Rigidbody>();
    }
    protected void Awake(){
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Enenmy_Move()
    {
        
        
        LoopTime += Time.deltaTime;

        if (gameObject.activeSelf == true)
        {

            if (gameObject.transform.position.z > Distance)
            {
                // ////debug.Log( );
                float zSpeed =  monster_speed;

                Vector3 MonsterVelo = new Vector3(0, 0, zSpeed);

                Monster_Rigidbody.velocity = MonsterVelo;
                ////debug.Log($"{Monster_Rigidbody.name}, after Rigid velo: {Monster_Rigidbody.velocity}, Velo: {MonsterVelo}");
                ////debug.Log($"{Monster_Rigidbody.name}, {Monster_Rigidbody.transform.position.z}, Moved: {zSpeed}, Velo: {MonsterVelo}");
                
            }
            else
            {


                if (LoopTime < 2.5f)
                {
                    LoopCheck = true;



                }
                else
                {   
                    if(LoopTime < 5f){
                        LoopCheck = false;
                    }else{
                        LoopTime = 0;
                    }
                    
                    

                }
                if (LoopCheck)
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
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, Distance + 10);
        }
    }
    protected void Enemy_shoot(){
        if(isShoot == false){
            Debug.Log(GameManager.instance.enemyBulletCount);
            if(GameManager.instance.enemyBulletCount >=99){
                GameManager.instance.enemyBulletCount =0;
            }
            Bullet_Pooling.instance.enemyBulletPooling[GameManager.instance.enemyBulletCount].transform.position = gameObject.transform.position;
            Bullet_Pooling.instance.enemyBulletPooling[GameManager.instance.enemyBulletCount].SetActive(true);
            GameManager.instance.enemyBulletCount++;
            StartCoroutine(ShootRate());
        }
    }
    protected IEnumerator ShootRate()
    {
        isShoot = true;
        yield return new WaitForSeconds(3f);
        isShoot = false;
    }

}