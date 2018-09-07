using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed = 2.0f;
    private Vector3 pos;
    private bool rotated = false;
	private TrailColliders trailColliders;
	private Vector3 prevPos;

	// Use this for initialization
	void Start()
    {
		prevPos = transform.position;
        pos = transform.position + transform.forward;

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
			trailColliders.PlaceCollider(prevPos);
			prevPos = pos;

            pos += transform.forward;
            rotated = false;

        }
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
    }
}
