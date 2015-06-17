using UnityEngine;
using System.Collections;

public class ParticlesortingLayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "foreground";
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder = 2;
		Destroy(gameObject, 10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
