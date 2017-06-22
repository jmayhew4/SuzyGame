using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public class StrangerMove : MonoBehaviour {

	public Transform startMarker;
    public Transform goal;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;
    public bool isMoving = false;

	// Use this for initialization
	void Start () {
		
		startMarker = this.transform;

	}
	
	// Update is called once per frame
	void Update () {
		if(isMoving){
			float distCovered = (Time.time - startTime) * speed;
        	float fracJourney = distCovered / journeyLength;
        	transform.position = Vector3.Lerp(startMarker.position, goal.position, fracJourney);
		}

	}
	public void StartMoving() {
		//this.GetComponent<NavMeshAgent>().destination = goal.position;
		startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, goal.position);
        isMoving = true;
	}
}
