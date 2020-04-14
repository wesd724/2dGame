using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour {

	public GameObject test_gameObject; // public 이기에 외부에서 오브젝트나 스크립트를 넣어줘야 한다.
	public Test test_testScript;
	private Test test_testScript2;

	void Start () {
		//test_gameObject.gameObject_value = 1; // 게임오브젝트를 가져오는 것이기에 안된다.
		test_gameObject.GetComponent<Test>().gameObject_value = 1;

		test_testScript.TestScript_value = 2;
		test_testScript.GetComponent<Test>().TestScript_value = 3; // 둘다 됨
		
		test_testScript2 = GameObject.Find("test").GetComponent<Test>(); // private 경우에는 GameObject.find 메소드로 오브젝트에 접근해야함
		test_testScript2.hello();
		
		//AddComponent<Rigidbody>(); //Addcomponent 할떄에는 gameObject로 명시해서 접근해야함 
		gameObject.AddComponent<Rigidbody>();
		GetComponent<Rigidbody>().velocity = new Vector2(3, 5);
	}
	

}
