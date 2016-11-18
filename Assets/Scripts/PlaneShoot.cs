using UnityEngine;
using System.Collections;

public class PlaneShoot : MonoBehaviour {

    public float shootDelay;
    public int countWave;
    [SerializeField]
    public GameObject bulletPrefab;
    public bool soundShoot;


    // Use this for initialization
    void OnEnable () {
        StartCoroutine(startShoot());
    }

    IEnumerator startShoot()
    {
        while (true)
        {
            StartCoroutine("shoot");
            yield return new WaitForSeconds(shootDelay);
        }
    }

    // Update is called once per frame
    void Update () {
	
	}

    IEnumerator shoot()
    {
        for (int i = 0; i < countWave; i++)
        {
            if (bulletPrefab != null)
                UbhObjectPool.Instance.GetGameObject(bulletPrefab, transform.position, transform.rotation);
            if (soundShoot && SoundManager.instance != null)
                SoundManager.instance.playSoundShoot_1();
            yield return new WaitForSeconds(0.05f);
        }
    }
}
