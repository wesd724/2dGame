using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
	public int gameObject_value = 0;
	public int TestScript_value = 0;
	void Start () {
		print(gameObject_value);
		print(TestScript_value);
	}

	public void hello() {
		print("hellow");
	}

}
