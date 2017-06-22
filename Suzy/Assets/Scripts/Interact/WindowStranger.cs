using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowStranger : MonoBehaviour {

	public GameObject stranger;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			//Play Radio if it's not already playing
			this.GetComponent<AudioSource>().Play();
			stranger.GetComponent<StrangerMove> ().StartMoving ();
			Destroy (this.gameObject, 4.0f);
		}
	}
}
