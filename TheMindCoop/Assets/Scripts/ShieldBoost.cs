using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBoost : MonoBehaviour {

	private GameMaster gm;

	void Start(){

		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			gm.shield += 100;
			Destroy(gameObject);
		} 
	}
}
