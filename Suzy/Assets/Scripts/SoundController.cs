using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

	private AudioSource audioSource;
	public AudioClip flashlightClick;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void PlayFlashlightClick () {
        audioSource.PlayOneShot(flashlightClick, 0.55f);
    }
}