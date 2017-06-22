using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseShatter : MonoBehaviour {

	public AudioClip vaseShatter;
	private bool isBroken;

	// Use this for initialization
	void Start () {
		isBroken = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col) {
		if (!isBroken) {
			//TODO: Create actual vase model, now broken

			this.GetComponent<AudioSource> ().clip = vaseShatter;
			this.GetComponent<AudioSource> ().spatialBlend = 1; //Switch from Jumpscare's universal playback to 3D playback of object
			this.GetComponent<AudioSource> ().Play();
			isBroken = true;
		}
	}


}
