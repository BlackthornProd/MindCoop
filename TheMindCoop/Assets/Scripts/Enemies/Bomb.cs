using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	public float lifetime;
	public int damage;
	private GameMaster gm;
	private int health = 1;

	public GameObject explosion;
	public GameObject bombMark;

	HurtPanel hurtPanel;
	CameraShake shake;

	void Start(){
		hurtPanel = GameObject.FindGameObjectWithTag("HurtPanel").GetComponent<HurtPanel>();
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
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
			hurtPanel.Anim();
			gm.TakeDamage(damage);
			DestroyBomb(1);
		}
	}

	public void DestroyBomb(int damage){
		shake.Shake(.1f, .1f);
		Vector2 pos = new Vector2(transform.position.x, transform.position.y + 2f);
		GameObject fx = (GameObject)Instantiate(explosion, pos, Quaternion.identity);
		Instantiate(bombMark, transform.position, Quaternion.identity);
		Destroy(fx, 4f);
		health -= damage;
	}

}
