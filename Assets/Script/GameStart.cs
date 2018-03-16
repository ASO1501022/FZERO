using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI() {
        if (GUI.Button(new Rect(Screen.width / 2 - 80, Screen.height / 2, 159, 30), "Stage1")) {
            SceneManager.LoadScene("Stage1");
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 80, Screen.height / 2 + 50, 159, 30), "Stage2開発中)")) {
            SceneManager.LoadScene("Stage2");
        }
    }
}
