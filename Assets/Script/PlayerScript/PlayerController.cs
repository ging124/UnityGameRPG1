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

    void Awake()
    {
        PlayerController.instance = this;
        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponent<PlayerAttack>();
        playerHurt = GetComponent<PlayerHurt>();
        playerLvUp = GetComponent<PlayerLvUp>();
        playerStats = GetComponent<PlayerStats>();
        playerHeal = GetComponent<PlayerHeal>();
    }
}
