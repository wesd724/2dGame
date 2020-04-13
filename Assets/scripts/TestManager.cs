using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour {

	public GameObject test_gameObject;
	public Test test_testScript;

	void Start () {
		//test_gameObject.gameObject_value = 1; // 게임오브젝트를 가져오는 것이기에 안된다.
		test_gameObject.GetComponent<Test>().gameObject_value = 1;

		test_testScript.TestScript_value = 2;
		test_testScript.GetComponent<Test>().TestScript_value = 3; // 둘다 됨
		
		//AddComponent<Rigidbody>(); //Addcomponent 할떄에는 gameObject로 명시해서 접근해야함 
		gameObject.AddComponent<Rigidbody>();
		GetComponent<Rigidbody>().velocity = new Vector2(3, 5);
	}
	

}
