using UnityEngine;
 using System.Collections;
 
 public class Flashlight : MonoBehaviour {
 
    public Light light;    //assign gameobject with light component attached
    public Light lightglow;
 	public AudioClip click;
 	AudioSource soundController;

 	void Start() {
 		soundController = GetComponent<AudioSource>();
 	}

	void Update () {
	 	if (Input.GetMouseButtonDown (1)) {      //Left mouse button
	     	light.enabled = !light.enabled;      //changes light on/off
	     	lightglow.enabled = !lightglow.enabled;
			soundController.PlayOneShot(click, 1f);
		}
	}
 }