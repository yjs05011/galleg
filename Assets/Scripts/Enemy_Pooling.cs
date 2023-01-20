using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Pooling : MonoBehaviour
{
    public GameObject Zico = null;
    public GameObject Goei = null;
    public GameObject[] ZicoPooling  = new GameObject [7];
    public GameObject[] GoeiPooling  = new GameObject [7];
    public GameObject Boss = null;
    public int Zico_Count = 0;
    public int Goei_Count = 0;
    public int BossCount = 1;
    public bool BossCheck = false;
    public static Enemy_Pooling instance = null;
    // Start is called before the first frame update
    void Awake(){
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
        for (int i = 0; i < ZicoPooling.Length; i++)
        {
            float ZICOX = (float)(i*2) - 7;
            GameObject enemy = (GameObject)Instantiate(Zico, new Vector3(ZICOX, 10, 24), Quaternion.Euler(0, 180.0f, 0));
            
            ZicoPooling[i] = enemy;
        }
                  for (int i = 0; i < GoeiPooling.Length; i++)
        {
            float GoeiX = (float)(i*2) - 7;
            GameObject enemy = (GameObject)Instantiate(Goei, new Vector3(GoeiX, 10, 27), Quaternion.Euler(0, 180.0f, 0));
            
            GoeiPooling[i] = enemy;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Player.instance.huntCount < 56)
        {
            if (Zico_Count >= 7 && Goei_Count >= 7)
            {
                Zico_Count = 0;
                Goei_Count = 0;
                for (int i = 0; i < ZicoPooling.Length; i++)
                {
                    float ZICOX = (float)(i * 2) - 7;
                    ZicoPooling[i].transform.position = new Vector3(ZICOX, 10, 24);
                    ZicoPooling[i].SetActive(true);
                }
                for (int i = 0; i < GoeiPooling.Length; i++)
                {
                    float ZICOX = (float)(i * 2) - 7;
                    GoeiPooling[i].transform.position = new Vector3(ZICOX, 10, 27);
                    GoeiPooling[i].SetActive(true);
                }
            }
        }
        else
        {
            if (!BossCheck)
            {
                for (int i = 0; i < ZicoPooling.Length; i++)
                {
                    float ZICOX = (float)(i * 2) - 7;
                    ZicoPooling[i].transform.position = new Vector3(ZICOX, 10, 24);
                    ZicoPooling[i].SetActive(false);
                }
                for (int i = 0; i < GoeiPooling.Length; i++)
                {
                    float ZICOX = (float)(i * 2) - 7;
                    GoeiPooling[i].transform.position = new Vector3(ZICOX, 10, 27);
                    GoeiPooling[i].SetActive(false);
                }
                GameObject boss = Instantiate(Boss,
                                new Vector3(0, 10, 24), Quaternion.Euler(0, 180.0f, 0));

                BossCheck = true;
            }
        }


    }
}
