using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {

    public Collider2D[] listBoss;
    private float hpMax;
    private float savePos;
    [HideInInspector]
    public bool startBoss;

	// Use this for initialization
	void Start () {
        savePos = transform.position.x;
    }

    public void setupBoss(float hp,bool startBoss)
    {
        this.hpMax = hp;
        this.startBoss = startBoss;
        Debug.Log(hp + "");
    }

    public void updateHpBoss(float hp)
    {
        if (startBoss)
        {
            if (hp >= hpMax * 2 / 3)
            {
                activeBoss(0);
            }

            if (hp < hpMax * 2 / 3 && hp >= hpMax / 3)
            {
                activeBoss(1);
            }

            if (hp < hpMax / 3)
            {
                activeBoss(2);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector2(savePos + Mathf.Sin(Time.time), transform.position.y);

    }

    void activeBoss(int index)
    {
        for (int i = 0; i < listBoss.Length; i++)
        {
            if (index == i)
            {
                UbhShotCtrl ubh = listBoss[i].GetComponent<UbhShotCtrl>();
                if (listBoss[i].enabled != true)
                {
                    listBoss[i].enabled = true;
                    ubh.enabled = true;
                    ubh.StartShotRoutine();
                }
            }
            else
            {
                UbhShotCtrl ubh = listBoss[i].GetComponent<UbhShotCtrl>();
                if (listBoss[i].enabled != false)
                {
                    listBoss[i].GetComponent<PlaneDie>().Explosion();
                    listBoss[i].enabled = false;
                    ubh.StopShotRoutine();
                    ubh.enabled = false;
                }
            }
        }
    }
}
