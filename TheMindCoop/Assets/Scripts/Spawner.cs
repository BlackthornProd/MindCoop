using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] possibleSpawns;

	void Start(){

		int randomSpawn = Random.Range(0, possibleSpawns.Length);
		Instantiate(possibleSpawns[randomSpawn], transform.position, transform.rotation);
	}
}
