using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public PlayerMovement movement;
    private scr_AudioManager audioManager;

    void Start(){
      audioManager = FindObjectOfType<scr_AudioManager>();
    }


    void OnCollisionEnter(Collision collisionInfo)
    {
        // Debug.Log(collisionInfo.collider.name);

        if (collisionInfo.collider.tag == "Obstacle")
        {
            //Debug.Log("We hit an obstacle");
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }


        if (collisionInfo.collider.tag == "PickUp"){

          audioManager.Play("C4");

          Destroy(collisionInfo.collider.gameObject);


        }
    }

}
