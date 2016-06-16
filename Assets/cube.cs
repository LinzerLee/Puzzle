using UnityEngine;
using System.Collections;

public class cube : MonoBehaviour {
    public float speed = 0.1F;

    private Transform[] cubes;
    // Use this for initialization
    void Start () {
        cubes = transform.parent.GetComponentInChildren<Transform>();
        EventTriggerListener.Get(gameObject).onDown += (go) =>
        {
            transform.localScale = new Vector3(1.2f, 1.2f, 1f);
            
            
        };

        EventTriggerListener.Get(gameObject).onUp += (go) =>
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        };

        EventTriggerListener.Get(gameObject).onBeginDrag += (go, delta) => 
        {
            transform.Translate(delta.x * speed, delta.y * speed, 0);
        };

        EventTriggerListener.Get(gameObject).onDrag += (go, delta) =>
        {
            transform.Translate(delta.x * speed, delta.y * speed, 0);
        };
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
            Debug.Log("拖动");
        }
    }
}
