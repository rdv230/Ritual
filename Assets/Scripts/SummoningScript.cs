using UnityEngine;
using System.Collections;

public class SummoningScript : MonoBehaviour {

	public ParticleSystem HecateSystem;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D (Collider2D coll){
		if(coll.gameObject.name == "Hecate"){
			
		}
	}
}
