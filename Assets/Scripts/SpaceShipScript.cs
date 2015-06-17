using UnityEngine;
using System.Collections;


namespace SpaceShip{
	public class SpaceShipScript : MonoBehaviour {

		public float speed;
		public GameObject bullet;
		public GameObject rocket;

		public float PlayerHealth = 100;

		private bool RocketReady = true;
		public GameObject RocketUI;
		public int RocketTimeout;

		// Use this for initialization
		void Start () {
			//GetComponent<SpriteRenderer>().color = new Color (1f, 1f, 1f, 0.5f);
		}
		
		// Update is called once per frame
		void Update () {

			if (Input.GetKeyDown ("space")) {
				Instantiate(bullet, transform.position, Quaternion.identity);
			}

			if (Input.GetKeyDown ("1")) {
				if(RocketReady){
					Instantiate(rocket, transform.position, Quaternion.identity);
					RocketReady = false;
					RocketUI.GetComponent<SpriteRenderer>().color = new Color (1f, 1f, 1f, 0.3f);
					InvokeRepeating("EnableRocket", RocketTimeout, 0);
				}
			}
		}

		void FixedUpdate () {
			float VelocityFactor = speed * Time.deltaTime * 100;
			Vector2 ShipVelocity = new Vector2 (Input.GetAxis ("Horizontal") * VelocityFactor, 0);
			GetComponent<Rigidbody2D>().velocity = ShipVelocity;
		}

		void EnableRocket(){
			this.RocketReady = true;
			RocketUI.GetComponent<SpriteRenderer>().color = new Color (1f, 1f, 1f, 1f);
		}
	}
}
