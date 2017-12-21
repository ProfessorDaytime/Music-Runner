using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

  public Rigidbody rb;

  public float forwardForce = 100f;
  public float sidewaysForce = 250f;

  //Seth's movement
  private float moveSpeed = 16f;




  //Seth's Platform Generation
  // private float spawnSpeed;
  // private int horizon = 12;
  //
  // float lengthinZaxis = 10f;
  //
  // Vector3 lastPos;
  //
  // [SerializeField]
  // GameObject ground;
  //
  // [SerializeField]
  // Transform firstObject;


  //End of Seth's Platform Generation

  // Use this for initialization
  void Start ()
  {


    //Ground Genearation
    // lastPos = firstObject.transform.position;
    //
    // for (int i = 0; i <= horizon; i++){
    //   Spawning();
    // }
    //End of Ground Generation
    //Debug.Log("Hello World");
    //rb.useGravity = false; //turns gravity off
    //rb.AddForce(0, 200, 500);
  }

  //Seth's Ground Spawning
  // private void Spawning(){
  //   GameObject _object = Instantiate (ground) as GameObject;
  //   _object.transform.position = lastPos + new Vector3 (0f, 0f, lengthinZaxis);
  //   lastPos = _object.transform.position;
  //
  // }


  // Update is called once per frame
  // We use "Fixed"Update because we are using it to mess with phyiscs
  // void FixedUpdate ()
  // {
  //   rb.AddForce(0, 0, forwardForce * Time.deltaTime); //adds force to z-axis
  //
  //   if ( Input.GetKey("d") )
  //   {
  //     rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
  //   }
  //
  //   if (Input.GetKey("a"))
  //   {
  //     rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
  //   }
  //
  //
  //   if (rb.position.y < -1f)
  //   {
  //     FindObjectOfType<GameManager>().EndGame();
  //   }
  //
  //   //Seth's Ground Genearation
  //   if(lastPos.z - transform.position.z < (horizon * lengthinZaxis)){
  //     Spawning();
  //   }
  //
  //
  //
  // }

  // Seth's Update is called once per frame
	void Update () {


		transform.Translate (moveSpeed *1.5f * Input.GetAxis ("Horizontal") * Time.deltaTime, 0f, moveSpeed * Time.deltaTime);

    if(transform.position.y != -0.45f){
      transform.position = new Vector3(transform.position.x, -0.45f, transform.position.z);
    }


    if(transform.rotation != Quaternion.identity){
      transform.rotation = Quaternion.identity;
    }

		//spawns new platforms if you get close to the horizon
		// if(lastPos.z - transform.position.z < (horizon * lengthinZaxis)){
		// 	Spawning();
		// }
	}

}
