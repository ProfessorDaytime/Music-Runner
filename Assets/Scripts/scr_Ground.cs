using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Ground : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");

		string s = string.Concat("Ground Created",transform.position.z);
		//Debug.Log(s);
		// print(Time.time);
	}


	// Update is called once per frame
	void Update () {
		if(player){
			// Debug.Log(player.transform.position.z);
			// Debug.Log(transform.position.z);

		}
		// if((player.transform.position.z - transform.position.z) > playerOffset){
    //
		// 	Destroy(this);
		// }
	}
}
