using UnityEngine;
using System.Collections;

public class Shadow : MonoBehaviour {

    public Vector2 pointLight = new Vector2(-5,100);

    private Vector2 abc;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        abc = (Vector2)transform.position - pointLight;
        abc = abc.normalized;
        transform.position = new Vector2(transform.parent.position.x - Mathf.Abs(abc.x), transform.parent.position.y - Mathf.Abs(abc.y));
	}
}
