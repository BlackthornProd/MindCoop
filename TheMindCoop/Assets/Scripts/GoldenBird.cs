using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenBird : MonoBehaviour {

	private Transform midPoint;
	public Transform[] shotsPoints;
	public GameObject shot;

	public float speed;
	private float timeBtwShots;
	public float startTimeBtwShots;

	void Start(){

		midPoint = GameObject.FindGameObjectWithTag("Mid").GetComponent<Transform>();
		timeBtwShots = startTimeBtwShots;
	}

	void Update(){

		transform.position = Vector2.MoveTowards(transform.position, midPoint.position, speed * Time.deltaTime);


		if(timeBtwShots <= 0){
			timeBtwShots = startTimeBtwShots;
			for (int i = 0; i < shotsPoints.Length; i++) {
				Instantiate(shot, shotsPoints[i].position, shotsPoints[i].rotation);
			}
		} else {
			timeBtwShots -= Time.deltaTime;
		}
	}

}
