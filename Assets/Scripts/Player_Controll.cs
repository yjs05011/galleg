using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controll : MonoBehaviour
{
    public float player_Speed = 8f;

    public Rigidbody PlayerRgBody = default;
    public float Player_Score = 0;
    public float huntCount = 0;
    public Player_Controll instance = null;
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
        PlayerRgBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
         Move();
    }
    public void Move()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            PlayerRgBody.MovePosition(PlayerRgBody.position + Vector3.forward * Time.deltaTime * player_Speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            PlayerRgBody.MovePosition(PlayerRgBody.position + Vector3.left * Time.deltaTime * player_Speed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            PlayerRgBody.MovePosition(PlayerRgBody.position + Vector3.right * Time.deltaTime * player_Speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {

            PlayerRgBody.MovePosition(PlayerRgBody.position + Vector3.back * Time.deltaTime * player_Speed);
        }
    }

}
