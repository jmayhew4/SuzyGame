using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radioPlay : MonoBehaviour {
	AudioSource radioAudio;

	// From the inspector, add the player GameObject on this script's field
	public GameObject Camera;
	public GameObject Player;

	public AudioClip uiClick; 

	public int interactionDistance;
	public GameObject InteractionText;
	public string description;

	// Use this for initialization
	void Start () {
		radioAudio = GetComponent<AudioSource> ();
		Camera = GameObject.FindGameObjectWithTag ("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown(0)) {

			 //WHEN PLAYER HITS, USE RAYCASTING SCRIPT TO IDENTIFY JUMPSCARES
			if (Camera.GetComponent<PlayerRaycasting> ().whatIHit.collider.name == "Radio"
				&& Camera.GetComponent<PlayerRaycasting> ().whatIHit.distance <= interactionDistance) {
				//Radio Logic, Play Broadcast and continue no matter what

				//UI Click Noise
				Player.GetComponent<AudioSource>().clip = uiClick;
				Player.GetComponent<AudioSource> ().Play ();

				if (!radioAudio.isPlaying) {
					radioAudio.Play ();

				} else {
					if (radioAudio.volume > 0)
						radioAudio.volume = 0;
					else
						radioAudio.volume = 1;
				}
			}
		} 
			
		//HIGHLIGHTING OBJECTS WHEN LOOKED AT SCRIPT
		if (Camera.GetComponent<PlayerRaycasting> ().didIHitAnything()) {
			//Debug.Log ("I hit a " + Camera.GetComponent<PlayerRaycasting> ().whatIHit);

			if (Camera.GetComponent<PlayerRaycasting> ().whatIHit.collider.name == "Radio"
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
		}
	}
}
