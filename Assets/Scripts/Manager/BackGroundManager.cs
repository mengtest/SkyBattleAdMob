using UnityEngine;
using System.Collections;

public class BackGroundManager : MonoBehaviour {

    public Animator ani;
    private GameManager _gameManager;

    // Use this for initialization
    void Start () {
        transform.position = GameSetting.positionCam;
        float height = GameSetting.sizeCam.y;
        float width = GameSetting.sizeCam.x;
        transform.localScale = new Vector3((width+1) / 10, 1.0f, -(height + 1) / 10);
        ani = GetComponent<Animator>();
        _gameManager = GameSetting._gameManager;
        if (Data.instance.backGround != null)
            GetComponent<MeshRenderer>().material = Data.instance.backGround;
    }

    // Update is called once per frame
    void Update () {
        if (_gameManager.gameState != GameState.Play)
        {
            if (ani.enabled == true)
                ani.enabled = false;
        }
        else
        {
            if (ani.enabled == false)
                ani.enabled = true;
        }

    }

}
