using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDisplay : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Vector3 cameraPos = touchObject.getPos();
        Debug.Log(cameraPos.x);
        Debug.Log(cameraPos.z);
    }
}
