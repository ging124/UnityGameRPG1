using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    static public EnemyController instance;
    public FollowPlayer followPlayer;
    public EnemyAttack enemyAttack;
    public EnemyHurt enemyHurt;
    public EnemyLvUp enemyLvUp;

    // Start is called before the first frame update
    void Awake()
    {
        EnemyController.instance = this;
        followPlayer = GetComponent<FollowPlayer>();
        enemyAttack = GetComponent<EnemyAttack>();
        enemyHurt = GetComponent<EnemyHurt>();
        enemyLvUp = GetComponent<EnemyLvUp>();
    }
}
