using UnityEngine;
using System.Collections;

public class PlaneDie : MonoBehaviour {

    [SerializeField]
    GameObject _ExplosionPrefab;

    void Start()
    {
        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
            col.isTrigger = true;
    }

    public void Explosion()
    {
        if (_ExplosionPrefab != null)
        {
            Instantiate(_ExplosionPrefab, transform.position, transform.rotation);
            SoundManager.instance.playSoundExplode_1();
        }
    }

}
