using UnityEngine;
using System.Collections;

public class spawnScript : MonoBehaviour {

	public GameObject enemy;
	public float spawnTime = 2;

	// Use this for initialization
	void Start () {
		InvokeRepeating("addEnemy", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void addEnemy() {
		float left = Camera.main.ScreenToWorldPoint( new Vector3(80.0f, 0.0f, 0) ).x;
		float right = Camera.main.ScreenToWorldPoint( new Vector3(Screen.width - 80, 0.0f, 0) ).x;

		Vector2 spawnPoint = new Vector2 (Random.Range (left, right), transform.position.y);

		Instantiate(enemy, spawnPoint, Quaternion.identity);
	}

}
