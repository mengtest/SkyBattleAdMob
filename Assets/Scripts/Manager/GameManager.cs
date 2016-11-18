using UnityEngine;
using System.Collections;

public enum GameState { None,Play,Pause,EndGame};

public class GameManager : MonoBehaviour {

    [HideInInspector]
    public PlaneController _planeController;
    [HideInInspector]
    public UIManager _uiManager;
    public GameObject[] list_plane;
    public Transform pointGen;
    [HideInInspector]
    public int point;

    [HideInInspector]
    public int countEnemy;
    [HideInInspector]
    public int countEnemyDie;
    [HideInInspector]
    public GameState gameState = GameState.None;

    [Range(0, 2)]
    public int _VsyncCount = 1;
    [Range(0, 60)]
    public int _FrameRate = 60;

    // Use this for initialization
    void Awake()
    {
        SetValue();
    }

    void Start () {
        GameObject plane = (GameObject)Instantiate(list_plane[GameSetting.name_plane], pointGen.position, list_plane[GameSetting.name_plane].transform.rotation);
        _planeController = plane.GetComponent<PlaneController>();
        _uiManager = GameSetting._uiManager;
        _uiManager.updateAvatar(plane.GetComponent<LevelPlane>().list_sprite_level[GameSetting.level_plane - 1]);
    }

    // Update is called once per frame
    public void addPoint(int point)
    {
        this.point += point;
        _uiManager.updateScore(this.point);
    }

    public void gameOver()
    {
        gameState = GameState.EndGame;
        _uiManager.gameOver();
    }

    public void gameWin()
    {
        gameState = GameState.EndGame;
        _uiManager.gameWin();
        bonus();
        PlayerPrefs.SetInt(MenuScript.LOCK_KEY + (int)(GameSetting.level + 1), MenuScript.TRUE_RESULT);
    }

    void bonus()
    {
        int money = PlayerPrefs.GetInt(MenuScript.MONEY_KEY);
        int boom = PlayerPrefs.GetInt(MenuScript.BOOM_KEY);

        PlayerPrefs.SetInt(MenuScript.MONEY_KEY, money + GameSetting.instance.for_money_win);
        PlayerPrefs.SetInt(MenuScript.BOOM_KEY, boom + GameSetting.instance.for_boom_win);
    }

    void SetValue()
    {
        _VsyncCount = Mathf.Clamp(_VsyncCount, 0, 2);
        QualitySettings.vSyncCount = _VsyncCount;

        _FrameRate = Mathf.Clamp(_FrameRate, 1, 120);
        Application.targetFrameRate = _FrameRate;
    }
}
