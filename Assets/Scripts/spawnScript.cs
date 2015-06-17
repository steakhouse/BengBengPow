using UnityEngine;
using System.Collections;

public class spawnScript : MonoBehaviour {

	public GameObject enemy;
	public int spawnTime = 2;

	// Use this for initialization
	void Start () {
		InvokeRepeating("addEnemy", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void addEnemy() {
		float x1 = transform.position.x - GetComponent<Renderer>().bounds.size.x/2;
		float x2 = transform.position.x + GetComponent<Renderer>().bounds.size.x/2;

		Vector2 spawnPoint = new Vector2 (Random.Range (x1, x2), transform.position.y);
		Instantiate(enemy, spawnPoint, Quaternion.identity);
	}

}
