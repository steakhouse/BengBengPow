using UnityEngine;
using System.Collections;
using SpaceShip;

public class enemyScript : MonoBehaviour {

	public float speed = -5;
	public GameObject explosion;
	public GameObject explosion_rocket;
	public GameObject Playership;

	// Use this for initialization
	void Start () {
		Vector2 EnemyVelocity = new Vector2 (0, speed); 
		GetComponent<Rigidbody2D>().velocity = EnemyVelocity;
		GetComponent<Rigidbody2D> ().angularVelocity = Random.Range (-200, 200);
		Destroy(gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		print ("Kollision mit Objekt " + other.gameObject.name.ToString());

		//Name des kollidierenden Objekts (Ey ALTER WER HAT MISCH DA ANGEFICKT!?)
		string name = other.gameObject.name;

		if (name == "bullet(Clone)") {
			Destroy(gameObject);
			Destroy(other.gameObject);
			Instantiate(explosion, transform.position, Quaternion.identity);
		}

		if (name == "spaceship") {
			Destroy(gameObject);
			Instantiate(explosion, transform.position, Quaternion.identity);
			SpaceShip.SpaceShipScript local = Playership.GetComponent<SpaceShip.SpaceShipScript>();
			local.PlayerHealth -= 20;
			print (local.PlayerHealth);
		}

		if (name == "rocket(Clone)") {
			Destroy(gameObject);
			Destroy(other.gameObject);
			Instantiate(explosion_rocket, transform.position, Quaternion.identity);
		}

	}
}
