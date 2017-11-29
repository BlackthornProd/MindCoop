using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyPatrol : MonoBehaviour {

	public Transform[] moveSpots;

	public float speed;
	int randomPos;
	float randomMoveTime;

	void Start(){
		randomPos = Random.Range(0, moveSpots.Length);
		randomMoveTime = Random.Range(1, 7);
	}

	void Update(){

		if(randomMoveTime <= 0){
			randomPos = Random.Range(0, moveSpots.Length);
			randomMoveTime = Random.Range(1, 7);
		} else {
			transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomPos].position, speed * Time.deltaTime);
			randomMoveTime -= Time.deltaTime;
		}
	}
}
