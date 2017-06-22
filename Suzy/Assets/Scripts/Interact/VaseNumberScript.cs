﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseNumberScript: MonoBehaviour {


	// From the inspector, add the player GameObject on this script's field
	public GameObject Camera;
	public GameObject Player;

	public float speed;

	public int interactionDistance;
	public GameObject InteractionText;
	public string description;

	bool lookedAt = false;

	// Use this for initialization
	void Start () {
		Camera = GameObject.FindGameObjectWithTag ("MainCamera");
		this.GetComponent<Rigidbody> ().velocity = this.transform.forward * speed;
		this.GetComponent<Rigidbody> ().AddForce (transform.forward * speed, ForceMode.Impulse);
	}

	// Update is called once per frame
	void Update () {

		//HIGHLIGHTING OBJECTS WHEN LOOKED AT SCRIPT
		if (Camera.GetComponent<PlayerRaycasting> ().didIHitAnything ()) {
			if (Camera.GetComponent<PlayerRaycasting> ().whatIHit.collider.name == "VaseNumber"
				&& Camera.GetComponent<PlayerRaycasting> ().whatIHit.distance <= interactionDistance) {

				//ADD IT TO THE NUMBER COUNTING SYSTEM
				Debug.Log("You found the Vase");
				lookedAt = true;

				//HIGHLIGHT OBJECT
				GetComponent<MeshRenderer> ().material.shader = Shader.Find ("Self-Illumin/Outlined Diffuse");

				//Interact with Text Script
				InteractionText.SetActive (true);
				InteractionText.GetComponent<InteractText> ().setText (description);

			} else {
				//UNHIGHLIGHT OBJECT
				GetComponent<MeshRenderer> ().material.shader = Shader.Find ("Diffuse");

				if (InteractionText.GetComponent<InteractText> ().displayText.text == description)
					InteractionText.GetComponent<InteractText> ().setText ("");

				//REMOVING TO MAKE GAME EASIER
				//if (lookedAt)
				//	Destroy (this.gameObject, 3f);
			}
		} else {
		}
	}
}

