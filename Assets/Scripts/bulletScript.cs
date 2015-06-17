using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {

	public float bulletSpeed;

	// Use this for initialization
	void Start () {
		Vector2 BulletVelocity = new Vector2 (0, bulletSpeed); 
		GetComponent<Rigidbody2D>().velocity = BulletVelocity;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnBecameInvisible() { 
		Destroy(gameObject);
	}
}
