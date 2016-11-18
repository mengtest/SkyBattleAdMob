using UnityEngine;
using System.Collections;

public enum BulletPath {line,sin};

[RequireComponent(typeof(Rigidbody2D))]
public class BulletController : MonoBehaviour {

    public BulletPath bullet_path;
    public float amblitude_sin_path = 1;
    public float speed_sin_path;
    public bool reverse;

    public float _Power;
    public float _Speed = 10;
    private Rigidbody2D rigi;
    private float a;
    void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        rigi.velocity = transform.up.normalized * _Speed;
    }

    void Update()
    {
        if (bullet_path == BulletPath.sin)
        {
           
            if (reverse)
                a = amblitude_sin_path * Mathf.Sin(Time.time * speed_sin_path);
            else
                a = amblitude_sin_path * Mathf.Sin(Time.time * speed_sin_path + 180);
            rigi.velocity = new Vector2(a, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

}
