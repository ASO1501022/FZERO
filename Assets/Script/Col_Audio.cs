using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Col_Audio : MonoBehaviour {
    GameObject mainCamera;
    public GameObject player_Col_Effect1;
    public GameObject player_Col_Effect2;
    public AudioClip col_Se1;
    public AudioClip col_Se2;
    AudioSource col_AudioSource;
    GameObject player;

    // Use this for initialization
    void Start () {
        col_AudioSource = gameObject.GetComponent<AudioSource>();
        mainCamera = GameObject.Find("Main Camera");
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update () {
	
	}


     public void colSound() {
        col_AudioSource.clip = col_Se1;
        StartCoroutine(effect(0.0f, player.transform.position.x - 3, player.transform.position.y + 5, player.transform.position.z + 3));

    }

    IEnumerator effect(float time, float x, float y, float z) {
        yield return new WaitForSeconds(time);
        col_AudioSource.PlayOneShot(col_Se1);
        GameObject effect = Instantiate((player_Col_Effect1), new Vector3(x, y, z), Quaternion.identity) as GameObject;
        StartCoroutine(effect2(1.0f, player.transform.position.x + 3, player.transform.position.y + 1, player.transform.position.z - 5));


    }
    IEnumerator effect2(float time, float x, float y, float z) {
        yield return new WaitForSeconds(time);
        col_AudioSource.PlayOneShot(col_Se1);
        GameObject effect = Instantiate(player_Col_Effect1, new Vector3(x, y, z), Quaternion.identity) as GameObject;
        StartCoroutine(effect3(0.5f, player.transform.position.x, player.transform.position.y + 5, player.transform.position.z));

    }
    IEnumerator effect3(float time, float x, float y, float z) {
        yield return new WaitForSeconds(time);
        col_AudioSource.PlayOneShot(col_Se1);
        GameObject effect = Instantiate(player_Col_Effect1, new Vector3(x, y, z), Quaternion.identity) as GameObject;
        StartCoroutine(effect4(1.0f, player.transform.position.x, player.transform.position.y + 5, player.transform.position.z - 20));

    }
    IEnumerator effect4(float time, float x, float y, float z) {
        yield return new WaitForSeconds(time);
        col_AudioSource.clip = col_Se2;
        col_AudioSource.PlayOneShot(col_Se2);
        GameObject effect = Instantiate(player_Col_Effect2, new Vector3(x, y, z), Quaternion.identity) as GameObject;
        Destroy(player, 0.5f);
        StartCoroutine("scene");
    }

    IEnumerator scene() {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Start");
    }

}
