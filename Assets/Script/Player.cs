using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    GameObject mainCamera;
    GameObject player;
    GameObject obj;
    GameObject under;
    CharacterController cc;
    AudioSource player_AudioSource;
    AudioSource mainCamera_AudioSource;

    public GameObject stageClear;
    public GameObject start_1;
    public GameObject start_2;
    public GameObject start_3;
    public GameObject start;
    public GameObject Right_Up;
    public GameObject Left_Up;
    public GameObject Right_Down;
    public GameObject Left_Down;
    public GameObject colAudio;
    

    Vector3 dir;

    private float x, y, z;
    private float PLAYER_RIGHT    = 300.0f;
    private float PLAYER_LEFT     = -300.0f;
    private float GRAVITY         = -8.0f;
    private float dash            = 750.0f;
    private bool colFlg           = false;
    private bool clearFlg         = false;
    private float time            = 4.0f;

    int start_Flg = 3;

    static bool checkPointFlg = false;
    static Vector3 checkPoint;

    void Start () {
        under = GameObject.Find("Under");
        mainCamera = GameObject.Find("Main Camera");
        player = GameObject.Find("Player");
        player_AudioSource = gameObject.GetComponent<AudioSource>();
        mainCamera_AudioSource = mainCamera.GetComponent<AudioSource>();
        if (checkPointFlg) {
            transform.position = checkPoint;
        }
    }

    // Update is called once per frame
    void Update () {
        x = 0.0f;
        y = 0.0f;
        z = dash * Time.deltaTime;
        if (!getColFlg()) time -= 1.0f * Time.deltaTime;

        if (-34.0f < transform.position.x && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))) {
            x = PLAYER_LEFT * Time.deltaTime;
        }
        if (transform.position.x < 34.0f && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))) {
            x = PLAYER_RIGHT * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            mainCamera.transform.Rotate(0, 180, 0);
            mainCamera.transform.position += new Vector3(0, -20, 0);
        }

        if (Input.GetKeyUp(KeyCode.Q)) {
            mainCamera.transform.Rotate(0, -180, 0);
            mainCamera.transform.position += new Vector3(0, 20, 0);
        }


        if (!getColFlg() && start_Flg != -1) { 

        time -= 0.1f * Time.deltaTime;

            switch ((int)time) {
                case 1:
                    if (start_Flg == 1) {
                        Destroy(obj);
                        obj = Instantiate(start_1);
                        start_Flg--;
                    }
                    break;
                case 2:
                    if (start_Flg == 2) {
                        Destroy(obj);
                        obj = Instantiate(start_2);
                        start_Flg--;
                    }
                    break;
                case 3:
                    if (start_Flg == 3) {
                        obj = Instantiate(start_3);
                        start_Flg--;
                    }
                    break;
                default:
                    setColFlg(true);
                    Destroy(obj);
                    obj = Instantiate(start);
                    Destroy(obj,1.0f);
                    start_Flg--;
                    break;
            }
        }

        if (under.transform.position.y + 4 < player.transform.position.y) {
            y += GRAVITY * Time.deltaTime;
        }

        dir = new Vector3(x, y, dash);
        //プレイヤーを移動させる
        if (getColFlg()) {
            dir = new Vector3(x, y, z);
            transform.GetComponent<CharacterController>().Move(dir);

        }

    }

    void OnControllerColliderHit(ControllerColliderHit col) {
        if (col.gameObject.tag == "Enemy") {
            mainCamera_AudioSource.Stop();
            Right_Up.GetComponent<ParticleSystem>().Stop();
            Left_Up.GetComponent<ParticleSystem>().Stop();
            Right_Down.GetComponent<ParticleSystem>().Stop();
            Left_Down.GetComponent<ParticleSystem>().Stop();
            mainCamera.transform.parent = null;

            setColFlg(false);
            Col_Audio col_Audio = colAudio.GetComponent<Col_Audio>();
            col_Audio.colSound();

        }
        if (col.gameObject.tag == "Goal" && !getClearFlg()) {
            StartCoroutine("clear");
            mainCamera.transform.parent = null;
            Destroy(player, 3);
            setClearFlg(true);
        }



        Debug.Log(col.gameObject);
    }

    void onTriggerEnter(Collider col) {
        if(col.gameObject.tag == "CheckPoint"){
            checkPoint = transform.position;
        }
    }

    IEnumerator clear() {
        yield return new WaitForSeconds(1.0f);
        Instantiate(stageClear);
        StartCoroutine("scene");
    }

    IEnumerator scene() {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Start");
    }

    public void setColFlg(bool flg) {
        colFlg = flg;
    }

    public bool getColFlg() {
        return colFlg;
    }

    public void setClearFlg(bool flg) {
        clearFlg = flg;
    }

    public bool getClearFlg() {
        return clearFlg;
    }



}
