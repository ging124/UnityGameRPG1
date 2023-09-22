using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public int attackDamage = 10;
    [SerializeField]
    private float attackRange = 0.5f;
    [SerializeField]
    private GameObject attackPoint;
    private float cooldown = 0.5f;
    private float lastAttackedAt = -9999f;
    public LayerMask playerLayer;
    public bool canAttack = true;
    public Collider2D hitPlayer;

    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Time.time > lastAttackedAt + cooldown)
        {
            Attack();
            lastAttackedAt = Time.time;
        }
    }

    void Attack()
    {
        if(canAttack)
        {
            hitPlayer = Physics2D.OverlapCircle(attackPoint.transform.position, attackRange, playerLayer);
            if (hitPlayer != null)
            {
                animator.SetTrigger("Attack");
                hitPlayer.GetComponent<PlayerHurt>().TakeDamage(attackDamage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.transform.position, attackRange);
    }
}
