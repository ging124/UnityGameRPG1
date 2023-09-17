using UnityEngine;
using TMPro;

public class UpdateIntStat : MonoBehaviour
{
    private TMP_Text intText;
    [SerializeField]
    private int intPoint;
    [SerializeField]
    private int pointAbility;

    void Awake()
    {
        intText = GameObject.Find("INT_Text").GetComponent<TMP_Text>();
    }

    public void ButtonPressed()
    {
        pointAbility = int.Parse(AbilityPoint.instance.pointAbility.text);
        intPoint++;
        pointAbility--;
        PlayerStats.instance.intelligence++;
        intText.text = intPoint.ToString();
        AbilityPoint.instance.pointAbility.text = pointAbility.ToString();
    }
}
