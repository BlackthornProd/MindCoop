using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBoost : MonoBehaviour {

	private GameMaster gm;
	public GameObject destroyFx;

	void Start(){

		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			gm.fireShield = 150;
			GameObject fx = (GameObject) Instantiate(destroyFx, transform.position, Quaternion.identity);
			Destroy(fx, 5f);
			Destroy(gameObject);
		} 
	}
}
