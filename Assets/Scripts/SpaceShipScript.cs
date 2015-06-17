using UnityEngine;
using System.Collections;

public class SpaceShipScript : MonoBehaviour {

	public float speed;
	public GameObject bullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("space")) {
			Instantiate(bullet, transform.position, Quaternion.identity);
		}
	}

	void FixedUpdate () {
		float VelocityFactor = speed * Time.deltaTime * 100;
		Vector2 ShipVelocity = new Vector2 (Input.GetAxis ("Horizontal") * VelocityFactor, 0);
		GetComponent<Rigidbody2D>().velocity = ShipVelocity;
	}
}
