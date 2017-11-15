using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour {

	public GameObject[] roomTemplates;
	private GameObject[] targets;

	private bool hasSpawned = false;

	void Start(){

		if(targets == null){
			targets = GameObject.FindGameObjectsWithTag("Player");
		}

	}

	void Update(){

		if(Vector2.Distance(transform.position, targets[0].transform.position) < 60 && hasSpawned == false || Vector2.Distance(transform.position, targets[1].transform.position) < 60 && hasSpawned == false){
			hasSpawned = true;
			int randomRoom = Random.Range(0, roomTemplates.Length);
			Instantiate(roomTemplates[randomRoom], transform.position, transform.rotation);
		}
	}
}
