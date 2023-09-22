using Unity.VisualScripting;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    public void Dead()
    {
        PlayerController.instance.playerHurt.GetComponent<PlayerHurt>().enabled = false;
        PlayerController.instance.playerMovement.GetComponent<PlayerMovement>().enabled = false;
        PlayerController.instance.playerAttack.canAttack = false;
        PlayerController.instance.animator.SetTrigger("Dead");
        Destroy(transform.parent.gameObject, 1f);
    }
}
