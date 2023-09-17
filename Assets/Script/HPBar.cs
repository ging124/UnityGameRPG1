using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{

    public Image bar;

    void Awake()
    {
        bar = GetComponent<Image>();
    }

    void Update()
    {
        HPBarUpdate(PlayerController.instance.playerHurt.currentHp, PlayerController.instance.playerHurt.maxHp);
    }

    public void HPBarUpdate(int HP,int maxHP)
    {
        bar.fillAmount = (float)HP / maxHP;
    }
}
