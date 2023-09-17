using UnityEngine;

public class PlayerHeal : MonoBehaviour
{
    [SerializeField]
    private int hpHeal = 20;
    public GameObject heal;
    public bool isHeal = false;

    void Awake()
    {
        heal.SetActive(false);
    }

    void Update()
    {
        if (isHeal == true)
        {
            Invoke("StopHeal", 1f);
        }
    }

    public void Heal()
    {
        heal.SetActive(true);
        isHeal = true;
        if (PlayerController.instance.playerHurt.currentHp + hpHeal <= PlayerController.instance.playerHurt.maxHp)
        {
            PlayerController.instance.playerHurt.currentHp += hpHeal;
        }
        else
        {
            PlayerController.instance.playerHurt.currentHp = PlayerController.instance.playerHurt.maxHp;
        }
    }

     void StopHeal()
    {
        heal.SetActive(false);
        isHeal = false;
    }
}
