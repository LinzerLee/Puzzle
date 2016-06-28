using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement; 

public class select : MonoBehaviour {
	Button	retBtn;
	// Use this for initialization
	void Start () {
		GameObject playboard = GameObject.Find("Playboard");

		retBtn = playboard.transform.Find("return").GetComponent<Button>();

		EventTriggerListener.Get(retBtn.gameObject).onDown += OnStartBtnDown;
		EventTriggerListener.Get(retBtn.gameObject).onUp += OnStartBtnUp;
	}

    void Awake()
    {
        // 忽略章节数据加载
        // 加载场景数据
        int cnt = int.Parse(RuntimeManager.scene.Substring(RuntimeManager.scene.LastIndexOf('.') + 1));
        switch(cnt)
        {
            case 3:
                GameObject.Find("diagram_3").transform.position = new Vector3(0, -2.3f);
                GameObject.Find("diagram_2").transform.position = new Vector3(-2.3f, 0);
                GameObject.Find("diagram_1").transform.position = new Vector3(0, 2.3f);

                GameObject.Find("diagram_3").GetComponent<SpriteRenderer>().sortingLayerName = "UI";
                GameObject.Find("diagram_2").GetComponent<SpriteRenderer>().sortingLayerName = "UI";
                GameObject.Find("diagram_1").GetComponent<SpriteRenderer>().sortingLayerName = "UI";
                break;
            case 2:
                GameObject.Find("diagram_2").transform.position = new Vector3(0, -2.3f);
                GameObject.Find("diagram_1").transform.position = new Vector3(-2.3f, 0);

                GameObject.Find("diagram_2").GetComponent<SpriteRenderer>().sortingLayerName = "UI";
                GameObject.Find("diagram_1").GetComponent<SpriteRenderer>().sortingLayerName = "UI";
                break;
            default:
                GameObject.Find("diagram_1").transform.position = new Vector3(0, -2.3f);
                GameObject.Find("diagram_1").GetComponent<SpriteRenderer>().sortingLayerName = "UI";
                break;
        }
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
