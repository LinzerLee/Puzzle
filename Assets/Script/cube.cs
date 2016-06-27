using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using PuzzleSceneUtil;

public class cube : MonoBehaviour {
    private SpriteRenderer sr;
    private Image image;
    private Transform parent;
    private float _angle = .0f;
	private float last_touch_begin = .0f;
	private bool is_flip = false;

    public float Angle
    {
        get
        {
            return _angle;
        }

        set
        {
            _angle = ((int)value + 360) % 360;
        }
    }

    // Use this for initialization
    void Start () {
        parent = transform.parent;
        sr = gameObject.GetComponent<SpriteRenderer>();
        image = gameObject.GetComponent<Image>();
        
        EventTriggerListener.Get(gameObject).onDown += (go, mouse_pos) =>
        {
            image.enabled = false;
            sr.sortingLayerName = "TouchHover";
            sr.enabled = true;
        };

        EventTriggerListener.Get(gameObject).onUp += (go, mouse_pos) =>
        {
            sr.sortingLayerName = "Playboard";
            transform.SetParent(null);
        };

        EventTriggerListener.Get(gameObject).onBeginDrag += (go, mouse_pos) => 
        {
            MoveTo(Camera.main.ScreenToWorldPoint(mouse_pos));
        };

        EventTriggerListener.Get(gameObject).onDrag += (go, mouse_pos) =>
        {
            MoveTo(Camera.main.ScreenToWorldPoint(mouse_pos));
        };
    }
	
	// Update is called once per frame
	void Update ()
    {
    }

	public static bool CheckCompleted()
	{
		GameObject[] gos = GameObject.FindGameObjectsWithTag ("cube");
		Vector3 pos;
		foreach (GameObject go in gos) {
			if (!go.GetComponent<cube>().CheckPosition(Camera.main.WorldToScreenPoint(go.transform.position), out pos)) 
			{
				return false;
			}
		}

		return true;
	}

	public bool CheckPosition(Vector3 input_pos, out Vector3 pos)
	{
		pos = new Vector3 (0f, 0f, 0f);
		List<State> states = RuntimeManager.GetPosition(name);

		foreach (State state in states) 
		{
			double angle = state.R;
			if (!state.IsFliped)
				angle = (360 - state.R) % 360;

			// Debug.Log ("R : " + angle + " Angle : " + Angle);
			// Debug.Log ("F : " + state.IsFliped + " is_flip : " + is_flip);
			if (state.IsFliped == is_flip && angle == Angle) 
			{
				pos = new Vector3 ((float)state.X, (float)state.Y, 0f);
				Vector3 offset = new Vector3(0f, 0f, 0f);
				switch(name)
				{
				case "cube_1_1":
					offset.x = 50f;
					offset.y = 25f;
					break;
				case "cube_2_1":
				case "cube_2_2":
					offset.x = 25f;
					offset.y = 25f;
					break;
				case "cube_3_1":
				case "cube_3_2":
					offset.x = 50f;
					offset.y = 25f;
					break;
				case "cube_4_1":
				case "cube_4_2":
					offset.x = 25f;
					offset.y = 37.5f;
					break;
				case "cube_5_1":
				case "cube_5_2":
					offset.x = 37.5f;
					offset.y = 25f;
					break;
				case "cube_6_1":
				case "cube_6_2":
				case "cube_6_3":
				case "cube_6_4":
					offset.x = 12.5f;
					offset.y = 12.5f;
					break;
				case "cube_7_1":
				case "cube_7_2":
					offset.x = 16.67f;
					break;
				}
				pos += offset;
				pos.x = pos.x / RuntimeManager.resolution.Width * Screen.width;
				pos.y = Screen.height - pos.y / RuntimeManager.resolution.Height * Screen.height;

				// Debug.Log("X : " + pos.x + " Y : " + pos.y + " F : " + state.IsFliped);
				// Debug.Log("Cube ：X : " + Input.mousePosition.x + " Y : " + Input.mousePosition.y + " F : " + is_flip);
				// Debug.Log(Vector3.Distance(Input.mousePosition, pos));
				if (Vector2.Distance (new Vector2(input_pos.x, input_pos.y), new Vector2(pos.x, pos.y)) <= 20) 
				{
					return true;
				}
			}
		}

		return false;
	}

	public void OnMouseUp()
    {
		if (Input.GetMouseButtonUp(0))
		{
            if (transform.parent == null)
            {
				float scope = 170f / 1024f * Camera.main.pixelHeight;
                if (Input.mousePosition.y < scope)
                {
					RuntimeManager.cur_cube = null;
                    sr.enabled = false;
                    sr.sortingLayerName = "UI";
                    transform.SetParent(parent);
                    image.enabled = true;

                }
                else
                {
					sr.sortingLayerName = "Playboard";
					Vector3 pos;
					if (CheckPosition(Input.mousePosition, out pos)) 
					{
						MoveTo(Camera.main.ScreenToWorldPoint(pos));
						if (CheckCompleted ()) {
							Button	back, hint, restart, go;

							back = GameObject.Find("back").GetComponent<Button>();
							hint = GameObject.Find("hint").GetComponent<Button>();
							restart = GameObject.Find("restart").GetComponent<Button>();
							go = GameObject.Find("go").GetComponent<Button>();
							/*
							back.enabled = false;
							hint.enabled = false;
							restart.enabled = false;
							go.enabled = true;
							*/
						}
					}
                }
            }
        }
		CheckCompleted ();
    }

	public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
			RuntimeManager.cur_cube = GetComponent<cube> ();
			if (Time.time - last_touch_begin < 0.6) 
			{
				is_flip = !is_flip;
                RotateTo(Angle);
            }

            last_touch_begin = Time.time;

            sr.sortingLayerName = "TouchHover";
        }
    }

	public void OnMouseDrag()
    {
        MoveTo(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    } 

	void OnMouseOver()
    {
        if (transform.parent == null)
        {
            //Zoom out
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                Rotate(-5.0f);
            }
            //Zoom in
            else if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                Rotate(5.0f);
            }
        }
    }

    public void MoveDetal(Vector3 detal)
    {
        transform.Translate(detal.x, detal.y, 0);
    }

	public void MoveTo(Vector3 pos)
    {
        pos.z = 0;
        transform.position = pos;
    }

    public void RotateTo(float angle)
    {
        Angle = angle;
		if (is_flip) 
		{
			transform.rotation = Quaternion.AngleAxis(180.0f, new Vector3(0, 1, 0));
			transform.Rotate(0, 0, Angle);
		} else 
		{
			transform.rotation = Quaternion.AngleAxis(Angle, new Vector3(0, 0, 1));
		}
    }

    public void Rotate(float angle)
    {
		RotateTo(Angle + angle);
    }
}
