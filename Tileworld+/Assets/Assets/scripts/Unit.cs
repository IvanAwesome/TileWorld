using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Unit : MonoBehaviour
{

	public string unitName;
	public int unitLevel;

	public int damage;


	public int maxHP;
	public int currentHP;

	public GameObject dialogue;
	


	public bool TakeDamage(int dmg)
	{
		dmg = Random.Range(1, 25);

		currentHP = Mathf.Max(currentHP - dmg, 0);

		if (currentHP == 0)
			return true;
		else
			return false;
	}

	public void Heal(int amount)
	{
		currentHP += amount;
		if (currentHP > maxHP)
			currentHP = maxHP;
	}

}
