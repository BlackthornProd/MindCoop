using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenHunger : MonoBehaviour {

	[Header("References")]
	private Transform midPoint;
	private Animator anim;
	public GameObject[] targets;

	[Header ("Stats")]
	private float speed;
	public float startSpeed;
	public int damage;

	private float changeTime;
	private int randTarget;
	public float startChangeTime;

	void Awake(){
		/*if(targets == null){
			targets = GameObject.FindGameObjectsWithTag("Player");
		}*/
	}


	void Start(){
		anim = GetComponent<Animator>();
		midPoint = GameObject.FindGameObjectWithTag("Mid").GetComponent<Transform>();

		changeTime = 0;
		speed = startSpeed;
	}

	void Update(){

		if(changeTime <= 0){
			changeTime = 2f;
			randTarget = Random.Range(1, 4);
		} else {
			changeTime -= Time.deltaTime;
		}

		if(randTarget == 1){
			transform.position = Vector2.MoveTowards(transform.position, midPoint.position, speed * Time.deltaTime);
		} else if(randTarget == 2){
			transform.position = Vector2.MoveTowards(transform.position, targets[0].transform.position, speed * Time.deltaTime);
		} else if(randTarget == 3){
			transform.position = Vector2.MoveTowards(transform.position, targets[1].transform.position, speed * Time.deltaTime);
		}

	}
}
