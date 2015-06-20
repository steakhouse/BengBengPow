using UnityEngine;
using System.Collections;
using SpaceShip;

public class enemyScript : MonoBehaviour {

	public float speed = -5;
	public GameObject explosion;
	public GameObject explosion_rocket;
	private SpaceShipScript Playership;

	// Use this for initialization
	void Start () {
		//Spawnt Enemy
		Vector2 EnemyVelocity = new Vector2 (0, speed); 
		GetComponent<Rigidbody2D>().velocity = EnemyVelocity;
		GetComponent<Rigidbody2D> ().angularVelocity = Random.Range (-200, 200);
		Destroy(gameObject, 5);

		//Spieler finden
		Playership = GameObject.Find ("spaceship").GetComponent<SpaceShipScript> ();
	}
	 
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		//print ("Kollision mit Objekt " + other.gameObject.name.ToString());

		//Name des kollidierenden Objekts (Ey ALTER WER HAT MISCH DA ANGEFICKT!?)
		string name = other.gameObject.name;

		if (name == "bullet(Clone)") {
			Destroy(gameObject);
			Destroy(other.gameObject);
			Instantiate(explosion, transform.position, Quaternion.identity);
			Playership.score += 10;
		}

		if (name == "spaceship") {
			Destroy(gameObject);
			Instantiate(explosion, transform.position, Quaternion.identity);
			if(Playership.ShieldReady){
				Playership.PlayerHealth -= 10;
			}
		}

		if (name == "rocket(Clone)") {
			Destroy(gameObject);
			Destroy(other.gameObject);
			Instantiate(explosion_rocket, transform.position, Quaternion.identity);
			Playership.score += 30;
		}

	}
}
