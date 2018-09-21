/* 
 Authors-
 Paul
 Chris
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public int count;
    public float speed = 2.0f;

    private Vector3 pos;
    private bool rotated = false;
	private TrailColliders trailColliders;
    private TrailRenderer trailRenderer;
	private Vector3 prevPos;
    public PlayerInput playerKeys;

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

    // Use this for initialization
    void Start()
    {
        playerKeys = gameObject.GetComponent<PlayerInput>();
        prevPos = transform.position;
        pos = transform.position + transform.forward;

		trailColliders = GetComponent<TrailColliders>();
        trailRenderer = GetComponent<TrailRenderer>();
		
    }

    // Update is called once per frame
    void Update()
    {
		if (rotated)
		{
			if (Input.GetAxisRaw(playerKeys.rotateKey) == 0)
				rotated = false;
		}
		else
		{
			// Rotate Right
			if (Input.GetAxisRaw(playerKeys.rotateKey) > 0.5f && canTurn)
			{
				count++;
				transform.Rotate(0, 90, 0);
				rotated = true;
			}

			// Rotate Left
			if (Input.GetAxisRaw(playerKeys.rotateKey) < -0.5f && canTurn)
			{
				count++;
				transform.Rotate(0, -90, 0);
				rotated = true;
			}
		}

		
		// Jump
        if (Input.GetAxisRaw(playerKeys.jumpKey) > 0.5f)
        {
            if (!jumping)
            {
				canTurn = false;
                jumping = true;
                currentJumpSpace = 0;
                transform.position += transform.up;
                pos += transform.up;
            }            
        }

		// Tunnel
        if (Input.GetAxisRaw(playerKeys.tunnelKey) < -0.5f)
        {
            if (!tunneling)
            {
				canTurn = false;
                tunneling = true;
                currentTunnelSpace = 0;
                transform.position -= transform.up;
                pos -= transform.up;
            }
        }

		// Dodge Right
        if (Input.GetAxisRaw(playerKeys.dodgeRightKey) > 0)
        {
            if(!dodging)
            {
                dodging = true;
                transform.position += transform.right + transform.right;
                pos += transform.right + transform.right;            
            }
        }

		// Dodge Left
        if (Input.GetAxisRaw(playerKeys.dodgeLeftKey) > 0)
        {
            if(!dodging)
            {
                dodging = true;
                transform.position -= transform.right + transform.right;
                pos -= transform.right + transform.right;
            }
        }

		// Update Position 
		if (pos == transform.position)
		{
            trailRenderer.enabled = true;
            trailColliders.PlaceCollider(prevPos);
			prevPos = pos;

            if (pos.x >= 100)
            {
                pos.x = 0;
                transform.position = pos; 
                trailRenderer.enabled = false;
            }
            else if (pos.x <= 0)
            {
                pos.x = 100;
                transform.position = pos;
                trailRenderer.enabled = false;
            }

            if (pos.z >= 100)
            {
                pos.z = 0;
                transform.position = pos;
                trailRenderer.enabled = false;
            }
            else if (pos.z <= 0)
            {
                pos.z = 100;
                transform.position = pos;
                trailRenderer.enabled = false;
            }

			pos += transform.forward;


            //rotated = false;

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
				if (currentDodgeSpaces < maxDodgeCount)
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
