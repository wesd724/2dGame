using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public static bool isDead;
	public float speed = 1f;
	private float x;
	private float y;
	private Rigidbody2D rigidBody;
	private Animator ani;
	
	//touch key
	private int up_Value;
	private int down_Value;
	private int left_Value;
	private int right_Value;

	private AdMobManager adMob;

	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();
		ani = GetComponent<Animator>();
		adMob = GameObject.Find("AdMobManager").GetComponent<AdMobManager>();
 		// Debug.Log("gameObject: " + gameObject);
		// Debug.Log("this.gameObject: " + this.gameObject);
		// Debug.Log("this: " + this);
	}	
	
	void Update () {

		Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            if (pos.x < 0f) pos.x = 0f;
            if (pos.x > 1f) pos.x = 1f;
            if (pos.y < 0.27f) pos.y = 0.27f;
            if (pos.y > 1f) pos.y = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
		//Debug.Log(pos.y + " , " + transform.position.y);

		x = Input.GetAxis("Horizontal") + left_Value + right_Value;
		y = Input.GetAxis("Vertical") + up_Value + down_Value;

		//transform.position += new Vector3(x * speed * Time.deltaTime, y * speed * Time.deltaTime);

		//transform.Translate( y * Vector3.up * speed * Time.deltaTime + x * Vector3.right * speed * Time.deltaTime);

		if(ani.GetFloat("moveX") != x) {
			ani.SetBool("isChange", true);
			ani.SetFloat("moveX", x);
		} else if(ani.GetFloat("moveY") != y) {
			ani.SetBool("isChange", true);
			ani.SetFloat("moveY", y);
		} else {
			ani.SetBool("isChange", false);
		}
		
	}

	void FixedUpdate() {
		rigidBody.velocity = new Vector2(x, y) * speed;
	}

	public void Die() {
		isDead = false;
		gameObject.SetActive(isDead);
		GameManager.instance.OnPlayerDead();
		adMob.ShowInterstitial();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "item") {
			GameManager.instance.AddScore(1);
		}
	}

	public void ButtonEnter(string type) {
		switch(type) {
			case "U":
				up_Value = 1;
				break;
			case "D":
				down_Value = -1;
				break;
			case "L":
				left_Value = -1;
				break;
			case "R":
				right_Value = 1;
				break;
			case "UL":
				up_Value = 1;
				left_Value = -1;
				break;
			case "UR":
				up_Value = 1;
				right_Value = 1;
				break;
			case "DR":
				down_Value = -1;
				right_Value = 1;
				break;
			case "DL":
				down_Value = -1;
				left_Value = -1;
				break;
		}
	}

	public void ButtonExit(string type) {
		switch(type) {
			case "U":
				up_Value = 0;
				break;
			case "D":
				down_Value = 0;
				break;
			case "L":
				left_Value = 0;
				break;
			case "R":
				right_Value = 0;
				break;
			case "UL":
				up_Value = 0;
				left_Value = 0;
				break;
			case "UR":
				up_Value = 0;
				right_Value = 0;
				break;
			case "DR":
				down_Value = 0;
				right_Value = 0;
				break;
			case "DL":
				down_Value = 0;
				left_Value = 0;
				break;
		}
	}
}
