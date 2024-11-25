using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMudançadeCor : MonoBehaviour
{
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if( nag.dead == true)
        {
            cam.backgroundColor = new Vector4();
        }
    }
}
