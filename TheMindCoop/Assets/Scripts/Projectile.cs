﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float speed;
	public float range;

	[Header ("Damage Tiers")]
	public int damage;
	public int damOne;
	public int damTwo;
	public int damThree;
	public int damFour;
	public int damFive;

	private GameMaster gm;
	private Animator anim;
	public float destructionTime;

	private HurtPanel hurtPanel;

	void Start(){
		hurtPanel = GameObject.FindGameObjectWithTag("HurtPanel").GetComponent<HurtPanel>();
		anim = GetComponent<Animator>();
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

	}

	void Update(){

		// damage depending on FIRE
		if(gm.fire > 0 && gm.fire <= 200){
			damage = damOne;
		} else if(gm.fire > 200 && gm.fire <= 400){
			damage = damTwo;
		} else if(gm.fire > 400 && gm.fire <= 600){
			damage = damThree;
		} else if(gm.fire > 600 && gm.fire <= 800){
			damage = damFour;
		} else if(gm.fire > 800){
			damage = damFive;
		}


		// Destroys the projectile after X seconds !
		if(range <= 0){
			StartCoroutine(AnimWait());
		} else {
			range -= Time.deltaTime;
		}

		// Move forward
		transform.Translate(Vector2.up * speed * Time.deltaTime);
	}


	// Checks Collisions !
	void OnTriggerEnter2D(Collider2D other){

		if(other.CompareTag("Enemy") || other.CompareTag("Merchant")){
				other.GetComponent<Enemy>().TakeDamage(damage);
				StartCoroutine(AnimWait());
		}

		
		if(other.CompareTag("Player") && damage > 0){
			gm.TakeDamage(damage);
			hurtPanel.Anim();
			StartCoroutine(AnimWait());
		} 
		 else if(other.CompareTag("Obstacle")){
			StartCoroutine(AnimWait());
		}  else if(other.CompareTag("Boss")){
			other.GetComponent<Boss1>().TakeDamage(damage);
			StartCoroutine(AnimWait());
		} else if(other.CompareTag("Bomb")){
			other.GetComponent<Bomb>().DestroyBomb(damage);
			StartCoroutine(AnimWait());
		} else if(other.CompareTag("Merchant")){
			other.GetComponent<Merchant>().isAngry = true;
		} else if(other.CompareTag("Boss2")){
			other.GetComponent<Boss2>().TakeDamage(damage);
			StartCoroutine(AnimWait());
		}

	}


	// When the projectile has hit something or has died out...
	IEnumerator AnimWait(){
		anim.SetTrigger("Impact");
		speed = 0;
		damage = 0;
		yield return new WaitForSeconds(destructionTime);
		Destroy(gameObject);
	}
}
