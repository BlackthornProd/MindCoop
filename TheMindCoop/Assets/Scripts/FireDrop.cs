using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDrop : MonoBehaviour {

	public int fireBoost = 10;
	public int fireBoostDefault = 10;

	private GameMaster gm;
	public GameObject effect;

	public int extraBoost = 10;

	void Start(){

		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

		if(gm.fireShield > 0){
			fireBoost += extraBoost;
		} else {
			fireBoost = fireBoostDefault;
		}
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
