using UnityEngine;
using System.Collections;

public class RocketScript : MonoBehaviour {

	public float rocketSpeed;

	// Use this for initialization
	void Start () {
		Vector2 RocketVelocity = new Vector2 (0, rocketSpeed); 
		GetComponent<Rigidbody2D>().velocity = RocketVelocity;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnBecameInvisible() { 
		Destroy(gameObject, 5);
	}
}
