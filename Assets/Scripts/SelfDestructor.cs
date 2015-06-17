using UnityEngine;
using System.Collections;

public class SelfDestructor : MonoBehaviour {

	//Selbstzerstörung
	public int LiveTime;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, LiveTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
