using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {
			transform.position = new Vector2(Random.Range(-2.51f,2.51f), Random.Range(-2.3f, 4.7f));
			GameManager.instance.AddScore(1);
		}
	}
}
