using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookScript: MonoBehaviour {


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
		description = "I have not Forgiven this Pair. I devote my pain to three,\n and give no mercy til I am but one remaining\n";
	}

	// Update is called once per frame
	void Update () {

		//HIGHLIGHTING OBJECTS WHEN LOOKED AT SCRIPT
		if (Camera.GetComponent<PlayerRaycasting> ().didIHitAnything ()) {
			if (Camera.GetComponent<PlayerRaycasting> ().whatIHit.collider.name == "Book"
				&& Camera.GetComponent<PlayerRaycasting> ().whatIHit.distance <= interactionDistance) {

				//HIGHLIGHT OBJECT
				GetComponent<MeshRenderer> ().material.shader = Shader.Find ("Self-Illumin/Outlined Diffuse");

				//Interact with Text Script
				InteractionText.SetActive (true);
				InteractionText.GetComponent<InteractText> ().setText (description);

				if (!lookedAt) {
					//ADD IT TO THE NUMBER COUNTING SYSTEM
					Debug.Log ("You found the Diary");
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

