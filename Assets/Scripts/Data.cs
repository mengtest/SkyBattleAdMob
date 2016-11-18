using UnityEngine;
using System.Collections.Generic;

public class Data : MonoBehaviour {

    public static Data instance;
    public List<GameObject> enemy_normal_line;
    public List<GameObject> enemy_normal_curve;
    public List<GameObject> enemy_hard;
    public Material backGround;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
	
	// Update is called once per frame
	public void setData (List<GameObject> line, List<GameObject> curve, List<GameObject> hard, Material bg) {
        enemy_normal_line = line;
        enemy_normal_curve = curve;
        enemy_hard = hard;
        backGround = bg;
	}
}
