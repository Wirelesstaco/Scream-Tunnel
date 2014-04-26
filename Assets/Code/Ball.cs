using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public float Power = 200f;
	public float Velicity = 3f;
	// Use this for initialization
	public void Move (Vector3 direction, float ballSize) {
		float fwdVelocity = Velicity - (ballSize/6);
		Vector3 forceDirection = new Vector3(direction.x, direction.y, fwdVelocity) * Power;
		rigidbody.AddForce(forceDirection);
	}
	private void RemoveMe(){
		Debug.Log ("X " + transform.position.x + " Y " + transform.position.y + " Z" + transform.position.z);

		if (transform.position.x > 20 || transform.position.x < -20 || transform.position.y > 20 || transform.position.y < -10 || transform.position.z > 30 || transform.position.z < -30) {

			Destroy (this.gameObject);
		}
	}

	private void Update()
	{
		RemoveMe ();
	}
}
