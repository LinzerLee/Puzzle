using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class cube : MonoBehaviour {
    private static Dictionary<string, Transform> cubes = new Dictionary<string, Transform>();
    private SpriteRenderer sr;
    private Image image;
    private Transform parent;
    private float _angle = .0f;

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
                }
            }
        }
        else if (Input.GetMouseButtonUp(2))
        {
            if (transform.parent == null)
            {
                Debug.Log("RButton");
            }
        }
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
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
                // transform.Rotate(.0f, .0f, -5.0f);
                Rotate(-5.0f);
            }
            //Zoom in
            else if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                // transform.Rotate(.0f, .0f, 5.0f);
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
        transform.rotation = Quaternion.AngleAxis(Angle, new Vector3(0, 0, 1));
    }

    private void Rotate(float angle)
    {
        RotateTo(Angle + angle);
    }
}
