using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour {

    public float timeDestroy;
	// Use this for initialization
	IEnumerator Start () {
        yield return new WaitForSeconds(timeDestroy);
        Destroy(gameObject);
	}
	
}
