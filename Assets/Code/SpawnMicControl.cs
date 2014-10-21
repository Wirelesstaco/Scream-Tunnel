using UnityEngine;
using System.Collections;

public class SpawnMicControl : MonoBehaviour {

	MicControlC micC;
	public GameObject MicController;//microphone tracker. 
	public float roomNoise = 3;
	public float noiseVolume;
	void Start () {
		//micC.micControl = Co
		//micC = gameObject.GetComponent("MicControl") as GameObject;
		micC = MicController.GetComponent<MicControlC>() as MicControlC;
	}
	void Update () {
		noiseVolume = micC.loudness;
		if (noiseVolume < roomNoise) {
			noiseVolume = 0;	
			gameObject.GetComponent<Player> ().Yelling = false;
		}else {
			gameObject.GetComponent<Player> ().Yelling = true;
			}
		//transform.localScale = new Vector3 (1, noiseVolume, 1);

	}
}
