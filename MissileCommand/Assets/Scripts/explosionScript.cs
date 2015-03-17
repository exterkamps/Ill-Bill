﻿using UnityEngine;
using System.Collections;

public class explosionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.localScale = transform.localScale * 0.5f;
		StartCoroutine( die() );
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 targetScale = transform.localScale * 2;
		transform.localScale = Vector3.Lerp (transform.localScale, targetScale, 1f * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D collidee)
	{
		//destroy a missile
		if (!collidee.gameObject.CompareTag ("explosion")) {
			if (collidee.gameObject.transform.parent.gameObject.CompareTag ("enemyMissile")) {
				GameObject explosion = (GameObject)Instantiate(Resources.Load("explosion_object"));
				explosion.transform.position = collidee.gameObject.transform.position;
				Destroy (collidee.gameObject.transform.parent.gameObject);
			}
		}
	}

	IEnumerator die()
	{
		while (true) {
			//baseScale = transform.localScale;
			//transform.localScale = baseScale * startSize;
			//currScale = startSize;


			//yield;

			//hold
			yield return new WaitForSeconds(1f);//0.2f);
			//die
			Destroy(this.gameObject);
			
		}
	}

}
