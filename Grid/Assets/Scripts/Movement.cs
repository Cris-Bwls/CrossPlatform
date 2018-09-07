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
    public PlayerInput PlayerKeys;

    public int maxJumpSpaces = 3;
    public int maxJumpDelay = 2;
    private int currentJumpSpace = 0;
    private bool jumping = false;

    public int maxTunnelSpaces = 3;
    public int maxTunnelDelay = 2;
    private int currentTunnelSpace = 0;
    private bool tunneling = false;

    private bool canTurn = true;

    private bool dodging = false;
    public int maxDodgeCount = 3;
    private int currentDodgeSpaces = 0;    

    //public KeyCode RotateRightKey;
    //public KeyCode RotateLeftKey;
    //public KeyCode JumpKey;

    private float userTime;

    // Use this for initialization
    void Start()
    {
        PlayerKeys = gameObject.GetComponent<PlayerInput>();
        prevPos = transform.position;
        pos = transform.position + transform.forward;

		trailColliders = GetComponent<TrailColliders>();



        //userTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //userTime += Time.deltaTime; 

        if (Input.GetKeyDown(PlayerKeys.RotateRightKey) && canTurn)
        {
            if (rotated == false)
            {
                transform.Rotate(0, 90, 0);
                rotated = true;
            }
        }

        if (Input.GetKeyDown(PlayerKeys.RotateLeftKey) && canTurn)
        {
            if (rotated == false)
            {
                transform.Rotate(0, -90, 0);
                rotated = true;
            }
        }

        //userTime += Time.deltaTime;
        if (Input.GetKeyDown(PlayerKeys.JumpKey))
        {
            canTurn = false;

            if (!jumping)
            {
                jumping = true;
                currentJumpSpace = 0;
                transform.position += transform.up;
                pos += transform.up;
            }

            
        }

        if (Input.GetKeyDown(PlayerKeys.TunnelingKey))
        {
            canTurn = false;

            if (!tunneling)
            {
                tunneling = true;
                currentTunnelSpace = 0;
                transform.position -= transform.up;
                pos -= transform.up;
            }
        }

        if (Input.GetKeyDown(PlayerKeys.DodgeRightKey))
        {
            if(!dodging)
            {
                dodging = true;
                transform.position += transform.right + transform.right;
                pos += transform.right + transform.right;            
            }
        }

        if (Input.GetKeyDown(PlayerKeys.DodgeLeftKey))
        {
            if(!dodging)
            {
                dodging = true;
                transform.position -= transform.right + transform.right;
                pos -= transform.right + transform.right;
            }
        }

        if (pos == transform.position)
        {
			trailColliders.PlaceCollider(prevPos);
			prevPos = pos;

            pos += transform.forward;
            rotated = false;

            if (jumping)
            {
                if (currentJumpSpace < maxJumpSpaces + maxJumpDelay)
                {
                    currentJumpSpace++;
                    if (currentJumpSpace == maxJumpSpaces)
                    {
                        transform.position -= transform.up;
                        pos -= transform.up;
                        canTurn = true;
                    }
                }
                else
                    jumping = false;
            }

            if (dodging)
            {
                if(currentDodgeSpaces < maxDodgeCount)             
                    currentDodgeSpaces++;
                else
                {
                    currentDodgeSpaces = 0;
                    dodging = false;
                }
            }

            if (tunneling)
            {
                if (currentTunnelSpace < maxTunnelSpaces + maxTunnelDelay)
                {
                    currentTunnelSpace++;
                    if (currentTunnelSpace == maxTunnelSpaces)
                    {
                        transform.position += transform.up;
                        pos += transform.up;
                        canTurn = true;
                    }
                }
                else
                {
                    tunneling = false;
                }
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
    }
    
}
