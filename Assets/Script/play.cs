using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement; 

public class play : MonoBehaviour {
	Button	back, hint, restart, go;
	// Use this for initialization
	void Start () {
		GameObject playboard = GameObject.Find("Playboard");

		back = playboard.transform.Find("back").GetComponent<Button>();
		hint = playboard.transform.Find("hint").GetComponent<Button>();
		restart = playboard.transform.Find("restart").GetComponent<Button>();
		go = playboard.transform.Find("go").GetComponent<Button>();

		EventTriggerListener.Get(back.gameObject).onDown += OnBackBtnDown;
		EventTriggerListener.Get(back.gameObject).onUp += OnBackBtnUp;
		EventTriggerListener.Get(hint.gameObject).onDown += OnHintBtnDown;
		EventTriggerListener.Get(hint.gameObject).onUp += OnHintBtnUp;
		EventTriggerListener.Get(restart.gameObject).onDown += OnRestartBtnDown;
		EventTriggerListener.Get(restart.gameObject).onUp += OnRestartBtnUp;
		EventTriggerListener.Get(go.gameObject).onDown += OnGoBtnDown;
		EventTriggerListener.Get(go.gameObject).onUp += OnGoBtnUp;

		go.gameObject.SetActive (false);
	}

	void Awake() 
	{
		GameObject.Find("go").SetActive (false);
		GameObject.Find("poetry").SetActive (false);
        GameObject.Find("Template").GetComponent<Image>().sprite = Resources.Load<Sprite>("bg/scene" + RuntimeManager.scene.Replace('.', '_'));
		GameObject.Find("Playboard").GetComponent<Image>().sprite = Resources.Load<Sprite>("playboard");
    }
	// Update is called once per frame
	void Update () {
		
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			// Debug.Log ("Input : " + Input.mousePosition);
			// Debug.Log ("touch : " + touch.position);
			Ray ray = Camera.main.ScreenPointToRay(touch.position);
			// Debug.Log ("ray (origin): " + ray.origin);
			// Debug.Log ("ray (direction): " + ray.direction);
			// Debug.Log (name + " pos : " + transform.position);
			RaycastHit hit = new RaycastHit();
			if (Physics.Raycast(ray, out hit))
			{
				Debug.Log ("Physics.Raycast");
				// 触摸移动
				if (Input.touchCount == 1)
				{
					if (touch.phase == TouchPhase.Began)
					{
						hit.transform.GetComponent<cube> ().OnMouseDown ();
					}
					else if (touch.phase == TouchPhase.Moved)
					{
						hit.transform.GetComponent<cube> ().OnMouseDrag ();
					}
					else if (touch.phase == TouchPhase.Ended)
					{
						hit.transform.GetComponent<cube> ().OnMouseUp ();
					}
				}
				// 触摸旋转
				else if(Input.touchCount == 2)
				{

				}
			}
		}

	}
    /*
	void OnGUI()
	{
		if (GUI.Button (new Rect (50, 50, 50, 50), "-5")) 
		{
			if (null != RuntimeManager.cur_cube) 
			{
				RuntimeManager.cur_cube.Rotate (-5.0f);
			}
		}

		if (GUI.Button (new Rect (150, 50, 50, 50), "+5")) 
		{
			if (null != RuntimeManager.cur_cube) 
			{
				RuntimeManager.cur_cube.Rotate (+5.0f);
			}
		}
	}
    */
	void OnBackBtnDown(GameObject go, Vector2 detal)
	{
		back.image.sprite = Resources.Load<Sprite>("play/back_hover");
	}

	void OnBackBtnUp(GameObject go, Vector2 detal)
	{
		back.image.sprite = Resources.Load<Sprite>("play/back");
		SceneManager.LoadScene("select");
	}

	void OnHintBtnDown(GameObject go, Vector2 detal)
	{
		hint.image.sprite = Resources.Load<Sprite>("play/hint_hover");
	}

	void OnHintBtnUp(GameObject go, Vector2 detal)
	{
		hint.image.sprite = Resources.Load<Sprite>("play/hint");
	}

	void OnRestartBtnDown(GameObject go, Vector2 detal)
	{
		restart.image.sprite = Resources.Load<Sprite>("play/restart_hover");
	}

	void OnRestartBtnUp(GameObject go, Vector2 detal)
	{
		restart.image.sprite = Resources.Load<Sprite>("play/restart");
	}

	void OnGoBtnDown(GameObject gob, Vector2 detal)
	{
		go.image.sprite = Resources.Load<Sprite>("play/go_hover");
	}

	void OnGoBtnUp(GameObject gob, Vector2 detal)
	{
		go.image.sprite = Resources.Load<Sprite>("play/go");
        SceneManager.LoadScene("select");
	} 
}
