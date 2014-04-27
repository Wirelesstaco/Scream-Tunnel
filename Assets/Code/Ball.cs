using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public float Power = 200f;
	public float Velicity = 3f;
	public Material Player1Mat;
	public Material Player2Mat;

	private int playerNumber = 0;
	// Use this for initialization
	public void Move (Vector3 direction, float ballSize,int playerNum) {
		playerNumber = playerNum;
		float fwdVelocity = Velicity - (ballSize/6);
		Vector3 forceDirection = new Vector3(direction.x, direction.y, fwdVelocity *direction.z) * Power;
		rigidbody.AddForce(forceDirection);
		setMaterial();
	}

	private void setMaterial() 
	{
		if(playerNumber == 1){
			renderer.material = Player1Mat;
		}else if(playerNumber == 2){
			renderer.material = Player2Mat;
		}
	}
	private void RemoveMe(){

		if (transform.position.x > 20 || transform.position.x < -20 || transform.position.y > 20 || transform.position.y < -10 || transform.position.z > 30 || transform.position.z < -30) {

			Destroy (this.gameObject);
		}
	}

	private void Update()
	{
		RemoveMe ();
	}

	private void OnCollisionEnter(){
		Debug.Log ("hit");
		//disable physic collisions
		//collider.isTrigger = true;
	}
}
