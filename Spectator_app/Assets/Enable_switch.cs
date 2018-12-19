using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enable_switch : MonoBehaviour
{
    public Vector3 pos_1;
    private float timeleft;
    // Use this for initialization
    void Start()
    {
        pos_1 = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;
        if (timeleft <= 0.0)
        {
            timeleft = 0.2f;

            Vector3 pos_2 = transform.position;
            if (pos_1 == pos_2)
            {
                MeshRenderer meshrender = GetComponent<MeshRenderer>();
                meshrender.material.color = new Color(255, 255, 255, 0);
            }
            else
            {
                MeshRenderer meshrender = GetComponent<MeshRenderer>();
                meshrender.material.color = new Color(255, 255, 255, 1);
            }
            pos_1 = pos_2;
        }
    }
}
