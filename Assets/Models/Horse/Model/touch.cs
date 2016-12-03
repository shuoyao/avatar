using UnityEngine;
using System.Collections;

public class touch : MonoBehaviour {

	public GameObject gorilla;
	public GameObject horse;
	public GameObject tiger;
	public GameObject butterfly;
	public GameObject rat;
	public GameObject cat;
	public GameObject new_horse;
	public GameObject grid;


	void start() {
		gorilla.SetActive (true); 
		horse.SetActive (true); 
		tiger.SetActive (true); 
		butterfly.SetActive (true); 
		rat.SetActive (true); 
		cat.SetActive (true);
		grid.SetActive (true);

	}

	void Awake()
	{
		new_horse.SetActive (false);
	}

	void Update() {
		int fingerCount = 0;
		foreach (Touch touch in Input.touches) {
			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled) {
				gorilla.SetActive (false); 
				tiger.SetActive (false); 
				butterfly.SetActive (false); 
				rat.SetActive (false); 
				cat.SetActive (false);
				horse.SetActive (false);
				grid.SetActive (false);
				new_horse.SetActive (true);
			}

		}
	}
}