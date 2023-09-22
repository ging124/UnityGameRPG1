using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    static public PlayerController instance;
    public PlayerMovement playerMovement;
    public PlayerAttack playerAttack;
    public PlayerHurt playerHurt;
    public PlayerLvUp playerLvUp;
    public PlayerStats playerStats;
    public PlayerHeal playerHeal;

    public GameObject model;
    public Animator animator;
    public Rigidbody2D rb;

    void Awake()
    {
        PlayerController.instance = this;
        playerMovement = GameObject.Find("PlayerMovement").GetComponent<PlayerMovement>();
        playerAttack = GameObject.Find("PlayerAttack").GetComponent<PlayerAttack>();
        playerHurt = GameObject.Find("PlayerHurt").GetComponent<PlayerHurt>();
        playerLvUp = GameObject.Find("PlayerLevel").GetComponent<PlayerLvUp>();
        playerStats = GameObject.Find("PlayerStats").GetComponent<PlayerStats>();
        playerHeal = GameObject.Find("PlayerHeal").GetComponent<PlayerHeal>();

        model = GameObject.Find("PlayerModel");
        animator = model.GetComponent<Animator>();
        rb = GetComponentInParent<Rigidbody2D>();
    }
}
