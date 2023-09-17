using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Dead()
    {
        animator.SetTrigger("Dead");
        PlayerController.instance.playerAttack.canAttack = false;
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 0.8f);
    }
}
