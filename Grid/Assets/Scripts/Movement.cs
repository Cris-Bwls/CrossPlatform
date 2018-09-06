using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed = 2.0f;
    private Vector3 pos;
    //private Transform trans;
    bool rotated = false;

    // Use this for initialization
    void Start()
    {
        pos = transform.position;
        //trans = transform;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D) /*&& trans.position == pos*/)
        {
            if (rotated == false)
            {
                transform.Rotate(0, 90, 0);
                rotated = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.A) /*&& trans.position == pos*/)
        {
            if (rotated == false)
            {
                transform.Rotate(0, -90, 0);
                rotated = true;
            }
        }
        if (pos == transform.position)
        {
            pos += transform.forward;
            rotated = false;
        }
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
    }
}
