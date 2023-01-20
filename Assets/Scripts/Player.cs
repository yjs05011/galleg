using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public float player_hp = 1;
    public float playerScore= 0;

    public float huntCount =56;

    private bool isShoot = false;


    public int bulletCount = 0;
    public Rigidbody player_Rigidbody = default;
    public static Player instance = null;
    private float player_Speed = 8f;
    // Start is called before the first frame update
    void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        player_Rigidbody = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        shooting();
        if(player_hp<=0){
            gameObject.SetActive(false);    
        }
        // Invoke("shooting",0.8f);
    }
    public void Move()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            player_Rigidbody.MovePosition(player_Rigidbody.position + Vector3.forward * Time.deltaTime * player_Speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player_Rigidbody.MovePosition(player_Rigidbody.position + Vector3.left * Time.deltaTime * player_Speed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            player_Rigidbody.MovePosition(player_Rigidbody.position + Vector3.right * Time.deltaTime * player_Speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {

            player_Rigidbody.MovePosition(player_Rigidbody.position + Vector3.back * Time.deltaTime * player_Speed);
        }
    }
    void shooting()
    {
        if (Input.GetKey(KeyCode.Space) && isShoot == false)
        {
            if (bulletCount > 28)
            {
                bulletCount = 0;
            }
            Debug.Log(bulletCount);
            Bullet_Pooling.instance.playerBulletPooling[bulletCount].transform.position = gameObject.transform.position;
            Bullet_Pooling.instance.playerBulletPooling[bulletCount].SetActive(true);
            bulletCount++;
            StartCoroutine(ShootRate());
        }
        
    }

    IEnumerator ShootRate()
    {
        isShoot = true;
        yield return new WaitForSeconds(0.3f);
        isShoot = false;
    }

}
