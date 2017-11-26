using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCarrier : MonoBehaviour {

	public GameObject bomb;


	public float startTimeBtwBombs;
	private float timeBtwBombs;

	private CarrierDetection detection;
	private Animator anim;

	void Start(){

		timeBtwBombs = startTimeBtwBombs;
		detection = GetComponent<CarrierDetection>();
		detection.enabled = false;

		anim = GetComponent<Animator>();
		anim.SetBool("AngryIdle", true);
	}

	void Update(){

		

		if(timeBtwBombs <= 0){
			Instantiate(bomb, transform.position, Quaternion.identity);
			timeBtwBombs = startTimeBtwBombs;
		} else {
			timeBtwBombs -= Time.deltaTime;
		}
	}
}
