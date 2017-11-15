using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDrop : MonoBehaviour {

	public int fireBoost = 10;

	private GameMaster gm;
	public GameObject effect;

	void Start(){

		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
	}

	void OnTriggerEnter2D(Collider2D other){

		if(other.CompareTag("Player")){
			GameObject fx = (GameObject) Instantiate(effect, transform.position, Quaternion.identity);
			Destroy(fx, 6f);
			gm.fire += fireBoost;
			Destroy(gameObject);
		}
	}
}
