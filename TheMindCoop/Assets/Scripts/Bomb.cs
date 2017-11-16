using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	public float lifetime;
	public int damage;
	private GameMaster gm;
	private int health = 1;

	void Start(){
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		Destroy(gameObject, lifetime);
	}

	void Update(){

		if(health <= 0){
			Destroy(gameObject);
		}
	}


	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			gm.TakeDamage(damage);
			DestroyBomb(1);
		}
	}

	public void DestroyBomb(int damage){
		health -= damage;
	}

}
