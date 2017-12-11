using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenCat : MonoBehaviour {

	public float speed;
	private float timeBtwDrops;
	public float minTime;
	public float maxTime;
	public int maxFires = 25;

	[Header ("References")]
	private Transform midPoint;
	private Animator anim;
	public GameObject fireDrop;

	void Start(){

		midPoint = GameObject.FindGameObjectWithTag("Mid").GetComponent<Transform>();
		anim = GetComponent<Animator>();
		timeBtwDrops = Random.Range(minTime, maxTime);
	}

	void Update(){

		transform.position = Vector2.MoveTowards(transform.position, midPoint.position, speed * Time.deltaTime);

		if(transform.position == midPoint.position){
			anim.SetBool("isRunning", false);
		} else {
			anim.SetBool("isRunning", true);
		}

		if(timeBtwDrops <= 0 && maxFires > 0){
			maxFires--;
			Instantiate(fireDrop, transform.position, Quaternion.identity);
			anim.SetTrigger("Create");
			timeBtwDrops = Random.Range(minTime, maxTime);
		} else {
			timeBtwDrops -= Time.deltaTime;
		}
	}
}
