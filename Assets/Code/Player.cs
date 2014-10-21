using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public GameObject Ball;
	public GameObject Indicator;
	public int Speed = 5;
	public float StartSize = 1f;
	public float GrowSpeed = 2f;
	public int PlayerNum = 1;

	private float ballSize = 1f;
	private Vector3 startPos;
	private Vector3 endPos;
	private GameObject gameIndicator;

	private string shoot;
	public int playerSign;

	public bool Yelling = false;
	public bool WasYelling = false;
	void Start ()
	{
		gameIndicator = (GameObject)Instantiate (Indicator, transform.position, transform.rotation) as GameObject;
	}

	// Update is called once per frame
	void Update () {
		//Control Spawner
		float xMove = 0;
		float yMove = 0;
	
		if (PlayerNum == 1) {
			xMove = Input.GetAxis ("Horizontal");
			yMove = Input.GetAxis ("Vertical");
			shoot = "Fire1";
			playerSign = 1;

		} else{
			xMove = Input.GetAxis ("HorizontalP2");
			yMove = Input.GetAxis ("VerticalP2");
			shoot = "Fire2";
			playerSign = -1;

		}
		Vector3 movement = new Vector3 (xMove * Speed, yMove * Speed, 0);
		transform.Translate	(movement * Time.deltaTime);
		UpdateIndicator ();
		shooting ();
	}

	void UpdateIndicator () 
	{
		gameIndicator.transform.localScale = new Vector3 (ballSize, ballSize, ballSize);
		gameIndicator.transform.position = transform.position;

	}

	void shooting() {
		//Get start angle Position
		if (Input.GetButtonDown (shoot) || Yelling) {
			if(Yelling && !WasYelling){
				WasYelling = true;
			}
				//Set Start
				startPos = transform.localPosition;
				gameIndicator.renderer.enabled = true;
				
			}
		//Shoot Ball	
		if(Input.GetButtonUp (shoot) || !Yelling && WasYelling)
			{
			WasYelling = false;
				gameIndicator.renderer.enabled = false;
				//Shoot angle
				endPos = transform.localPosition;
				
				
				Vector3 forceDirection = endPos - startPos;
				
				//Set Z
				forceDirection.z = playerSign;
				Debug.Log (endPos.x);
				Ball.transform.rotation = Quaternion.LookRotation(endPos);
				
				
				//Ball scale
				Ball.transform.localScale = new Vector3( ballSize , ballSize , ballSize );
				GameObject instance = (GameObject)Instantiate (Ball, transform.position, transform.rotation) as GameObject;
				instance.GetComponent<Ball>().Move(forceDirection , ballSize ,PlayerNum);
				
				//Set Mass
				instance.GetComponent<Rigidbody>().mass = ballSize;
				
				//Rest ball size
				ballSize = StartSize;
				
			}
			//Charging 
			if (Input.GetButton (shoot) || Yelling) 
			{	
				ballSize += GrowSpeed * Time.deltaTime;
				
				UpdateIndicator();
			}
		}


}
