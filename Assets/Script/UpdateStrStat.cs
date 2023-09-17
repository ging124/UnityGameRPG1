using UnityEngine;
using TMPro;

public class UpdateStrStat : MonoBehaviour
{
    private TMP_Text strText;
    [SerializeField]
    private int strPoint;
    [SerializeField]
    private int pointAbility;

    void Awake()
    {
        strText = GameObject.Find("STR_Text").GetComponent<TMP_Text>();
    }

    public void ButtonPressed()
    {
        pointAbility = int.Parse(AbilityPoint.instance.pointAbility.text);
        strPoint++;
        pointAbility--;
        PlayerStats.instance.strength++;
        strText.text = strPoint.ToString();
        AbilityPoint.instance.pointAbility.text = pointAbility.ToString();
    }
}
