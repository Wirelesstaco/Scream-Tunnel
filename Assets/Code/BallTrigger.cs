using UnityEngine;
using System.Collections;

public class BallTrigger : MonoBehaviour {


	void OnTriggerEnter() 
	{


		transform.parent.GetComponent<Ball>().test();
	}
}
