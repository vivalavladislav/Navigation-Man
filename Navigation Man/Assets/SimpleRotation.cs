using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotation : MonoBehaviour
{
	[SerializeField] float anglePerSecond;


	void Start () 
	{
		
	}
	

	void Update () 
	{
		float horizontalS = 0;
		if(Input.GetKey(KeyCode.D))	
			horizontalS = 1f;

		if(Input.GetKey(KeyCode.A))	
			horizontalS -= 1f;

		float verticalS = 0;
		if(Input.GetKey(KeyCode.W))	
			verticalS = -1f;

		if(Input.GetKey(KeyCode.S))	
			verticalS += 1f;

		//var euler = new Vector3( 0f, horizontalS * anglePerSecond, 0f) * Time.deltaTime;
		var euler = new Vector3( verticalS * anglePerSecond, horizontalS * anglePerSecond, 0f) * Time.deltaTime;

		//transform.Rotate(0, 
		//transform.rotation = transform.rotation * Quaternion.Euler( euler );
		//transform.Rotate(euler );
	}
}
