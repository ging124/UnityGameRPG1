using UnityEngine;

public class HeartPickUp : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Player")
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            PlayerController.instance.playerHeal.Heal();
            Destroy(gameObject);
        }
    }
}
