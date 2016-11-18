using UnityEngine;
using System.Collections;

public class PointHoming : MonoBehaviour {

    [SerializeField]
    GameObject homing;
    [SerializeField]
    float shootDelay;
    // Use this for initialization
    IEnumerator Start()
    {
        while (true)
        {
            StartCoroutine("shoot");
            yield return new WaitForSeconds(shootDelay);
        }
    }

    // Update is called once per frame
    void shoot() {
        Instantiate(homing, transform.position, transform.rotation);
	}
}
