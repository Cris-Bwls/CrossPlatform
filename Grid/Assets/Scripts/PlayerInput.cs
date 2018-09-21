/* 
 Authors-
Chris
Paul
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	public int playerNumber = 1;

	[HideInInspector]	
	public string rotateKey = "Horizontal";
	[HideInInspector]
	public string jumpKey = "Jump";
	[HideInInspector]
	public string tunnelKey = "Tunnel";
	[HideInInspector]
	public string dodgeLeftKey = "DodgeLeft";
	[HideInInspector]
	public string dodgeRightKey = "DodgeRight";

	private void Awake()
	{

		// Add Player number to key string
		rotateKey += playerNumber.ToString();
		jumpKey += playerNumber.ToString();
		tunnelKey += playerNumber.ToString();
		dodgeLeftKey += playerNumber.ToString();
		dodgeRightKey += playerNumber.ToString();
	}
}
