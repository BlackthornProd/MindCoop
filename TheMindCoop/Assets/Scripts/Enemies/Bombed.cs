using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombed : MonoBehaviour {

	public Chaser bomb;
	public Transform[] spawnPoints;


	public void Death(){

		for (int i = 0; i < spawnPoints.Length; i++) {
			Chaser spawn = (Chaser)Instantiate(bomb, spawnPoints[i].position, Quaternion.identity);
			spawn.speed = spawn.speed * 1.5f;
		}
	}
}
