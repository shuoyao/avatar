using UnityEngine;
using System.Collections;

public class Agent : MonoBehaviour {

	public Path path;
	public Animation animation;
	public float reachDistance = 1f;
	public bool drawGizmos = false;
	public float speed = 5f;
	public float rotSpeed = 10f;
	private int currentNodeID = 0;
	private int count = 0; 

	public GameObject text_1; 
	public GameObject text_2; 
	public GameObject text_3; 
	public GameObject text_4; 
	public GameObject horse; 


	void Start () {
		GetComponent<Animator> ().Play ("Horse_Walk");

	}
	void Awake()
	{
		text_1.SetActive (true); 
		text_2.SetActive (false);
		text_3.SetActive (false); 
		text_4.SetActive (false);
	}

	void Update () {
		if (count == 4)
			horse.SetActive(false); 
		Vector3 dest = path.GetNodePos (currentNodeID);
		Vector3 offset = dest - transform.position;
		if (offset.sqrMagnitude > reachDistance) {
			offset = offset.normalized;
			transform.Translate (offset * speed * Time.deltaTime, Space.World);

			Quaternion lookRot = Quaternion.LookRotation(offset);
			transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, rotSpeed * Time.deltaTime);
		} else {
			
				ChangeDestNode();
		}
	}



	void ChangeDestNode(){

		if (count == 1) {
			text_2.SetActive (true); 
			text_3.SetActive (false); 
			text_4.SetActive (false);
		}
		if (count == 2) {
			text_3.SetActive (true); 
			text_2.SetActive (false);
			text_4.SetActive (false);
		}
		if (count == 3) {
			text_4.SetActive (true); 
			text_2.SetActive (false); 
			text_3.SetActive (false); 
		}
		count++; 
		currentNodeID++;
		text_1.SetActive (false); 
		WaitFiveSeconds (); 
		//GetComponent<Animator> ().Play ("Horse_Idle",0,5.0f);
		GetComponent<Animator> ().Play ("Horse_Walk");

		if(currentNodeID >= path.nodes.Length){
			currentNodeID = 0;
			animation.Stop("Horse_Idle");
			animation.Stop("Horse_Walk");
		}
	}


	void OnDrawGizmos() {
		if (drawGizmos) {
			Gizmos.color = Color.red;
			Gizmos.DrawLine(transform.position, path.GetNodePos (currentNodeID));
		}
	}

	IEnumerator WaitFiveSeconds()
	{
		yield return new WaitForSeconds(5);
		GetComponent<Animator> ().Play("Horse_Idle");
	
		foreach (Touch touch in Input.touches) {
			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled) {
				break; 
			}

		}
	}
}