using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public float Power = 200f;
	public float Velicity = 3f;
	public Material Player1Mat;
	public Material Player2Mat;

	private float ballSize;

	public float BallSize {
		get {
			return ballSize;
		}
	}
	private int playerNumber = 0;
	// Use this for initialization
	public void Move (Vector3 direction, float theBallSize,int playerNum) {
		ballSize = theBallSize;
		playerNumber = playerNum;
		float fwdVelocity = Velicity - (ballSize/6);
		Vector3 forceDirection = new Vector3(direction.x, direction.y, fwdVelocity *direction.z) * Power;
		rigidbody.AddForce(forceDirection);
		setMaterial();
	}

	private void Update()
	{
		RemoveMe ();
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
	public void BallHit(Collider otherBall)
	{
	float otherBallSize = otherBall.transform.parent.GetComponent<Ball>().BallSize;
		Debug.Log ("otherBall " + ballSize +" myBll " + otherBallSize);
		//ballSize -= otherBallSize;
		float newSize =0;
		if(ballSize > otherBallSize) {
			newSize -= otherBallSize;
		}else {
			newSize = 0;
		}
		//updateBallSize(newSize);
		LerpScale (2.0f ,newSize);
	}

	private void updateBallSize(float newSize){
		//Vector3 startSize = new Vector3( ballSize , ballSize , ballSize );
		//Vector3 endSize = new Vector3( newSize , newSize , newSize );

		transform.localScale = new Vector3( ballSize , ballSize , ballSize );
	}

	private void LerpScale(float time, float newSize)
	{
		Vector3 startSize = new Vector3( ballSize , ballSize , ballSize );
		Vector3 endSize = new Vector3( newSize , newSize , newSize );
		float startTime = time;

		while (time > 0.0f)
		{
			time -= Time.deltaTime;

			transform.localScale = Vector3.Lerp (endSize, startSize , time/startTime);

		}
	}
	
}
