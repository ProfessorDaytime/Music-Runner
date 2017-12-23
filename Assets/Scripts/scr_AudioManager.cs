using UnityEngine.Audio;
using System;
using UnityEngine;

public class scr_AudioManager : MonoBehaviour {


	public Sound[] sounds = new Sound[37];


	public static scr_AudioManager instance;

	private string curNote;
	private string prevNote;
	private string curChord;
	private string prevChord;
	private string curKey;
	private string prevKey;
	private bool pentatonicMode;
	//private float curTime;



	// Use this for initialization
	void Awake () {
		if(instance == null)
			instance = this;
		else{
			Destroy(gameObject);
			return;
		}

		foreach (Sound s in sounds){
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
		}


		setChord("Am");

	}


	public void setChord(string chord){

		curChord = chord;
	}


	// public void LoadSounds(){
  //
	// 	//CMajorPent
	// 	//sounds[0].source = "sound/SoftSynthHorn/C4";
	// 	//Debug.Log(sounds[0].name);// = "C4";
	// }

	public void Play(string name){
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if(s == null){
			Debug.LogWarning("Sound with name: " + name + " is not found!");
			return;
		}

		//Debug.Log(Time.time - curTime);
		s.source.Play();
		//curTime = Time.time;
	}
}
