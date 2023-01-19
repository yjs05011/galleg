using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPools : MonoBehaviour
{
    public GameObject ZICOPrefab;
    public List<GameObject> ZICOPrefabs;
    public GameObject GOEIPrefab;
    public List<GameObject> GOEIPrefabs;
    public int enemyMaxSpawn;
    public bool ableSpawn = false;
    public Transform ZICOTransf = default;
    public static ObjectPools instance = null;




    // Start is called before the first frame update
    void Awake()
    {
        List<GameObject> ZICOPrefabs = new List<GameObject>();
         if(null == instance){
            instance = this; 
        }else{
            Destroy(this.gameObject);
            
        }
        ZICORandomSpawn(7);
        GOEIRandomSpawn(7);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ZICORandomSpawn(int time)
    {
        Debug.Log("working");
        for (int i = 0; i < time; i++)
        {
            float ZICOX = (float)(i*2.1) - 7;
            
            if (enemyMaxSpawn < 7)
            {
                ableSpawn = true;
            }
            if (ableSpawn)
            {
                 
                if (ZICOPrefabs.Count < 7)
                {
                    
                    GameObject ZICO = (GameObject)Instantiate(ZICOPrefab, new Vector3(ZICOX, 10, 24), Quaternion.Euler(0, 180.0f, 0));
                    ZICO.name = $"{name}_{i}";
                    enemyMaxSpawn = ZICOPrefabs.Count;
                    ZICOPrefabs.Add(ZICO);


                }
                else
                {
                    ableSpawn = false;
                }
            }
        }


    }
    void GOEIRandomSpawn(int time)
    {
        Debug.Log("working");
        for (int i = 0; i < time; i++)
        {
            float GOEIX = (float)(i*2.1) - 7;
            
            if (enemyMaxSpawn < 7)
            {
                ableSpawn = true;
            }
            if (ableSpawn)
            {
                 
                if (GOEIPrefabs.Count < 7)
                {
                    
                    GameObject GOEI = (GameObject)Instantiate(GOEIPrefab, new Vector3(GOEIX, 10, 20), Quaternion.Euler(0, 180.0f, 0));
                    GOEI.name = $"{name}_{i}";
                    enemyMaxSpawn = GOEIPrefabs.Count;
                    GOEIPrefabs.Add(GOEI);


                }
                else
                {
                    ableSpawn = false;
                }
            }
        }


    }
}
