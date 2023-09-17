using UnityEngine;
using TMPro;

public class EnemyHurt : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    public int currentHp;
    [SerializeField]
    public int maxHp = 10;
    private Material matWhite;
    private Material matDefault;
    [SerializeField]
    SpriteRenderer sr;
    [SerializeField]
    private TMP_Text damageText;
    [SerializeField]
    private GameObject hitEffect;

    public EnemyDead enemyDead;
    public HPBarEnemy hpBarEnemy;

    void Awake()
    {
        animator = GetComponent<Animator>();
        enemyDead = GetComponent<EnemyDead>();
        hpBarEnemy = GetComponentInChildren<HPBarEnemy>();
        sr = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;
        currentHp = maxHp;
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        Vector3 hitEffectPosition = new Vector3(transform.position.x, transform.position.y + 0.1f, 0);
        Instantiate(hitEffect, hitEffectPosition , Quaternion.identity);
        Vector3 textPopup = new Vector3(transform.position.x + Random.Range(-0.05f, 0.05f), transform.position.y + 0.2f, 0);
        TMP_Text text = Instantiate(damageText, textPopup, Quaternion.identity);
        text.GetComponent<TMP_Text>().text = damage.ToString();
        animator.SetTrigger("Hurt");
        sr.material = matWhite;
        Invoke("ResetMaterial", 0.2f);
        hpBarEnemy.EnemyHpBar(currentHp, maxHp);
        if (currentHp <= 0)
        {
            enemyDead.Dead();
        }
    }

    void ResetMaterial()
    {
        sr.material = matDefault;
    }

}
