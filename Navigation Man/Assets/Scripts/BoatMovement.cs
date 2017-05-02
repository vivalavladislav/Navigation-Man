using UnityEngine;

public class BoatMovement : MonoBehaviour 
{
	[SerializeField] float velocity;
	[SerializeField] float angluarVelocity;
	public bool Moving = true;
	[SerializeField] Rigidbody target;
	[SerializeField] bool forwardVector = true;



	void Update () 
	{
		if(Moving || Input.GetKey(KeyCode.W))
			Move();

		var rotationSign = 0f;
		if(Input.GetKey(KeyCode.D))
			rotationSign += 1;
		if(Input.GetKey(KeyCode.A))
			rotationSign -= 1;

		if(Mathf.Abs(rotationSign) > Mathf.Epsilon)
			Rotate(rotationSign);
	}

	void Move()
	{
		Vector3 add = Vector3.zero;
		if(forwardVector)
			add += target.transform.forward * velocity;	
		else
			add += target.transform.right * velocity;

		add.y = target.velocity.y;
		target.velocity = add * Time.timeScale;
	}

	void Rotate(float sign)
	{
		target.angularVelocity = angluarVelocity / 180F * Mathf.PI * Vector3.up * sign * Time.timeScale; 
	}
}
