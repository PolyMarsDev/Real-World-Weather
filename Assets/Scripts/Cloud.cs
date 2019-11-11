using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {
	public float maxSpeed;
	public float minSpeed;
	private float speed;
	// Use this for initialization
	void Start () {
		speed = Random.Range (maxSpeed, minSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (speed * Time.deltaTime, 0f, 0f));
		if (transform.position.x >= 8.5f) {
			transform.position = new Vector3 (-8.5f, transform.position.y, transform.position.z);
		}
	}
}
