﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	public float lifetime;
	public int damage;
	private GameMaster gm;
	private int health = 1;

	public GameObject explosion;
	public GameObject bombMark;

	void Start(){
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
	}

	void Update(){

		if(lifetime <= 0){
			DestroyBomb(1);
		} else {
			lifetime -= Time.deltaTime;
		}

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
		Debug.Log("Hellio");
		Vector2 pos = new Vector2(transform.position.x, transform.position.y + 2f);
		GameObject fx = (GameObject)Instantiate(explosion, pos, Quaternion.identity);
		Instantiate(bombMark, transform.position, Quaternion.identity);
		Destroy(fx, 4f);
		health -= damage;
	}

}
