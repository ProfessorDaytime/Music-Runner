using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Destroyer : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		//Debug.Log("Destroy!!!");

		if(other.tag == "Player"){
			Debug.Break();
		}

		if(other.gameObject.transform.parent){
			Destroy(other.gameObject.transform.parent.gameObject);
		}
		else{
			Destroy(other.gameObject);
		}
	}
}
