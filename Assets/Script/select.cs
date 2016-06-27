using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement; 

public class select : MonoBehaviour {
	Button	retBtn;
	// Use this for initialization
	void Start () {
		retBtn = GameObject.Find("return").GetComponent<Button>();

		EventTriggerListener.Get(retBtn.gameObject).onDown += OnStartBtnDown;
		EventTriggerListener.Get(retBtn.gameObject).onUp += OnStartBtnUp;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnStartBtnDown(GameObject go, Vector2 detal)
	{
	}

	void OnStartBtnUp(GameObject go, Vector2 detal)
	{
		SceneManager.LoadScene("home");
	}
}
