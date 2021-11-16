using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public static int adInit = 0;
	void Start() {
		//print(Test.test1);
	}
	public void mainScene() {
		SceneManager.LoadScene("main");
	}
}
