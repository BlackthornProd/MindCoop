using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform[] players;
	public Transform midwayPoint;

	public float smoothSpeed = 0.125f;
	public Vector3 offset;

	void Update(){

		midwayPoint.position = players[1].position + (players[0].position - players[1].position) *0.5f;
	}

	void FixedUpdate(){

		Vector3 desiredPos = midwayPoint.position + offset;
		Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
		transform.position = smoothedPos;

	}

}
