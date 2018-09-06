using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed = 2.0f;
    private Vector3 pos;
    private bool rotated = false;
	private TrailColliders trailColliders;

    // Use this for initialization
    void Start()
    {
        pos = transform.position;

		trailColliders = GetComponent<TrailColliders>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (rotated == false)
            {
                transform.Rotate(0, 90, 0);
                rotated = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
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

			trailColliders.UpdateColliders();
        }
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
    }
}
