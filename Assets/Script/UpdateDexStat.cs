using UnityEngine;
using TMPro;

public class UpdateDexStat : MonoBehaviour
{
    private TMP_Text dexText;
    [SerializeField]
    private int dexPoint;
    [SerializeField]
    private int pointAbility;
    void Awake()
    {
        dexText = GameObject.Find("DEX_Text").GetComponent<TMP_Text>();
    }

    public void ButtonPressed()
    {
        pointAbility = int.Parse(AbilityPoint.instance.pointAbility.text);
        dexPoint++;
        pointAbility--;
        PlayerStats.instance.dexterity++;
        dexText.text = dexPoint.ToString();
        AbilityPoint.instance.pointAbility.text = pointAbility.ToString();
    }
}
