using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraDam : MonoBehaviour {

	private GameMaster gm;
	public int damageBoost;

	void Start(){

		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			gm.damage += damageBoost;
			Destroy(gameObject);
		}
	}
}
