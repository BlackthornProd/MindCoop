using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpit : MonoBehaviour {

	public float speed;
	public int damage;
	private GameObject[] targets;
	private GameMaster gm;
	public GameObject destroyEffect;

	public float lifeTime;

	HurtPanel hurtPanel;


	void Start(){
		hurtPanel = GameObject.FindGameObjectWithTag("HurtPanel").GetComponent<HurtPanel>();
		speed = Random.Range(4, 8);
		lifeTime = Random.Range(3, 8);
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		Invoke("DestroySpit", lifeTime);

		if(targets == null){
			targets = GameObject.FindGameObjectsWithTag("Player");
		}
	}


	void Update(){

		// Makes the chaser follow the nearest player !
		if(Vector2.Distance(transform.position, targets[0].transform.position) > Vector2.Distance(transform.position, targets[1].transform.position)){
			transform.position = Vector2.MoveTowards(transform.position, targets[1].transform.position, speed * Time.deltaTime);
		} else {
			transform.position = Vector2.MoveTowards(transform.position, targets[0].transform.position, speed * Time.deltaTime);
		}
	}


	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			hurtPanel.Anim();
			gm.TakeDamage(damage);
			DestroySpit();
		}
	}


	void DestroySpit(){

		Instantiate(destroyEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
