using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject heartPrefab;
    private int exp = 1;
    [SerializeField]
    private float dropRate = 0.02f;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Dead()
    {
        animator.SetTrigger("Dead");
        GetComponent<Collider2D>().enabled = false;
        GetComponent<FollowPlayer>().enabled = false;
        GetComponent<EnemyAttack>().enabled = false;
        PlayerController.instance.playerLvUp.ExpGain(exp);
        Destroy(gameObject, 1f);
        if (Random.Range(0f, 1f) <= dropRate)
        {
            GameObject heart = Instantiate(heartPrefab, transform.position, Quaternion.identity);
        }
    }
}