using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	private int timesHit;
	private LevelManager levelManager;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	private bool isBreakable;
	public AudioClip crack;
	public GameObject smoke;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		// Keep track of breakable bricks
		if(isBreakable){
			breakableCount++;
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	//every time a brick is hit...
	void OnCollisionEnter2D(Collision2D collision){
		AudioSource.PlayClipAtPoint(crack, transform.position);
		if(isBreakable) {
			HandleHits();
		}

	}

	//every time a brick is hit...
	void HandleHits(){
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		print(timesHit);
		if(timesHit >= maxHits){
			breakableCount--;
			levelManager.BrickDestroyed();
			GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
			smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
			Destroy(gameObject);		
		}
		else{
			LoadSprites();
		}
	}

	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex]){	//handles if theres no sprite at the index
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
		else{
			Debug.LogError("Brick sprite was not found!!");
		}
	}
	// Update is called once per frame
	void Update () {
		
	}

	//TODO
	void SimulateWin(){
		levelManager.LoadNextLevel();
	}
}
