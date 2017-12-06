﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour {

	public float speed;
	private GameObject[] targets;
	private GameMaster gm;


	void Start(){
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		if(targets == null){
			targets = GameObject.FindGameObjectsWithTag("Player");
		}
	}


	void Update(){

		// Makes the chaser follow the nearest player !
		if(gm.fire > 0){
			if(Vector2.Distance(transform.position, targets[0].transform.position) > Vector2.Distance(transform.position, targets[1].transform.position)){
				transform.position = Vector2.MoveTowards(transform.position, targets[1].transform.position, speed * Time.deltaTime);
			} else {
				transform.position = Vector2.MoveTowards(transform.position, targets[0].transform.position, speed * Time.deltaTime);
			}
		}


	}
}
