using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Camera.main.ScreenToWorldPoint (Input.mousePosition).x > transform.position.x + 0.3f) {
			//face right
			transform.eulerAngles = new Vector3 (0, 0, 0);
			transform.Translate (new Vector3 (1f * Time.deltaTime, 0f, 0f));
			anim.SetTrigger ("walk");
			anim.ResetTrigger ("idle");
		} else if (Camera.main.ScreenToWorldPoint (Input.mousePosition).x < transform.position.x - 0.3f) {
			//face left
			transform.eulerAngles = new Vector3 (0, 180, 0);
			transform.Translate (new Vector3 (1f * Time.deltaTime, 0f, 0f));
			anim.SetTrigger ("walk");
			anim.ResetTrigger ("idle");
		} else {
			anim.SetTrigger ("idle");
			anim.ResetTrigger ("walk");
		}
	}
}
