using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 

public class diagram : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp()
	{
		// 准备场景数据--RuntimeManager
		// RuntimeManager.scene
		// RuntimeManager.section
		// 切换场景
		SceneManager.LoadScene("play");
	}
}
