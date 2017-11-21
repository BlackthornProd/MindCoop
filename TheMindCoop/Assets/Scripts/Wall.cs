using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Enemy")){
			if(other.GetComponent<Enemy>().isFatty == true){
				other.GetComponent<Fatty>().randomPos = 0;
			}

		}
	}
}
