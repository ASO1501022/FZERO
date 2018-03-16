using UnityEngine;
using System.Collections;

public class Script: MonoBehaviour {
    public GameObject tree;

	// Use this for initialization
	void Start () {

        for (int i = -10; i < 91; i++) {
            GameObject stage = Instantiate(tree);
            stage.transform.position = new Vector3(-60, -10, i * 120);
        }
        for (int i = -10; i < 91; i++) {
            GameObject stage = Instantiate(tree);
            stage.transform.position = new Vector3(60, -10, i * 120);
        }
    }

    // Update is called once per frame
    void Update () {

    }



}
