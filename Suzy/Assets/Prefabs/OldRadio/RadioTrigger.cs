using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioTrigger : MonoBehaviour {

	public GameObject radio;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			//Play Radio if it's not already playing

			if (!radio.GetComponent<AudioSource>().isPlaying) {
				//PLAY JUMPSCARE INDICATION, SUBTLE
				this.GetComponent<AudioSource>().Play();
				radio.GetComponent<AudioSource> ().Play ();
			}
			Destroy (this.gameObject);
		}
	}

}
