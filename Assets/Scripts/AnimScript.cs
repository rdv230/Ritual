using UnityEngine;
using System.Collections;

public class AnimScript : MonoBehaviour {

	public Animator myAnimator;

	Player playerScript;

	// Use this for initialization
	void Start () {
		playerScript = GameObject.Find("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.A)){
			myAnimator.SetBool("isRunning", true);
		}
		if(Input.GetKeyUp(KeyCode.A)){
			myAnimator.SetBool("isRunning", false);
		}
		if(Input.GetKeyDown(KeyCode.D)){
			myAnimator.SetBool("isRunning", true);
		}
		if(Input.GetKeyUp(KeyCode.D)){
			myAnimator.SetBool("isRunning", false);
		}
//		if(Input.GetKeyDown(KeyCode.Space)){
//			
//			myAnimator.SetBool("isGrounded", false);
//		}
		if(playerScript.isGrounded){
			myAnimator.SetBool("isGrounded", true);
			myAnimator.SetBool("isDown", false);
		}
		if(playerScript.isGrounded && Input.GetKeyDown(KeyCode.Space)){
			myAnimator.SetBool("isDown", true);
			myAnimator.SetBool("isGrounded", false);
		}
		if(!playerScript.isGrounded){
			myAnimator.SetBool("isDown", true);
//			myAnimator.SetBool("isGrounded", false);
		}


	}
}
