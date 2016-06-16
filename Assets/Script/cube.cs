using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class cube : MonoBehaviour {
    private static Dictionary<string, Transform> cubes = new Dictionary<string, Transform>();
    private SpriteRenderer sr;
    private Image image;
    private RaycastHit hit = new RaycastHit();
    private bool back_to_cubeboard = false;
    private Transform parent;
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
        
        if (Input.GetMouseButtonDown(0))
        {
            MoveTo(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if(back_to_cubeboard)
            {
                sr.enabled = false;
                sr.sortingLayerName = "UI";
                transform.SetParent(parent);
                image.enabled = true;
                back_to_cubeboard = false;
            }
        }
    }

    void OnCollisionEnter( Collision collisionInfo )
    {
        if(collisionInfo.gameObject.name.Equals("Cubeboard"))
        {
            back_to_cubeboard = true;
        }
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.name.Equals("Cubeboard"))
        {
            back_to_cubeboard = false;
        }
    }

    private void MoveTo(Vector3 pos)
    {
        pos -= transform.position;
        transform.Translate(pos.x, pos.y, 0);
    }
}
