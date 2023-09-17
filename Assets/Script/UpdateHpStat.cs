using UnityEngine;
using TMPro;

public class UpdateHpStat : MonoBehaviour
{
    private TMP_Text hpText;
    [SerializeField]
    private int hpPoint;
    [SerializeField]
    private int pointAbility;

    void Awake()
    {
        hpText = GameObject.Find("HP_Text").GetComponent<TMP_Text>();
    }

    public void ButtonPressed()
    {
        pointAbility = int.Parse(AbilityPoint.instance.pointAbility.text);
        hpPoint++;
        pointAbility--;
        PlayerController.instance.playerHurt.maxHp += 10;
        hpText.text = hpPoint.ToString();
        AbilityPoint.instance.pointAbility.text = pointAbility.ToString();
    }
}
