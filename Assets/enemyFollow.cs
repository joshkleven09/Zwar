using UnityEngine;
using System.Collections;

public class enemyFollow : MonoBehaviour {
	private Transform target;
	public float followSpeed = 1f;
	// Use this for initialization
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		target = go.transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(target.position);
		transform.Rotate(new Vector3(0,-90,0),Space.Self);//correcting the original rotation
		
		

		transform.Translate(new Vector3(followSpeed* Time.deltaTime,0,0) );

		
	}

	void OnTriggerEnter2D(Collider2D col) {
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		if(col.gameObject.tag == "Player"){
			Destroy(gameObject);
			Destroy(go);
		}
	}
}
