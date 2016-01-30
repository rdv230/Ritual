using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public float speed = 10;
	public float health = 100;
	public float jumpForce = 20;
	public bool isGrounded = false;
	Rigidbody2D playerBod;
	public GameObject heldObj1;
	public GameObject heldObj2;

	public Image Held1;
	public Image Held2;
	public bool isFlip = true;
	public GameObject Art;

	public GameObject hand1;
	public GameObject hand2;
 

	// Use this for initialization
	void Start () {
		playerBod = GetComponent<Rigidbody2D>();
		health = 100;
	}
	
	// Update is called once per frame
	void Update () {

		if(isFlip){
			Art.transform.localScale = new Vector3 (-1,1,1);
		}else{
			Art.transform.localScale = new Vector3(1,1,1);
		}

	
		Movement();
	}

	void Movement(){
		if(Input.GetKey(KeyCode.A)){
			playerBod.velocity = new Vector2(speed * -1, playerBod.velocity.y);
			isFlip = false;
		}
		if(Input.GetKey(KeyCode.D)){
			isFlip = true;
			playerBod.velocity = new Vector2(speed,playerBod.velocity.y);
		}

//		if(Input.GetKeyUp(KeyCode.A)){
//			playerBod.velocity = new Vector2(0,0);
//		}else if(Input.GetKeyUp(KeyCode.D)){
//			playerBod.velocity = new Vector2(0,0);
//		}

		//JUMP CODE
		if(isGrounded && Input.GetKeyDown(KeyCode.Space)){
			playerBod.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
			isGrounded = false;
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "ground"){
			isGrounded = true;
		}
	}

	void OnTriggerStay2D(Collider2D coll){
		if(coll.gameObject.tag == "toy"){
			Debug.Log("Its happening");
			if(Input.GetKeyDown(KeyCode.Q) && coll.gameObject.GetComponent<ToyScript>().isHeld == false){
//				Debug.Log("GOT" + coll.gameObject.name);
				if(heldObj1 == null){
					heldObj1 = coll.gameObject;
					Collect1();
					coll.gameObject.GetComponent<ToyScript>().isHeld = true;
				} else if(heldObj1 != null && heldObj2 == null){
					heldObj2 = coll.gameObject;
					Collect2();
					coll.gameObject.GetComponent<ToyScript>().isHeld = true;
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.gameObject.tag == "toy" || coll.gameObject.tag == "Player"){
			isGrounded = true;
		}
		Debug.Log("iS this happening?");
	}



	void Collect1(){
		if(heldObj1 != null){

			GameObject toy = heldObj1.GetComponent<ToyScript>().toyObj as GameObject;


			GameObject held = Instantiate(toy, new Vector3(100,100,100),Quaternion.identity) as GameObject;

			GameObject toDestroy;

			toDestroy = heldObj1;
			heldObj1 = held;

			Destroy(toDestroy);
//			Physics2D.IgnoreCollision(
			heldObj1.transform.parent = hand1.transform;
			heldObj1.transform.localPosition = Vector3.zero;
			heldObj1.transform.localScale = new Vector3(1,1,1);
			Held1.sprite = heldObj1.GetComponent<SpriteRenderer>().sprite;
		}
	}

	void Collect2(){
		if(heldObj2 != null){
			GameObject toy = heldObj2.GetComponent<ToyScript>().toyObj as GameObject;


			GameObject held = Instantiate(toy, new Vector3(100,100,100),Quaternion.identity) as GameObject;

			GameObject toDestroy;

			toDestroy = heldObj2;
			heldObj2 = held;

			Destroy(toDestroy);
			heldObj2.transform.parent = hand2.transform;
			heldObj2.transform.localPosition = Vector3.zero;
			heldObj2.transform.localScale = new Vector3(1,1,1);
			Held2.sprite = heldObj2.GetComponent<SpriteRenderer>().sprite;
		}
	}
}
