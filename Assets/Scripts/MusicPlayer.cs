using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;
	// Use this for initialization
	void Awake(){
		if(instance != null){
			Destroy(gameObject);
			print("Duplicate musicplayer destroyed.");
		}
		else{
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
