using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThomasNum: MonoBehaviour {


	// From the inspector, add the player GameObject on this script's field
	public GameObject Camera;
	public GameObject Player;


	public int interactionDistance;
	public GameObject InteractionText;
	public string description;

	bool lookedAt = false;

	// Use this for initialization
	void Start () {
		Camera = GameObject.FindGameObjectWithTag ("MainCamera");
	}

	// Update is called once per frame
	void Update () {

		//HIGHLIGHTING OBJECTS WHEN LOOKED AT SCRIPT
		if (Camera.GetComponent<PlayerRaycasting> ().didIHitAnything ()) {
			if (Camera.GetComponent<PlayerRaycasting> ().whatIHit.collider.name == "ThomasNum"
				&& Camera.GetComponent<PlayerRaycasting> ().whatIHit.distance <= interactionDistance) {

				//HIGHLIGHT OBJECT
				GetComponent<MeshRenderer> ().material.shader = Shader.Find ("Self-Illumin/Outlined Diffuse");

				//Interact with Text Script
				InteractionText.SetActive (true);
				InteractionText.GetComponent<InteractText> ().setText (description);

				if (!lookedAt) {
					//ADD IT TO THE NUMBER COUNTING SYSTEM
					Debug.Log ("You found the Thomas Number");
					lookedAt = true;
				}

			} else {
				//UNHIGHLIGHT OBJECT
				GetComponent<MeshRenderer> ().material.shader = Shader.Find ("Diffuse");

				if (InteractionText.GetComponent<InteractText> ().displayText.text == description)
					InteractionText.GetComponent<InteractText> ().setText ("");
			}
		} else {
		}
	}
}

