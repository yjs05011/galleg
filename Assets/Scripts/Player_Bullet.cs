using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet : MonoBehaviour
{
    public Rigidbody BulletRigideBody = null;
    private float bulletSpeed = 8f;
    // Start is called before the first frame update
    void Start()
    {
        BulletRigideBody = gameObject.GetComponent<Rigidbody>();
        BulletRigideBody.velocity = transform.forward * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.z>16){
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zico"))
        {
            Zico Zico_state = other.GetComponent<Zico>();
            Zico_state.Enemy_hp--;
            gameObject.SetActive(false);
            Debug.Log(Zico_state.Enemy_hp);

        }
        else if
        (other.gameObject.CompareTag("Goei"))
        {
            Goei Goei_state = other.GetComponent<Goei>();
            Goei_state.Enemy_hp--;
            gameObject.SetActive(false);
            Debug.Log(Goei_state.Enemy_hp);

        }else if(other.gameObject.CompareTag("Boss"))
        {
            Boss Boss_state = other.GetComponent<Boss>();
            Boss_state.Enemy_hp--;
            gameObject.SetActive(false);
            Debug.Log(Boss_state.Enemy_hp);

        }
    }


}
