using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement; 

public class home : MonoBehaviour {
	Button	start;

	// Use this for initialization
	void Start () {
		start = GameObject.Find("start").GetComponent<Button>();

		EventTriggerListener.Get(start.gameObject).onDown += OnStartBtnDown;
		EventTriggerListener.Get(start.gameObject).onUp += OnStartBtnUp;

	}

	// Update is called once per frame
	void Update () {

	}

	void OnStartBtnDown(GameObject go, Vector2 detal)
	{
		Debug.Log ("OnStartBtnDown");
		start.image.sprite = Resources.Load<Sprite>("home/start");
	}

	void OnStartBtnUp(GameObject go, Vector2 detal)
	{
		Debug.Log ("OnStartBtnUp");
		start.image.sprite = Resources.Load<Sprite>("home/start");
		SceneManager.LoadScene("select");
	}
}
