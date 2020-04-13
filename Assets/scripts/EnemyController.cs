using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	public Enemy enemy;
	void Start () {
		InvokeRepeating("newEnemy", 5, Random.Range(8f, 10f));
	}
	void Update () {
		
	}

	public void newEnemy() {
		//Debug.Log("적 속도: " + enemy.speed);
		enemy.speed += 0.2f;
		Vector2 randomLocation = new Vector2(Random.Range(-2.51f,2.51f), Random.Range(-2.3f, 4.7f));
		Instantiate(enemy, randomLocation, Quaternion.identity);
	}
}
