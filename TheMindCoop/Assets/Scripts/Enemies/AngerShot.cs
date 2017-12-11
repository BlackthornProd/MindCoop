using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngerShot : MonoBehaviour {

	public float lifeTime;
	public int damage;


	private GameMaster gm;
	public GameObject destroyEffect;
	private CameraShake shake;
	private HurtPanel hurtPanel;

	void Start(){
		hurtPanel = GameObject.FindGameObjectWithTag("HurtPanel").GetComponent<HurtPanel>();
		shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();

		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		Invoke("Death", lifeTime);
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			shake.Shake(.3f, .3f);
			hurtPanel.Anim();

			gm.TakeDamage(damage);
			Death();
		}
	}

	void Death(){
		Instantiate(destroyEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
