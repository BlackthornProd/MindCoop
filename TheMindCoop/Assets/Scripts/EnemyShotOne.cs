using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotOne : MonoBehaviour {

	public float speed;
	public int damage;
	int randomDir;

	private GameMaster gm;

	void Start(){
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		Destroy(gameObject, 3f);
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
			gm.TakeDamage(damage);
			Destroy(gameObject);
		}
	}
}
