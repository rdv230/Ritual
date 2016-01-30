using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {

	public float rolledNum;
	public float timeToNextRoll;
	public float lowNumber = 0.2f;
	public float HighNumber = 3;
	public bool hasRolled = false;
	GameObject currentToy;
	public GameObject[] Toys;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasRolled){
			Roll();
			hasRolled = true;
		}else{
			timeToNextRoll+= Time.deltaTime;
		}
		if(timeToNextRoll >= rolledNum){
			hasRolled = false;
			timeToNextRoll = 0;
			GenerateToy();
//			Debug.Log("GENERATE TOY");
		}

	
	}

	void Roll(){
		rolledNum = Random.Range(lowNumber,HighNumber);
		currentToy = Toys[Random.Range(0,3)];
	}

	void GenerateToy(){
		GameObject Obj = Instantiate(currentToy,new Vector3(Random.Range(-7,8),5),Quaternion.identity) as GameObject;
		Obj.transform.Rotate(new Vector3(0,0,Random.Range(0,360)));

	}
}
