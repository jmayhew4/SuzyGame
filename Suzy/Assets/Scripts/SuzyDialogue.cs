using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuzyDialogue : MonoBehaviour {

	public AudioClip[] clips;
	public float timeLeft = 10.0f;
	int clipPick = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if(timeLeft < 0)
		{
			playClip ();
			timeLeft = 10.0f;
		}
	}

	public void playClip() 
	{
		if (clipPick < clips.Length) {
			GetComponent<AudioSource> ().clip = clips [clipPick];
			GetComponent<AudioSource> ().Play ();
			clipPick++;
		} else {
			clipPick = 0;
		}
	}
}
