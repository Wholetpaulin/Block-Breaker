using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;

	void OnTriggerEnter2D(Collider2D trigger){
		GetComponent<AudioSource>().Play();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		levelManager.LoadLevel("Lose");
	}

	void OnCollisionEnter2D(Collision2D collision){
		print("Collision");
	}
}
