using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int enemyBulletCount = 0;
    public float gameTime = 0; 
    public static GameManager instance = null;
    // Start is called before the first frame update
    void Awake(){
         if(null == instance){
            instance = this; 
        }else{
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static GameManager Instance{
        get{
            if(null == instance )
            {
                return null;

            }
            return instance;
        }
    }
}
