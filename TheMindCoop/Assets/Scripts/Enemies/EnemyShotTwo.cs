using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotTwo : MonoBehaviour {

	public float speed;
	public int damage;

	private GameMaster gm;
	public GameObject destroyEffect;
	private HurtPanel hurtPanel;

	void Start(){
		hurtPanel = GameObject.FindGameObjectWithTag("HurtPanel").GetComponent<HurtPanel>();
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		Invoke("DestroyFx", 3f);
	}


	void Update(){

		transform.Translate(Vector2.right * speed * Time.deltaTime);
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
