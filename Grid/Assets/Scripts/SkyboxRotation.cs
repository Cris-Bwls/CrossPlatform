﻿/* 
 Authors-
	Josh
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotation : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		RenderSettings.skybox.SetFloat("_Rotation", Time.time * 10);
	}
}
