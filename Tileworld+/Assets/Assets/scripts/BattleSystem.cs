using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

	public GameObject playerPrefab;
	public GameObject enemyPrefab;

	public Transform playerBattleStation;
	public Transform enemyBattleStation;

	Unit playerUnit;
	Unit enemyUnit;

	public Text dialogueText;

	public BattleHUD playerHUD;
	public BattleHUD enemyHUD;

	public BattleState state;

    // Start is called before the first frame update
    void Start()
    {
		state = BattleState.START;
		StartCoroutine(SetupBattle());
    }

	IEnumerator SetupBattle()
	{
		GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
		playerUnit = playerGO.GetComponent<Unit>();

		GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
		enemyUnit = enemyGO.GetComponent<Unit>();

		dialogueText.text = "A wild " + enemyUnit.unitName + " approaches...";

		playerHUD.SetHUD(playerUnit);
		enemyHUD.SetHUD(enemyUnit);

		yield return new WaitForSeconds(1f);

		state = BattleState.PLAYERTURN;
		PlayerTurn();
	}

	IEnumerator PlayerAttack()
	{
		bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

		enemyHUD.SetHP(enemyUnit.currentHP);
		dialogueText.text = "The attack is successful!";

		yield return new WaitForSeconds(0f);

		if(isDead)
		{
			state = BattleState.WON;
			StartCoroutine(EndBattle());
		} else
		{
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
		}
	}

	IEnumerator EnemyTurn()
	{
		dialogueText.text = enemyUnit.unitName + " attacks!";

		yield return new WaitForSeconds(0.75f);

		bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

		playerHUD.SetHP(playerUnit.currentHP);

		yield return new WaitForSeconds(1f);

		if(isDead)
		{
			state = BattleState.LOST;
			StartCoroutine(EndBattle());
		} else
		{
			state = BattleState.PLAYERTURN;
			PlayerTurn();
		}

	}

	IEnumerator EndBattle()
	{
		Debug.Log("ah");
		if(state == BattleState.WON)
		{
			if (enemyUnit.currentHP == 0)
			{
				dialogueText.text = "You won the battle!";
				yield return new WaitForSeconds(3f);
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			}
		} 
		else if(state == BattleState.LOST)
		{
			if (playerUnit.currentHP == 0)
            {
				dialogueText.text = "You were defeated.";
				yield return new WaitForSeconds(3f);
				SceneManager.LoadScene("gameover");
			}
	
		}
	}

	void PlayerTurn()
	{
		dialogueText.text = "Choose an action:";
	}

	IEnumerator PlayerHeal()
	{
		playerUnit.Heal(11);

		playerHUD.SetHP(playerUnit.currentHP);
		dialogueText.text = "You regenerate unnaturally!";

		yield return new WaitForSeconds(0f);

		state = BattleState.ENEMYTURN;
		StartCoroutine(EnemyTurn());
	}

	public void OnAttackButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerAttack());
	}

	public void OnHealButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerHeal());
	}

}
