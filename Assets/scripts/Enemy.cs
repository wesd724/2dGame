using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	
	public float speed = 0.8f;
	// private Rigidbody2D enemyRigidbody;
	private Transform targetTransform;
	// private GameObject target;
	EnemyController enemyController;
	Item item;
	void Start () {
		targetTransform = GameObject.Find("Player").transform;
		// target = GameObject.Find("Player");
		// enemyRigidbody = GetComponent<Rigidbody2D>();
		enemyController = GameObject.Find("enemyController").GetComponent<EnemyController>();
		item = GameObject.Find("item").GetComponent<Item>();
	}
	
	void Update () {
		Vector3 dir = targetTransform.position - transform.position;
		transform.position += dir * speed * Time.deltaTime;    
		float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {
			PlayerController playercontroller = other.gameObject.GetComponent<PlayerController>();
			playercontroller.Die();
			item.CancelInvoke("coolTime");
			item.StopCoroutine("newItem");
			enemyController.CancelInvoke("newEnemy");
		}
	}
}
