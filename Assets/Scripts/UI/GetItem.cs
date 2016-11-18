using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetItem : MonoBehaviour
{

	public GameObject bombPanel;
	public GameObject moneyPanel;
	public Text moneyText,bombText;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void GetItemFree ()
	{
		int money = PlayerPrefs.GetInt (MenuScript.MONEY_KEY);
		money += 10;
		PlayerPrefs.SetInt (MenuScript.MONEY_KEY, money);

		moneyText.text = money.ToString ();
	}

	public void ShowRewardVideo ()
	{
		AdsControl.Instance.ShowRewardVideo ();
	}

	public void BuyBomb ()
	{
		int money = PlayerPrefs.GetInt (MenuScript.MONEY_KEY);
		int bomb = PlayerPrefs.GetInt (MenuScript.BOOM_KEY);
		if (money >= 100) {
			bomb++;
			PlayerPrefs.SetInt (MenuScript.BOOM_KEY, bomb);
			money -= 100;
			PlayerPrefs.SetInt (MenuScript.MONEY_KEY, money);
			bombText.text = bomb.ToString ();
			moneyText.text = money.ToString ();
		}
	}

	public void ShowMoney ()
	{
		moneyPanel.SetActive (true);
	}

	public void ShowBomb ()
	{
		bombPanel.SetActive (true);	
	}

	public void CloseMoney ()
	{
		moneyPanel.SetActive (false);
	}

	public void CloseBomb ()
	{
		bombPanel.SetActive (false);
	}
}
