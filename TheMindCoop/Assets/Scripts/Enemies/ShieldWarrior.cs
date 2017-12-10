using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldWarrior : MonoBehaviour {

	private GameObject[] targets;
	private int rand;

	void Start(){
		if(targets == null){
			targets = GameObject.FindGameObjectsWithTag("Player");
		}

		rand = Random.Range(0, 2);
	}

	void Update(){

		if(rand == 0){
			Vector3 toTargetVector = targets[0].transform.position - transform.position;
			float zRotation = Mathf.Atan2(toTargetVector.y, toTargetVector.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRotation - 90));
		} else {
			Vector3 toTargetVector = targets[1].transform.position - transform.position;
			float zRotation = Mathf.Atan2(toTargetVector.y, toTargetVector.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRotation - 90));
		}

	}


}
