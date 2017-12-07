using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenBirdShot : MonoBehaviour {

	public float speed;
	public int damage;

	public GameObject effect;

	void Update(){
		Invoke("Death", 10f);
		transform.Translate(Vector2.right * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(){
		Instantiate(effect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

	void Death(){
		Instantiate(effect, transform.position, Quaternion.identity);
		Destroy(gameObject);	
	}

}
