using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fatty : MonoBehaviour {

	public float speed;
	public float moveTime = 2f;

	public Transform[] movePositions;
	public int randomPos;
	int randomMoveTime;

	public GameObject spawnedDeath;

	void Start(){

		randomPos = Random.Range(0, movePositions.Length);
		randomMoveTime = Random.Range(2, 4);
	}

	void Update(){

		if(moveTime <= 0){
			randomMoveTime = Random.Range(2, 4);
			randomPos = Random.Range(0, movePositions.Length);
			moveTime = 2f;
		} else {
			moveTime -= Time.deltaTime;
			transform.position = Vector2.MoveTowards(transform.position, movePositions[randomPos].position, speed * Time.deltaTime);
		}

		if(transform.position == movePositions[randomPos].position){
			moveTime = 0;
		}
		
	}

	public void Spawn(){

		Instantiate(spawnedDeath, transform.position, transform.rotation);
	}

}
