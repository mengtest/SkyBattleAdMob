using UnityEngine;
using System.Collections;

public class DestroyArea : MonoBehaviour {

    [SerializeField]
    BoxCollider2D _ColCenter;

    void Start()
    {
        if (_ColCenter == null)
        {
            return;
        }
        Vector2 size = GameSetting.sizeCam;
        Vector2 center = Vector2.zero;

        _ColCenter.size = new Vector2(Mathf.Abs(size.x) + 1, Mathf.Abs(size.y) + 1);

#if UNITY_4_3 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7
            center.x = _ColTop.center.x;
            center.y = size.y;
            _ColTop.center = center;
#else
        center.y = size.y;
#endif

#if UNITY_4_3 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7
            center.x = _ColBottom.center.x;
            center.y = -size.y;
            _ColBottom.center = center;
#else
        center.y = -size.y;
#endif

        Vector2 horizontalSize = Vector2.zero;
        horizontalSize.x = size.y;
        horizontalSize.y = size.x;

        center.x = (size.x / 2f) + (horizontalSize.x / 2f);
#if UNITY_4_3 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7
            center.y = _ColRight.center.y;
            _ColRight.center = center;
#else

#endif

        center.x = -(size.x / 2f) - (horizontalSize.x / 2f);
#if UNITY_4_3 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7
            center.y = _ColLeft.center.y;
            _ColLeft.center = center;
#endif

    }

    void OnTriggerExit2D(Collider2D c)
    {
        HitCheck(c.transform);
    }

    void HitCheck(Transform colTrans)
    {
        // *It is compared with name in order to separate as Asset from project settings.
        //  However, it is recommended to use Layer or Tag.
        string goName = colTrans.name;
        if (goName.Contains(PlaneController.NAME_ENEMY_BULLET) ||
            goName.Contains(EnemyController.NAME_PLAYER_BULLET))
        {
            UbhObjectPool.Instance.ReleaseGameObject(colTrans.parent.gameObject);

        }
        else
        if (goName.Equals(EnemyController.NAME_PLAYER) == false)
        {
            Destroy(colTrans.gameObject);
        }
    }
}
