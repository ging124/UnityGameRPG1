using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    public int attackDamage;
    [SerializeField]
    private float attackRange = 0.5f;
    [SerializeField]
    private GameObject attackPoint;
    [SerializeField]
    private GameObject slashEffectFront;
    [SerializeField]
    private GameObject slashEffectBack;
    [SerializeField]
    private GameObject slashEffectLeft;
    private float cooldown = 0.5f;
    private float lastAttackedAt = -9999f;
    public LayerMask enemyLayer;
    public bool canAttack = true;

    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Time.time > lastAttackedAt + cooldown)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                Attack();
                lastAttackedAt = Time.time;
            }
        }
    }

    void Attack()
    {
        if(canAttack)
        {
            animator.SetTrigger("Attack");
            SlashEffect();
            Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRange, enemyLayer);
            foreach (Collider2D enemy in hitEnemy)
            {
                enemy.GetComponent<EnemyController>().enemyHurt.TakeDamage(attackDamage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, attackRange);
    }

    void SlashEffect()
    {
        if (animator.GetFloat("Vertical") == -1)
        {
            Instantiate(slashEffectFront, transform.position, Quaternion.identity);
        }
        else if (animator.GetFloat("Vertical") == 1)
        {
            Instantiate(slashEffectBack, transform.position, Quaternion.identity);
        }
        else if (animator.GetFloat("Horizontal") == -1)
        {
            Instantiate(slashEffectLeft, transform.position, Quaternion.identity);
        }
        else if (animator.GetFloat("Horizontal") == 1)
        {
        }

    }
}
