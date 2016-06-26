using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
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

	void OnGUI()
	{
		if (GUI.Button (new Rect (50, 50, 50, 50), "-5")) 
		{
			if (null != ResourceManager.cur_cube) 
			{
				ResourceManager.cur_cube.Rotate (-5.0f);
			}
		}

		if (GUI.Button (new Rect (150, 50, 50, 50), "+5")) 
		{
			if (null != ResourceManager.cur_cube) 
			{
				ResourceManager.cur_cube.Rotate (+5.0f);
			}
		}
	}
}
