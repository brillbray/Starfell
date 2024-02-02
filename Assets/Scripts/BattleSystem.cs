using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public BattleState state;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerPos;
    public Transform enemyPos;

    Unit playerUnit;
    Unit enemyUnit;

    public Text dialogueText;
    public Animator playerAnimator;
    public Animator enemyAnimator;
    public Button atkBtn;
    private bool shouldAttack = false;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD; 

    public GameObject youWinText;
    public GameObject gameOverText;
    private bool attackButtonClicked = false;
    public SwitchScreen switchScreen;

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
        AudioManager.Instance.PlayFightBGM();
        AudioManager.Instance.sfxSource.volume = 1f;
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerPos);
        playerUnit = playerGO.GetComponent<Unit>();
        playerAnimator = playerGO.GetComponent<Animator>();

        yield return new WaitForSeconds(1f);

        GameObject enemyGO = Instantiate(enemyPrefab, enemyPos);
        enemyUnit = enemyGO.GetComponent<Unit>();
        enemyAnimator = enemyGO.GetComponent<Animator>();

        dialogueText.text = enemyUnit.unitName + " approaches!";
        yield return new WaitForSeconds(1f); 
     
        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void Update()
    {
        if (shouldAttack)
        {
            shouldAttack = false;

            if (!attackButtonClicked)
            {
                attackButtonClicked = true;
                OnAttackButton();
            }
        }
    }

    void PlayerTurn()
    {
        dialogueText.text = "Click Attack Button to defeat enemies!";
    }

    public void OnAttackButton()
    {
        if (state == BattleState.PLAYERTURN && !attackButtonClicked)
        {
            StartCoroutine(PlayerAttack());
            AudioManager.Instance.PlaySFX("SwordMC");
            atkBtn.interactable = false;
            attackButtonClicked = true;
        }
    }

    IEnumerator PlayerAttack()
    {
        playerAnimator.SetBool("Attack", true);
        playerAnimator.SetBool("Idle", false); 
        
        enemyAnimator.SetBool("Attack", false);
        enemyAnimator.SetBool("Idle", true); 
      
        yield return new WaitForSeconds(.8f);

        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        dialogueText.text = "You dealt " + playerUnit.damage + " damage to " + enemyUnit.unitName;
		enemyHUD.SetHP(enemyUnit.currentHP);

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
            dialogueText.text = "";

            yield return new WaitForSeconds(2f);
         
            switchScreen.SwitchSceneName();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
            attackButtonClicked = false;
        }
    }

    IEnumerator EnemyTurn()
    {
        playerAnimator.SetBool("Attack", false);
        playerAnimator.SetBool("Idle", true); 

        enemyAnimator.SetBool("Attack", true);
        enemyAnimator.SetBool("Idle", false); 
        AudioManager.Instance.PlaySFX("EnemySFX");
        yield return new WaitForSeconds(.8f);

        dialogueText.text = enemyUnit.unitName + " attacks " + playerUnit.unitName;

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
		playerHUD.SetHP(playerUnit.currentHP);

        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
            atkBtn.interactable = true;
        }
    }

    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            youWinText.SetActive(true);
        }  
        else if (state == BattleState.LOST)
        {
            gameOverText.SetActive(true);
        }
    }
}
