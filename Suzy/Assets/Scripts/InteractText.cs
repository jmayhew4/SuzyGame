using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractText : MonoBehaviour {

	public Text displayText;

	// Use this for initialization
	void Start () {
		//ResourceLoad - Custom Font
		displayText.font = Resources.Load ("Fonts/BebasNeue Regular", typeof(Font)) as Font;


		displayText = GetComponent<Text> ();
	}

	public void setText(string text) {
		displayText.text = text;
		return;
	}
		
}
