using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimeController : MonoBehaviour 
{
	[SerializeField] float rewindCoef;
	[SerializeField] AnimationCurve timeCurve;
	[SerializeField] float animTime;
	[SerializeField] AnimationCurve revertCurve;
	[SerializeField] float revertTime;

	float startedTime = -1f;
	float endedTime = -1f;

	void Update () 
	{
		if (Input.GetKey(KeyCode.E))
		{
			UpdateFastForward();
		}
		else
		{
			UpdateNormal();
		}
	}

	void UpdateFastForward()
	{
		endedTime = -1f;
		if (startedTime < 0)
		{
			startedTime = Time.time;
			Time.timeScale = 1f;
			return;
		}

		if ((Time.time - startedTime) < animTime)
		{
			var lerpCoef = timeCurve.Evaluate((Time.time - startedTime) / animTime);
			Time.timeScale = Mathf.Lerp(1f, rewindCoef, lerpCoef);
			return;
		}

		Time.timeScale = rewindCoef;
	}

	void UpdateNormal()
	{
		startedTime = -1f;
		if (endedTime < 0)
		{
			endedTime = Time.time;
			Time.timeScale = rewindCoef;
			return;
		}

		if ((Time.time - endedTime) < revertTime)
		{
			var lerpCoef = revertCurve.Evaluate((Time.time - endedTime) / revertTime);
			Time.timeScale = Mathf.Lerp(rewindCoef, 1f, lerpCoef);
			return;
		}

		Time.timeScale = 1f;
	}

}
