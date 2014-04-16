using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public float Power = 200f;
	public float Velicity = 3f;
	// Use this for initialization
	public void Move (Vector3 direction, float ballSize) {
		float fwdVelocity = Velicity - (ballSize/6);Debug.Log (ballSize);
		Vector3 forceDirection = new Vector3(direction.x, direction.y, fwdVelocity) * Power;
		rigidbody.AddForce(forceDirection);
	}
}
