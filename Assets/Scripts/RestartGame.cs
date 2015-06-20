using UnityEngine;
using System.Collections;

public class RestartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void RestartGameE(){ //Wird mittels SendMessage von GUI getriggert!
		Application.LoadLevel ("MainScene");
	}
}
