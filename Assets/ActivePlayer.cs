using UnityEngine;
using System.Collections;

public class ActivePlayer : MonoBehaviour {
	public bool active;
	float distancecovered;
	float velocity;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("velocity "+rigidbody.velocity.sqrMagnitude);
		Debug.Log ("distance covered "+distancecovered);
		velocity = rigidbody.velocity.sqrMagnitude;
		if (velocity>0)
			distancecovered+=Time.deltaTime;
		if (distancecovered>8)
			Debug.LogError("NN");
	}
}
