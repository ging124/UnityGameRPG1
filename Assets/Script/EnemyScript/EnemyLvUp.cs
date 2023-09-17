using UnityEngine;
using TMPro;

public class EnemyLvUp : MonoBehaviour
{
    public TMP_Text enemyLv;
    public int levelEnemy = 1;
    public int currentExp;
    public int maxExp;
    public float lastExpGain = -99999;
    public float cooldown = 0.5f;
    private float levelGain = 1;
    private EnemyAttack enemyAttack;
    private EnemyHurt enemyHurt;

    void Awake()
    {
        enemyAttack = GetComponent<EnemyAttack>();
        enemyHurt = GetComponent<EnemyHurt>();
    }

    void Update()
    {
        if (Time.time > lastExpGain + cooldown)
        {
            cooldown = 15 / levelGain;
            levelGain += 7*Time.deltaTime;
            ExpGain(1);
            lastExpGain = Time.time;
        }
    }

    public void EnemyLevelUp()
    {
        levelEnemy++;
        enemyLv.text = levelEnemy.ToString();
        enemyAttack.attackDamage++;
        enemyHurt.maxHp +=  20*levelEnemy;
        enemyHurt.currentHp = enemyHurt.maxHp;
        currentExp = 0;
        maxExp = (int)(0.4f * Mathf.Pow((float)levelEnemy, 2f) + 0.8 * Mathf.Pow((float)levelEnemy, 2f) + 2 * levelEnemy);
    }

    public void ExpGain(int exp)
    {
        currentExp += exp;
        if (currentExp >= maxExp)
        {
            EnemyLevelUp();
        }
    }
}
