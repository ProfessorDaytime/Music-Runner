using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;
using UnityEngine;

public class scr_Spawn : MonoBehaviour {

	//Seth's Platform Generation
  private float spawnSpeed;
  private int horizon = 12;
  private bool obOn = false; //Decides whether or not obstacles will be drawn this row

  private List<string> lvlData = new List<string>();//list of string lines of Generation
  private int curLine = 0;

  float lengthinZaxis = 10f;

  Vector3 lastPos;

  [SerializeField]
  GameObject ground;

  [SerializeField]
  Transform firstObject;

	[SerializeField]
  GameObject pickUp;
  //public PickUp pickUp;

  [SerializeField]
  GameObject obstacle;

	// Use this for initialization
	void Start () {

		//Ground Genearation
    lastPos = firstObject.transform.position;
    if(Load("Assets/Scripts/dat_LvlTest2.txt")){
      // Debug.Log("Loaded LVLTEST");
      for (int i = 0; i <= horizon; i++){
        Spawning();
      }
    }

	}

  private void SpawnObstacle(float xPos, float zOffset){

    float height;

    if(zOffset == 0){
      height = UnityEngine.Random.Range(0f,4f);

    }
    else{
      height = UnityEngine.Random.Range(-5f,-2.5f);
    }
    GameObject _obstacle = Instantiate (obstacle) as GameObject;
    _obstacle.transform.localScale += new Vector3(0f,height,0f);
    _obstacle.transform.position = lastPos + new Vector3(xPos, 3.25f + height, lengthinZaxis + zOffset);
  }

  private void SpawnPickUp(float xPos, float zOffset, int interval, bool isChord){
    GameObject pickUpClone = Instantiate (pickUp) as GameObject;
    pickUpClone.transform.position = lastPos + new Vector3(xPos, 1, lengthinZaxis + zOffset);

    PickUp myPickUp = pickUpClone.GetComponent<PickUp>();
    myPickUp.setIsChord(isChord);

    //myPickUp.SetInterval(7);
    if(interval == 0){
      myPickUp.SetInterval(UnityEngine.Random.Range(1,8));
    }
    else{
      myPickUp.SetInterval(interval);
    }


  }

	//Seth's Ground Spawning
  private void Spawning(){
    GameObject _ground = Instantiate (ground) as GameObject;
    _ground.transform.position = lastPos + new Vector3 (0f, 0f, lengthinZaxis);

    string lastGen = "no";


    //Obstacle and Note Spawning
		if(lvlData.Count != 0){
      int curXPos = -50;
      for(int i = 0; i < 100; i++){

        string gen = lvlData[0].Substring(i,1);
        int val = -1;
        int.TryParse(gen, out val);

        if(gen == "w"){
          //Debug.Log("WWWWW");
          SpawnObstacle(curXPos,0);
          lastGen = "obstacle";
        }
        else if(val > 0 && val < 8){
          SpawnPickUp(curXPos, 0, val, false);
          lastGen = "pickUp";
        }
        else if(val == 9){
          SpawnPickUp(curXPos, 0, 0, false);
          lastGen = "pickUp";
        }
        else if (gen == "a"){
          SpawnPickUp(curXPos, 0, 1, true);
          lastGen = "pickUp";
        }
        else if (gen == "b"){
          SpawnPickUp(curXPos, 0, 2, true);
          lastGen = "pickUp";
        }
        else if (gen == "c"){
          SpawnPickUp(curXPos, 0, 3, true);
          lastGen = "pickUp";
        }
        else if (gen == "d"){
          SpawnPickUp(curXPos, 0, 4, true);
          lastGen = "pickUp";
        }
        else if (gen == "e"){
          SpawnPickUp(curXPos, 0, 5, true);
          lastGen = "pickUp";

        }
        else if (gen == "f"){
          SpawnPickUp(curXPos, 0, 6, true);
          lastGen = "pickUp";

        }
        else if (gen == "g"){
          SpawnPickUp(curXPos, 0, 7, true);
          lastGen = "pickUp";

        }
        else if(gen == "r"){
          lastGen = RandomGen(lastGen, curXPos);
        }
        else{
          lastGen = "no";
        }

        curXPos ++;
      }
      lvlData.RemoveAt(0);
    }
    else{
      for (int i = -49; i < 50; i++){
        lastGen = RandomGen(lastGen, i);
      }
    }

    lastPos = _ground.transform.position;
    obOn = !obOn;
  }

  private string RandomGen(string lg, int xPos){
    string lastGen = lg;

    int chooseTens = UnityEngine.Random.Range(0, 10);
    int chooseFives = UnityEngine.Random.Range(0,10);

    //Spawns on the 10s places
    if(chooseTens < 4){//Spawn pickups
      if(lastGen != "pickUp"){
        SpawnPickUp(xPos,0, UnityEngine.Random.Range(1,8), false);
        lastGen = "pickUp";
      }
      else{
        lastGen = "no";
      }

    }
    else if(chooseTens < 7 && obOn){//Spawn Obstacles
      SpawnObstacle(xPos,0);
      lastGen = "obstacle";
    }
    else{
      lastGen = "no";
    }

    return lastGen;
  }

  private bool Load(string fileName){
    //Handle any problems that might arise when reading the Text
    try{
      string line;

      //Create a new StreamReader, tell it which file to read and what encoding the file was saved as
      StreamReader theReader = new StreamReader(fileName, Encoding.Default);

      //Immediately clean up the reader after this block of code is done.
      //You generally use the 'using' statement for potentially memory-intensive objects
      //--instead of relying on garbage collection.
      //(DO NOT CONFUSE THIS WITH THE USING DIRECTIVE FOR NAMESPACE AT THE BEGINNING OF A CLASS)

      using (theReader){

        //while there're lines left in the text file, do this:
        do{

          line = theReader.ReadLine();

          if(line != null){
            //Do whatever you need to do with the text line - it is a string now
            lvlData.Add(line);
            // Debug.Log(line);
          }
          else{
            // Debug.Log("Line was Empty Somehow?");
          }
        }
        while(line != null);
        //Done reading, close the reader and return true to broadcast success

        theReader.Close();
        return true;
      }

    }
    catch (Exception e){
      Debug.Log("Catch");
      Debug.Log(e.Message);
      Console.WriteLine("{0}\n", e.Message);
      return false;
    }
  }


	// Update is called once per frame
	void Update () {

		//spawns new platforms if you get close to the horizon
		if(lastPos.z - transform.position.z < (horizon * lengthinZaxis)){
			Spawning();
		}
	}
}
