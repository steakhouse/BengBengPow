using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace SpaceShip{
	public class SpaceShipScript : MonoBehaviour {

		//Spielerschiff-Eigenschaften
		public int score = 0;
		public float speed;					//Geschwindigkeit Spielerschiff
		public float energy = 100;			//Aktuelle Schiffsenergie
		public float energy_rate = 5.5f;	//Wiederherstellungsrate der Energy

		public GameObject bullet;			//Normaler Schuss
		public GameObject rocket;			//Rakete

		public float PlayerHealth = 100;	//Aktuelle Spielerhülle
		private bool t_gameover = false;	//Gameover?

		//Waffen-Eigenschaften [Rakete]
		private bool RocketReady = true;
		public int RocketTimeout;

		//Schild-Eigenschaften
		public bool ShieldReady = true;	//Schild wieder bereit?
		public int ShieldTimeout;			//SchildTimeout
		public GameObject ShieldCom;		//GameObject Shield

		//UI Elemente
		public GameObject RocketUI;			//Rakete auf Bildschirm
		public GameObject ShieldUI;			//Schild auf Bildschirm
		public GameObject HealthBar;		//Lebensanzeige bzw. Schiffs-Schilde
		public GameObject EnergyBar;		//Energie-Bar für aktuellen Energie-Stand
		public GameObject ScoreText;		//Highscore-Anzeige
		public GameObject GameOverScreen;	//Gameover-Screen


		// Use this for initialization
		void Start () {
			//Aktiviert Co-Routine für die Energie-Bar
			InvokeRepeating ("EnergyUpdate", 1.0f, 1.0f);
		}
		
		// Tastenabfrage / sonstige Dinge die PRO Frame laufen
		void Update () {

			if (Input.GetKeyDown ("space")) {
				if(energy - 5 > 0){
					Instantiate(bullet, transform.position, Quaternion.identity);
					energy -= 5;
				}
			}

			if (Input.GetKeyDown ("1")) {
				if(RocketReady && energy - 20 > 0){	
					Instantiate(rocket, transform.position, Quaternion.identity);			//Rakete spawnen
					RocketReady = false;													//Weitere Raketen deaktivieren
					energy -= 20;															//Schuss verbraucht Energie
					RocketUI.GetComponent<Image>().color = new Color (1f, 1f, 1f, 0.3f);	//Schuss-UI transparent machen
					RocketUI.GetComponent<Image>().fillAmount = 0.01f;						//Kreis-Runde Darstellung Raketen-Icon
					InvokeRepeating("EnableRocket", RocketTimeout, 0);						//Co-Routine starten
				}
			}

			if (Input.GetKeyDown ("2")) {
				if(ShieldReady && energy - 40 > 0){
					ShieldReady = false;
					energy -= 40;
					ShieldCom.SetActive(true);

					ShieldUI.GetComponent<Image>().color = new Color (1f, 1f, 1f, 0.3f);	//Schild-UI transparent machen
					ShieldUI.GetComponent<Image>().fillAmount = 0.01f;						//Kreis-Runde Darstellung Schild-Icon
					InvokeRepeating("EnableShield", ShieldTimeout, 0);						//Co-Routine starten
				}
			}

			AnimateRocketBar ();
			AnimiateShieldBar ();
			ShieldUpdate ();
			ScoreUpdate ();
		}

		//Schiffsteuerung
		void FixedUpdate () {
			float VelocityFactor = speed * Time.deltaTime * 100;
			Vector2 ShipVelocity = new Vector2 (Input.GetAxis ("Horizontal") * VelocityFactor, 0);
			GetComponent<Rigidbody2D>().velocity = ShipVelocity;
		}

		//RaktenCooldown
		void EnableRocket(){
			this.RocketReady = true;
			RocketUI.GetComponent<Image>().color = new Color (1f, 1f, 1f, 1f);
		}

		//Animiert RocketBar
		void AnimateRocketBar(){
			if (RocketUI.GetComponent<Image> ().fillAmount < 1) {
				RocketUI.GetComponent<Image> ().fillAmount += 0.01f;
			}
		}

		//Shield-Cooldown
		void EnableShield(){
			this.ShieldReady = true;
			ShieldCom.SetActive (false);
			ShieldUI.GetComponent<Image>().color = new Color (1f, 1f, 1f, 1f);
		}

		//Animiert ShieldBar
		void AnimiateShieldBar(){
			if (ShieldUI.GetComponent<Image> ().fillAmount < 1) {
				ShieldUI.GetComponent<Image> ().fillAmount += 0.01f;
			}
		}

		//Handhabung der Schilde
		void ShieldUpdate(){
			HealthBar.GetComponent<Image> ().fillAmount = (float)PlayerHealth / 100;

			if (PlayerHealth == 0) {
				//Application.Quit();
				GameOver();
			}
		}

		//Handhabung der aktuellen Energie -> Wird als Co-Routine aufgerufen!
		void EnergyUpdate(){
			EnergyBar.GetComponent<Image> ().fillAmount = (float)energy / 100;

			if (energy != 100) {
				energy += energy_rate;
			}
		}

		//PunkteAnzeige
		void ScoreUpdate(){
			ScoreText.GetComponent<Text> ().text = "Score: " + score.ToString ();
		}

		//GameOver-Logik
		void GameOver(){
			if (!t_gameover) {
				Time.timeScale = 0.10f;
				InvokeRepeating("GameOverproceed", 0.2f, 0);
				t_gameover = true;
			}
		}

		//Wird nach kurzer Zeit aktiviert
		void GameOverproceed(){
			Time.timeScale = 0.00f;
			GameOverScreen.SetActive(true);
		}
	}
}
