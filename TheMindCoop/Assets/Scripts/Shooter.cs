using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	public GameObject shot;
	private float timeBtwShots;
	public float startTimeBtwShots;

	private Animator anim;

	void Start(){
		timeBtwShots = startTimeBtwShots;
		anim = GetComponent<Animator>();
	}

	void Update(){

		if(timeBtwShots <= 0){
			timeBtwShots = startTimeBtwShots;
			anim.SetTrigger("Shoot");
			Instantiate(shot, transform.position, Quaternion.identity);
		} else {
			timeBtwShots -= Time.deltaTime;
		}
	}
}
