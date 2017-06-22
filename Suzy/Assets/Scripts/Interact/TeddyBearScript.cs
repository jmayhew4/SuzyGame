using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddyBearScript: MonoBehaviour {
	AudioSource TeddyBearAudio;

	/* Audio Clips for Teddy Bear
	 * 0 - Default cute bear talk
	 * 1 - Freaky Satanic line
	 * 2 - Freaky Clue for game objective
	 * 3 - Cute line
	 */

	public AudioClip [] TeddyBearDialogue;
	int teddyAudioIndex;


	// From the inspector, add the player GameObject on this script's field
	public GameObject Camera;
	public GameObject Player;


	public int interactionDistance;
	public GameObject InteractionText;
	public string description;
	private bool isSatanic;


	// Use this for initialization
	void Start () {
		TeddyBearAudio = GetComponent<AudioSource> ();
		Camera = GameObject.FindGameObjectWithTag ("MainCamera");
		isSatanic = false;
	}

	// Update is called once per frame
	void Update () {

		if (teddyAudioIndex > 0)
			isSatanic = true;
		if (isSatanic) {
			// Add hellish effects please
		}

		if (Input.GetMouseButtonDown (0)) {

			//WHEN PLAYER HITS, USE RAYCASTING SCRIPT TO IDENTIFY JUMPSCARES
			if (Camera.GetComponent<PlayerRaycasting> ().whatIHit.collider.name == "TeddyBear"
			    && Camera.GetComponent<PlayerRaycasting> ().whatIHit.distance <= interactionDistance) {
				//TeddyBear Logic, Play Broadcast and continue no matter what

				//Alternate Sounds
				if (!TeddyBearAudio.isPlaying) {
						TeddyBearAudio.clip = TeddyBearDialogue [teddyAudioIndex];
					if (teddyAudioIndex < TeddyBearDialogue.Length - 1) {
						teddyAudioIndex++;
					}
					else {
						teddyAudioIndex = 0;
					}
					TeddyBearAudio.Play ();
					}
				}
			}

		//HIGHLIGHTING OBJECTS WHEN LOOKED AT SCRIPT
		if (Camera.GetComponent<PlayerRaycasting> ().didIHitAnything ()) {
			if (Camera.GetComponent<PlayerRaycasting> ().whatIHit.collider.name == "TeddyBear"
			    && Camera.GetComponent<PlayerRaycasting> ().whatIHit.distance <= interactionDistance) {


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
			}
		} else {
		}
	}
}

