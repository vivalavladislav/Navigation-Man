using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class AutoScale : MonoBehaviour 
{
	public GameObject[] constellations;
	public Vector3 scale;

	public void Do()
	{
		foreach (GameObject con in constellations)
		{
			// child iteration, magic
			foreach(Transform star in con.transform) 
			{
				//MeshRenderer mr = star.gameObject.GetComponent<MeshRenderer>();
				//mr.material.color = Color.green;
				star.localScale = scale;
			}
		}
	}
}



[CustomEditor(typeof(AutoScale))]
public class AutoScaleEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		var t = target as AutoScale;
		if (GUILayout.Button("change scale"))
		{
			t.Do();
		}
	}
}


