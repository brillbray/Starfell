using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}
public class BattleSystem : MonoBehaviour
{
    public BattleState state;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerPos;
    public Transform enemyPos;

    EnemyUiController playerUnit;
    EnemyUiController enemyUnit;

    void Start(){
        state = BattleState.START;
        SetupBattle();
    }

    void SetupBattle(){
        GameObject playerGO = Instantiate(playerPrefab, playerPos);
        playerUnit = playerGO.GetComponent<EnemyUiController>();
        GameObject enemyGO = Instantiate(enemyPrefab, enemyPos);
    }
}
