using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footprint : MonoBehaviour {

	void Start(){

		Destroy(gameObject, 1.5f);

		int randomRot = Random.Range(1, 5);

		if(randomRot == 1){
			transform.eulerAngles = new Vector3(0, 0, 0);
		} else if(randomRot == 2){
			transform.eulerAngles = new Vector3(0, 0, 90);
		} else if(randomRot == 3){
			transform.eulerAngles = new Vector3(0, 0, -90);
		} else if(randomRot == 4){
			transform.eulerAngles = new Vector3(0, 0, -180);
		}
	}
}
