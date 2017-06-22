using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MirrorScareTrigger : MonoBehaviour {

	public GameObject Skeleton;
	public bool played = false;
	public bool trig = false;
	public AudioClip laugh;
	AudioSource soundController;

	// Use this for initialization
	void Start () {
		soundController = GetComponent<AudioSource>();
		played = false;
		Skeleton.GetComponent<Renderer>().enabled = false;
	}

	void OnTriggerEnter(Collider other){
		if(played == false){
			soundController.PlayOneShot(laugh, 1f); 
		}
		trig = true;
		played = true;

	}
	
	// Update is called once per frame
	void Update () {
		if(trig == true && played == true){
			Skeleton.GetComponent<Renderer>().enabled = true;
			StartCoroutine (DespawnModel());
		}
	}

     IEnumerator DespawnModel()
	{
	    while (true) {
	        yield return new WaitForSeconds(1.7f);
	        Skeleton.GetComponent<Renderer>().enabled = false;
	    }
	}

}
