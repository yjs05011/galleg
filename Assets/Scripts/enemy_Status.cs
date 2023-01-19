using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_Status : MonoBehaviour
{
    [SerializeField]
    private float enemy_hp;
    public float enemy_score;
    public string enemy_name;
    private float distance;
    public float spawnRaterMin = 0.5f;
    public float spawnRaterMax = 3.0f;
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
    public Transform targerTransf = default;

    public Rigidbody Monster_Rigidbody = default;
    public float monster_speed = 2.0f;

    public float deltaSpeed = 0;
    private float spwanRate = default;
    private float timeAfterSpawn = default;
    public bool CoroutineCheck = false;
    public List<GameObject> enemy;

    public GameObject[] bullets;



    public Player_Controll player;
    // Start is called before the first frame update
    void Awake()
    {

    }
    protected void Start()
    {
        bullets = Monster_pattern.instance.enemyBulletPools;
        Monster_Rigidbody = gameObject.GetComponent<Rigidbody>();
        timeAfterSpawn = 0f;
        spwanRate = Random.Range(spawnRaterMin, spawnRaterMax);
        



    }

    // Update is called once per frame
    void Update()
    {


        // if (turn == 4)
        // {
        //     turn = 0;

        //     for(int i =0; i<ZICO.Count; i++){
        //         GOEI[i].transform.position = new Vector3 (GOEI[i].transform.position.x,GOEI[i].transform.position.y,GOEI[i].transform.position.z-1);
        //         ZICO[i].transform.position = new Vector3 (ZICO[i].transform.position.x,ZICO[i].transform.position.y,ZICO[i].transform.position.z-1);
        //     }

        // }


    }


    protected IEnumerator shot()
    {
        CoroutineCheck =true;

        Enenmy_shot();
        CoroutineCheck =false;
        yield return new WaitForSeconds(1.0f);
        
    }

    void Enenmy_shot()
    {

        bullets[GameManager.instance.enemyBulletCount].SetActive(true);

        bullets[GameManager.instance.enemyBulletCount].transform.position = gameObject.transform.position;
        bullets[GameManager.instance.enemyBulletCount].transform.LookAt(player.instance.transform.position);
        transform.LookAt(player.instance.transform.position);

        
        GameManager.instance.enemyBulletCount += 1;
        if(GameManager.instance.enemyBulletCount <100){
            GameManager.instance.enemyBulletCount =0;
        }
        Debug.Log(GameManager.instance.enemyBulletCount);
    }

}
