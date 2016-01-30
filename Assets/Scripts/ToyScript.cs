using UnityEngine;
using System.Collections;

public class ToyScript : MonoBehaviour {

	public float deathTime = 10f;
	public bool isHeld;
	public GameObject toyObj;

	// Use this for initialization
	void Start () {
		isHeld = false;
		Invoke("Death", deathTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void Death(){
		Destroy(this.gameObject);
	}
}
