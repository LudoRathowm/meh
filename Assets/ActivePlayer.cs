using UnityEngine;
using System.Collections;

public class ActivePlayer : MonoBehaviour {
	public bool active;
	float distancecovered;
	float velocity;
	public float input;
	public float result;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		result = Mathf.Log(input)*1000;
		Debug.Log ("velocity "+rigidbody.velocity.sqrMagnitude);
		Debug.Log ("distance covered "+distancecovered);
		velocity = rigidbody.velocity.sqrMagnitude;
		if (velocity>0)
			distancecovered+=Time.deltaTime;


	}
}
