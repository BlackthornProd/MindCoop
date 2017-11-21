using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotOne : MonoBehaviour {

	public float speed;
	public int damage;
	int randomDir;

	private GameMaster gm;
	public GameObject destroyEffect;

	HurtPanel hurtPanel;

	void Start(){
		hurtPanel = GameObject.FindGameObjectWithTag("HurtPanel").GetComponent<HurtPanel>();
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		Invoke("DestroyFx", 3f);
		randomDir = Random.Range(1, 5);
	}

	void Update(){

		if(randomDir == 1){
			transform.Translate(Vector2.left * speed * Time.deltaTime);
		} else if(randomDir == 2){

			transform.Translate(Vector2.right * speed * Time.deltaTime);
		} else if(randomDir == 3){

			transform.Translate(Vector2.down * speed * Time.deltaTime);
		} else if(randomDir == 4){

			transform.Translate(Vector2.up * speed * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			hurtPanel.Anim();
			gm.TakeDamage(damage);
			DestroyFx();
		}
	}

	void DestroyFx(){

			GameObject fx = (GameObject)Instantiate(destroyEffect, transform.position, Quaternion.identity);
			Destroy(fx, 3f);
			Destroy(gameObject);
	}
}
