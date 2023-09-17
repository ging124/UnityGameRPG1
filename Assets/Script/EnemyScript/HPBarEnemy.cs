using UnityEngine;
using UnityEngine.UI;

public class HPBarEnemy : MonoBehaviour
{
    public Image bar;

    void Awake()
    {
        bar = GetComponent<Image>();
    }

    public void EnemyHpBar(int currentHp, int maxHp)
    {
        bar.fillAmount = (float)currentHp / maxHp;
    }
}
