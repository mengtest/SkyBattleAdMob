using UnityEngine;
using System.Collections;

public class LevelPlane : MonoBehaviour {

    public SpriteRenderer sprite_plane;
    [SerializeField]
    public Sprite[] list_sprite_level;

	// Use this for initialization
	void Start () {
        if (GameSetting.level_plane != 0)
        {
            sprite_plane.sprite = list_sprite_level[GameSetting.level_plane - 1];
            sprite_plane.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = list_sprite_level[GameSetting.level_plane - 1];
        }

    }
	
}
