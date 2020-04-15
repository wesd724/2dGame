using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	void Start() {
		//print(Test.test1);
	}
	public void mainScene() {
		SceneManager.LoadScene("main");
	}
}
