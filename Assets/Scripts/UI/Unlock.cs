using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Unlock : MonoBehaviour {

	public int numberlevel;
	private int checkLock;

    public Button play;
	public GameObject unLock;
	public GameObject Star;

    public List<GameObject> enemy_normal_line;
    public List<GameObject> enemy_normal_curve;
    public List<GameObject> enemy_hard;
    public Material backGround;

    // Use this for initialization
    void Start () {
	
		checkLock = PlayerPrefs.GetInt (MenuScript.LOCK_KEY+numberlevel);

		if (checkLock == MenuScript.TRUE_RESULT) {
			unLock.SetActive (true);
			Star.SetActive(true);
		} else {
			unLock.SetActive (false);
			Star.SetActive(false);
		}

        play.onClick.AddListener(this.playLevel);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void playLevel(){
		if (checkLock == MenuScript.TRUE_RESULT) {
            PlayerPrefs.SetInt(MenuScript.LEVEL_KEY,numberlevel);
			Application.LoadLevel(MenuScript.STORE_NAME);
		}
        // set data for scene
        Data.instance.setData(enemy_normal_line, enemy_normal_curve, enemy_hard, backGround);
	}
}
