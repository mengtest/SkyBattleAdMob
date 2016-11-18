using UnityEngine;
using System.Collections;

public class HomingMissile : MonoBehaviour {

    public string targetTag;

	public GameObject target;
    public float distanceAttack;
	public float speedMove;

    private GameObject[] Targets;

    // Use this for initialization
    void Start () {
        //GetComponent<Rigidbody2D> ().gravityScale = 1;
    }
	
	// Update is called once per frame
	void Update () {

        if (target == null)
        {
            findTarget();
        }

        if (target != null)
        {
            Vector2 direction = (target.transform.position - transform.position).normalized;

            Vector2 desiredVelocity = direction * speedMove;
            Vector2 steeringForce = desiredVelocity - GetComponent<Rigidbody2D>().velocity;

            if (GetComponent<Rigidbody2D>().velocity.x < 0)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(steeringForce.x, steeringForce.y));
            }
            else
                GetComponent<Rigidbody2D>().AddForce(steeringForce);
        }
       


        float angleRad = Mathf.Atan2 (GetComponent<Rigidbody2D> ().velocity.y,
		                              GetComponent<Rigidbody2D> ().velocity.x);
		
		float angleDeg = (180 / Mathf.PI) * angleRad;
		transform.rotation = Quaternion.Euler (0, 0, angleDeg - 90);

	}

    void findTarget()
    {
        Targets = GameObject.FindGameObjectsWithTag(targetTag);
        if (Targets.Length != 0)
        {
            foreach (GameObject Target in Targets)
            {

                if (Vector2.Distance(transform.position, Target.transform.position) < distanceAttack)
                {
                    if (Target.GetComponent<Collider2D>() != null)
                        if (Target.GetComponent<Collider2D>().enabled == true)
                            this.target = Target;
                        else
                            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3);
                }
                else
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3);

            }
        }
        else
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3);

    }
	
}
