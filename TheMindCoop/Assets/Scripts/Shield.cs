using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

	[Header ("References")]
	private GameMaster gm;
	public SpriteRenderer shieldBody;
	public Sprite[] bodies;
	private Transform midPoint;
	public GameObject effect;

	[Header ("Stats")]
	public int health = 300;
	public float speed = 50f;


	void Start(){
		midPoint = GameObject.FindGameObjectWithTag("Mid").GetComponent<Transform>();
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		gm.shieldProtection = health;
	}

	void Update(){

		transform.position = Vector2.MoveTowards(transform.position, midPoint.position, speed * Time.deltaTime);

		if(gm.shieldProtection <= 300 && gm.shieldProtection > 200){
			shieldBody.sprite = bodies[0];
		} else if(gm.shieldProtection <= 200 && gm.shieldProtection > 150){
			shieldBody.sprite = bodies[1];
		} else if(gm.shieldProtection <= 150 && gm.shieldProtection > 100){
			shieldBody.sprite = bodies[2];
		} else if(gm.shieldProtection <= 100 && gm.shieldProtection > 0){
			shieldBody.sprite = bodies[3];
		} else if(gm.shieldProtection <= 0){
			Instantiate(effect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
