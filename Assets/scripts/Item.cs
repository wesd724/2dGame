using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {
	public float speedItem = 3f;
	public int itemcoolTime = 5;
	public Slider cooldownSlider;
	private float cooldownTime;
	private bool status = false; 
	private float newSpeed;
	private SpriteRenderer sprite;
	private PlayerController playerController;
	//private Enemy enemy;
	void Start () {
		playerController = GameObject.Find("Player").GetComponent<PlayerController>();
		//enemy = GameObject.Find("enemy").GetComponent<Enemy>();
		sprite = GetComponent<SpriteRenderer>();
		cooldownSlider.gameObject.SetActive(status);
		newSpeed = playerController.speed;
		cooldownSlider.value = 100;
		cooldownTime = Mathf.Ceil(100 / (float)itemcoolTime);
	}
	
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {
			cooldownSlider.value = 100;
			status = true;
			sprite.enabled = false;
			cooldownSlider.gameObject.SetActive(status);
			StartCoroutine("newItem");
		}
	}

	IEnumerator newItem() {
		InvokeRepeating("coolTime", 0 ,1);
		playerController.speed = speedItem;
		yield return new WaitForSeconds(itemcoolTime);
		CancelInvoke("coolTime");
		//if(enemy.speed < 1.2) {
			playerController.speed = newSpeed;
		// } else if(enemy.speed >= 1.2) {
		// 	playerController.speed = newSpeed + 0.2f;
		// }
		transform.position = new Vector2(Random.Range(-2.51f,2.51f), Random.Range(-2.3f, 4.7f));
		yield return new WaitForSeconds(Random.Range(1.0f, 2.5f));
		sprite.enabled = true;
		yield break;
		
	}

	void coolTime() {
		if(cooldownSlider.value > cooldownTime) {
			cooldownSlider.value -= 100 / itemcoolTime;
		} else if(cooldownSlider.value == cooldownTime) {
			status = false;
			cooldownSlider.gameObject.SetActive(status);
		}
	}
}
