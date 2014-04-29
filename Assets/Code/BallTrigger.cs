using UnityEngine;
using System.Collections;

public class BallTrigger : MonoBehaviour {

	//Fire event when other ball has been hit.
	void OnTriggerEnter(Collider other) 
	{
		transform.parent.GetComponent<Ball>().BallHit(other);
	}
}
