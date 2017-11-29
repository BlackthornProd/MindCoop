using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnviDetail : MonoBehaviour {

	public GameObject[] randomDetail;

	void Start(){

		int rand = Random.Range(0, randomDetail.Length);
		Instantiate(randomDetail[rand], transform.position, Quaternion.identity);
	}

}
