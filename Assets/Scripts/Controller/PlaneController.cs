using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

[RequireComponent (typeof(PlaneDie))]
public class PlaneController : MonoBehaviour
{
	public const string NAME_ENEMY_BULLET = "EnemyBullet";
	public const string NAME_ENEMY = "Enemy";
	public bool isShield;
	public float distanceToHand;
    [HideInInspector]
    public float HPmax;
    [HideInInspector]
    public float preHP;

    private GameManager _gameManager;
    private PlaneDie planeDie;
	private bool canController;
	private float speedMove;

	// Use this for initialization
	void Start ()
	{
		HPmax = GameSetting.armor_plane;
		preHP = HPmax;

		speedMove = GameSetting.speed_plane;

		_gameManager = GameSetting._gameManager;
		planeDie = GetComponent<PlaneDie> ();
		canController = true;
	}

	// Update is called once per frame
	void Update ()
	{
		if (_gameManager.gameState == GameState.Play) {
			move ();
		}
	}

	void move ()
	{
		//if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject() && canController)
		#if (UNITY_ANDROID || UNITY_IPHONE) && !UNITY_EDITOR
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId) && canController)
        {

            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y + distanceToHand));
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                //_gameManager._uiManager.slowGame(false);
                transform.position = Vector2.Lerp(transform.position, touchPosition, speedMove * Time.deltaTime);
            }
            else
            {
               
            }

        }
		#elif UNITY_EDITOR

		if (Input.GetMouseButton (0) && !EventSystem.current.IsPointerOverGameObject () && canController) {

			Vector2 touchPosition = Camera.main.ScreenToWorldPoint (new Vector2 (Input.mousePosition.x, Input.mousePosition.y + distanceToHand));
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);

			if (hit.collider != null) {
				transform.position = Vector2.Lerp (transform.position, touchPosition, speedMove * Time.deltaTime);
			} else {

			}
		}
		#endif
	}

	public void add_HP (int hp)
	{
		preHP += hp;
		if (preHP > HPmax) {
			preHP = HPmax;
		}
        _gameManager._uiManager.updateHP();
    }

	public void activeShield (bool check)
	{
		isShield = check;
	}

	void OnTriggerEnter2D (Collider2D c)
	{
		if (!isShield)
			HitCheck (c.transform);
	}

	IEnumerator revival ()
	{
		preHP = HPmax;
		_gameManager._uiManager.updateHP ();
		GetComponent<SupportManager> ().resetSupport ();

		activeShield (true);
		canController = false;
		Color color_plane = new Color ();
		color_plane.a = 0.5f;
		color_plane.b = 1;
		color_plane.g = 1;
		color_plane.r = 1;
		transform.GetChild (0).GetComponent<SpriteRenderer> ().color = color_plane;

		yield return new WaitForSeconds (1);
		canController = true;
		yield return new WaitForSeconds (1);
		activeShield (false);
		color_plane.a = 1;
		transform.GetChild (0).GetComponent<SpriteRenderer> ().color = color_plane;

	}

	void HitCheck (Transform colTrans)
	{
		// *It is compared with name in order to separate as Asset from project settings.
		//  However, it is recommended to use Layer or Tag.
		string goName = colTrans.name;
		if (goName.Equals (NAME_ENEMY_BULLET) && _gameManager.gameState == GameState.Play) {
			UbhObjectPool.Instance.ReleaseGameObject (colTrans.parent.gameObject);
			preHP--;
			_gameManager._uiManager.updateHP ();
			takeDame ();
		}

        if (colTrans.tag == NAME_ENEMY && _gameManager.gameState == GameState.Play)
        {
            if (colTrans.GetComponent<EnemyController>() != null)
                if (colTrans.GetComponent<EnemyController>()._Hp > HPmax)
                {
                    preHP = 0;
                    takeDame();
                }
                else {
                    preHP--;
                    _gameManager._uiManager.updateHP();
                    takeDame();
                }
            else
            {
                preHP = 0;
                takeDame();
            }
        }
	}

	void takeDame ()
	{
		if (preHP <= 0) {
            planeDie.Explosion();
            if (GameSetting.instance.getLife ()) {
                StartCoroutine(revival());
                Transform pointGen = GameObject.Find ("pointGenPlayer").transform;
				transform.position = pointGen.position;
				_gameManager._uiManager.updateData ();
			} else if (_gameManager != null) {
				_gameManager.gameOver ();
				Destroy (gameObject);
			}
		}
	}

}
