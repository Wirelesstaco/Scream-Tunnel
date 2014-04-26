using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	public GameObject Ball;
	public GameObject Indicator;
	public int Speed = 5;
	public float StartSize = 1f;
	public float GrowSpeed = 2f;
	public int Player = 1;

	private float ballSize = 1f;
	private Vector3 startPos;
	private Vector3 endPos;
	private GameObject gameIndicator;


	void Start ()
	{
		gameIndicator = (GameObject)Instantiate (Indicator, transform.position, transform.rotation) as GameObject;
	}

	// Update is called once per frame
	void Update () {
		//Control Spawner
		float xMove = 0;
		float yMove = 0;
		int direction = 1;
		if (Player == 1) {
			xMove = Input.GetAxis ("Horizontal");
			yMove = Input.GetAxis ("Vertical");

		} else{
			xMove = Input.GetAxis ("HorizontalP2");
			yMove = Input.GetAxis ("VerticalP2");

		}
		Vector3 movement = new Vector3 (xMove * Speed, yMove * Speed, 0);
		transform.Translate	(movement * Time.deltaTime);
		UpdateIndicator ();

		if (Input.GetButtonDown ("Jump")) {
			//Set Start
			startPos = transform.position;
			gameIndicator.renderer.enabled = true;
		}

		if(Input.GetButtonUp ("Jump"))
		{
			gameIndicator.renderer.enabled = false;
			//Shoot angle
			endPos = transform.position;

			Vector3 forceDirection = endPos - startPos;
			Debug.Log (forceDirection);

			Ball.transform.rotation = Quaternion.LookRotation(endPos);


			//Ball scale
			Ball.transform.localScale = new Vector3( ballSize , ballSize , ballSize );
			GameObject instance = (GameObject)Instantiate (Ball, transform.position, transform.rotation) as GameObject;
			instance.GetComponent<Ball>().Move(forceDirection , ballSize);

			//Set Mass
			instance.GetComponent<Rigidbody>().mass = ballSize;

			//Rest ball size
			ballSize = StartSize;

		}

		if (Input.GetButton ("Jump")) 
		{	
			ballSize += GrowSpeed * Time.deltaTime;

			UpdateIndicator();
		}
	}

	void UpdateIndicator () 
	{
		gameIndicator.transform.localScale = new Vector3 (ballSize, ballSize, ballSize);
		gameIndicator.transform.position = transform.position;

	}
}
