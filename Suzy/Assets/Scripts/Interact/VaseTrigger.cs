using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseTrigger : MonoBehaviour {

	public GameObject vase;
	public GameObject vaseNumber;
	public float speed;
	// Candle Flame setup
	public GameObject candleFlame;
	public GameObject candleLight;



	void Start () {
		vase.GetComponent<Rigidbody> ().velocity = vase.transform.forward * speed;
		vase.GetComponent<Rigidbody> ().AddForce (transform.forward * speed, ForceMode.Impulse);

	}
		

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			vase.gameObject.SetActive (true);
			vaseNumber.gameObject.SetActive (true);
			StartCoroutine (removeVaseNum ());
			// Candle Light/Flame color change
			//candleFlame.GetComponent<ParticleSystem>().startColor = new Color(1, 0, 1, .5f);
			//candleLight.GetComponent<Light>().color = new Color(1, 0, 1, .5f);

			// TODO: Destroy the vase after xxx seconds OR CHANGE IT INTO BROKEN CLASS
			Destroy (vase, 4.0f);
			this.gameObject.SetActive (false);
			Destroy (this, 4.0f);

		}
	}
	IEnumerator removeVaseNum() {
		vaseNumber.transform.parent = null;
		yield return new WaitForSeconds (1.0f);
	}


}
