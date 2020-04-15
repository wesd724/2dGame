using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
	public int gameObject_value = 0;
	public int TestScript_value = 0;

	public static int test1 = 50; // 다른 씬에서도 접근 가능한 변수이다.
	void Start () {
		//print(gameObject_value);
		//print(TestScript_value);
	}
	public void hello() {
		//print("hellow");
	}

}
