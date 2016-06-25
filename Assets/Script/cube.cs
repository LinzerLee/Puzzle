using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using PuzzleSceneUtil;

public class cube : MonoBehaviour {
    private static Dictionary<string, Transform> cubes = new Dictionary<string, Transform>();
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
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000))
            {
                // 触摸移动
                if (Input.touchCount == 1)
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        OnMouseDown();
                    }
                    else if (touch.phase == TouchPhase.Moved)
                    {
                        MoveTo(Camera.main.ScreenToWorldPoint(touch.position));
                    }
                    else if (touch.phase == TouchPhase.Ended)
                    {
                        OnMouseUp();
                    }
                }
                // 触摸旋转
                else if(Input.touchCount == 2)
                {

                }
            }
        } 
    }

    void OnMouseUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (transform.parent == null)
            {
                float scope = 170f / 1024f * Camera.main.pixelHeight;
                if (Input.mousePosition.y < scope)
                {
                    sr.enabled = false;
                    sr.sortingLayerName = "UI";
                    transform.SetParent(parent);
                    image.enabled = true;

                }
                else
                {
                    sr.sortingLayerName = "Playboard";
					List<State> states = ResourceManager.GetPosition(name);

					foreach (State state in states) 
					{
                        double angle = state.R;
                        if (!state.IsFliped)
                            angle = (360 - state.R) % 360;

                        Debug.Log ("R : " + angle + " Angle : " + Angle);
						Debug.Log ("F : " + state.IsFliped + " is_flip : " + is_flip);
						if (state.IsFliped == is_flip && angle == Angle) 
						{
                            Vector3 pos = new Vector3 ((float)state.X, (float)state.Y, 0f);
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
                            pos.x = pos.x / ResourceManager.resolution.Width * Screen.width;
                            pos.y = Screen.height - pos.y / ResourceManager.resolution.Height * Screen.height;
                            
                            Debug.Log("X : " + pos.x + " Y : " + pos.y + " F : " + state.IsFliped);
                            Debug.Log("Cube ：X : " + Input.mousePosition.x + " Y : " + Input.mousePosition.y + " F : " + is_flip);
                            Debug.Log(Vector3.Distance(Input.mousePosition, pos));
                            if (Vector3.Distance (Input.mousePosition, pos) <= 10) 
							{
								MoveTo(Camera.main.ScreenToWorldPoint(pos));
								break;
							}
						}
					}
                }
            }
        }
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
			if (Time.time - last_touch_begin < 0.6) 
			{
				is_flip = !is_flip;
                RotateTo(Angle);
            }

            last_touch_begin = Time.time;

            sr.sortingLayerName = "TouchHover";
        }
    }

    void OnMouseDrag()
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

    private void MoveDetal(Vector3 detal)
    {
        transform.Translate(detal.x, detal.y, 0);
    }

    private void MoveTo(Vector3 pos)
    {
        pos.z = 0;
        /*
        pos -= transform.position;
        transform.Translate(pos.x, pos.y, 0);
        */
        transform.position = pos;
    }

    private void RotateTo(float angle)
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

    private void Rotate(float angle)
    {
        RotateTo(Angle + angle);
    }
}
