using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

	public GameObject detroyEffect;
	public float timeToDestroy = 5f;
	public bool hasFx = true;

	void Start(){

		Invoke("End", timeToDestroy);
	}

	void End(){
		if(hasFx == true){
			Instantiate(detroyEffect, transform.position, Quaternion.identity);
		}

		Destroy(gameObject);
	}
}
