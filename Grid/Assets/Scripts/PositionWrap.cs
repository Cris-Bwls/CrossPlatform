/* 
 Authors-
 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionWrap : MonoBehaviour
{

    public Transform destination;
    public Vector3 destinationOffset;
    public Vector3 destinationRotation;
    //public Vector3 destination;
    //public GameObject Player;
    // List of all tags that can teleport
    public string TagList = "|Player1|Player2|"; 
    // Use this for initialization
    void Start()
    {
        //destination = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.tag);
        //if (Collision.)
        //{
        //    other.transform.position = destination.position;
        //}

        // If the tag of the colliding object is allowed to teleport
        if (TagList.Contains(string.Format("|{0}|", other.tag)))
        {
            // Update other objects position and rotation
            other.transform.position = other.transform.position + destination.transform.position + destinationOffset;
            other.transform.Rotate(destinationRotation.x, destinationRotation.y, destinationRotation.z);
        }
    }
}
