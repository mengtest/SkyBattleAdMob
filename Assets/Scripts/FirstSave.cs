using UnityEngine;
using System.Collections;

public class FirstSave : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		//PlayerPrefs.DeleteAll ();
        //PlayerPrefs.SetInt(MenuScript.FIRST_GAME_CHECK,MenuScript.FALSE_RESULT);
        if (PlayerPrefs.GetInt(MenuScript.FIRST_GAME_CHECK) != MenuScript.TRUE_RESULT)
        {
            Debug.Log("save first");
            setUp_firstGame();
            PlayerPrefs.SetInt(MenuScript.FIRST_GAME_CHECK, MenuScript.TRUE_RESULT);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setUp_firstGame()
    {
        PlayerPrefs.SetInt(PlaneInformation.LEVEL_PLANE + 0, 1);
        PlayerPrefs.SetInt(PlaneInformation.LEVEL_PLANE + 1, 0);
        PlayerPrefs.SetInt(PlaneInformation.LEVEL_PLANE + 2, 0);
        PlayerPrefs.SetInt(MenuScript.BOOM_KEY, 2);
        PlayerPrefs.SetInt(MenuScript.MONEY_KEY, 0);
        PlayerPrefs.SetInt(MenuScript.LOCK_KEY + 1, MenuScript.TRUE_RESULT);
        PlayerPrefs.SetFloat(MenuScript.SOUND_KEY, 1);
        PlayerPrefs.SetFloat(MenuScript.SFX_KEY, 0.5f);
    }
}
