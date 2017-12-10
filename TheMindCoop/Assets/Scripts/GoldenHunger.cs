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
	int rand;

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

		randTarget = Random.Range(0, targets.Length);
		rand = Random.Range(0, 2);
	}

	void Update(){

		if(changeTime <= 0){
			changeTime = startChangeTime;
			randTarget = Random.Range(1, targets.Length);
			rand = Random.Range(0, 2);
		} else {
			changeTime -= Time.deltaTime;
		}

		if(rand == 0){
			transform.position = Vector2.MoveTowards(transform.position, midPoint.position, speed * Time.deltaTime);
		} else if(rand == 1){
			transform.position = Vector2.MoveTowards(transform.position, targets[randTarget].transform.position, speed * Time.deltaTime);
		} 

	}
}
