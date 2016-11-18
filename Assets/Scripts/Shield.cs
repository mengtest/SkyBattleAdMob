using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D c)
    {
        HitCheck(c.transform);
    }

    void HitCheck(Transform colTrans)
    {
        // *It is compared with name in order to separate as Asset from project settings.
        //  However, it is recommended to use Layer or Tag.
        string goName = colTrans.name;
        if (goName.Contains(PlaneController.NAME_ENEMY_BULLET) || goName.Contains(EnemyController.NAME_PLAYER_BULLET))
        {
            if (!goName.Contains(EnemyController.NAME_PLAYER_BULLET))
                UbhObjectPool.Instance.ReleaseGameObject(colTrans.parent.gameObject);

        }
        else
        if (goName.Equals(EnemyController.NAME_PLAYER) == false)
        {
            Destroy(colTrans.gameObject);
        }
    }
}
