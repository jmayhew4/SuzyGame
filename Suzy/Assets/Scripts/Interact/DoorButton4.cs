using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton4 : MonoBehaviour {

	public GameObject DoorKeypad;

	bool pushed = false;
	// From the inspector, add the player GameObject on this script's field
	public GameObject Camera;
	public GameObject Player;


	public int interactionDistance;
	public GameObject InteractionText;
	public string description;

	// Use this for initialization
	void Start () {
		Camera = GameObject.FindGameObjectWithTag ("MainCamera");	
	}

	// Update is called once per frame
	void Update () {


		if (Input.GetMouseButtonDown (0)) {

			//WHEN PLAYER HITS, USE RAYCASTING SCRIPT TO IDENTIFY JUMPSCARES
			if (Camera.GetComponent<PlayerRaycasting> ().whatIHit.collider.name == "Button4"
				&& Camera.GetComponent<PlayerRaycasting> ().whatIHit.distance <= interactionDistance) {
				//Button Logic
				if (!pushed) {
					DoorKeypad.GetComponent<DoorPasswordScript> ().enterNumber (4);
					this.GetComponent<AudioSource> ().Play ();
					pushed = true;
				}
			}
		}

		//HIGHLIGHTING OBJECTS WHEN LOOKED AT SCRIPT
		if (Camera.GetComponent<PlayerRaycasting> ().didIHitAnything ()) {
			if (Camera.GetComponent<PlayerRaycasting> ().whatIHit.collider.name == "Button4"
				&& Camera.GetComponent<PlayerRaycasting> ().whatIHit.distance <= interactionDistance) {


				//HIGHLIGHT OBJECT
				GetComponent<MeshRenderer> ().material.shader = Shader.Find ("Self-Illumin/Outlined Diffuse");

				//Interact with Text Script
				InteractionText.SetActive (true);
				InteractionText.GetComponent<InteractText> ().setText (description);

			} else {
				//UNHIGHLIGHT OBJECT
				GetComponent<MeshRenderer> ().material.shader = Shader.Find ("Diffuse");
				pushed = false;
				if (InteractionText.GetComponent<InteractText> ().displayText.text == description)
					InteractionText.GetComponent<InteractText> ().setText ("");
			}
		} 
	}
}
