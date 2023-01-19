using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Resoltion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Camera camera = GetComponent<Camera>();
        Rect rect = camera.rect;
        float scaleheight =((byte)((float)Screen.width/ Screen.height) / ((float)9/16));
        float scalewidth = 1f/scaleheight;
        if(scaleheight <1){
            rect.height = scaleheight;
            rect.y = (1f-scaleheight) /2 ;
        }
        else {
            rect.width = scalewidth;
            rect.x = (1f -scalewidth)/2;
        }
        camera.rect = rect;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
