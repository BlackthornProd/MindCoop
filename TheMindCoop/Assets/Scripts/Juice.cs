using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Juice : MonoBehaviour {

	public Sprite[] juices;
	private Image img;

	private GameMaster gm;

	void Start(){
		img = GetComponent<Image>();
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
	}

	void Update(){

		if(gm.fire > 0 && gm.fire <= 200){
			img.sprite = juices[0];
		} else if(gm.fire > 200 && gm.fire <= 400){
			img.sprite = juices[1];
		} else if(gm.fire > 400 && gm.fire <= 600){
			img.sprite = juices[2];
		} else if(gm.fire > 600 && gm.fire <= 800){
			img.sprite = juices[3];
		} else if(gm.fire > 800){
			img.sprite = juices[4];
		}

	}
}
