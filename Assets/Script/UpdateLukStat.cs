using UnityEngine;
using TMPro;

public class UpdateLukStat : MonoBehaviour
{
    private TMP_Text lukText;
    [SerializeField]
    private int lukPoint;
    [SerializeField]
    private int pointAbility;

    void Awake()
    {
        lukText = GameObject.Find("LUK_Text").GetComponent<TMP_Text>();
    }

    public void ButtonPressed()
    {
        pointAbility = int.Parse(AbilityPoint.instance.pointAbility.text);
        lukPoint++;
        pointAbility--;
        PlayerStats.instance.luck++;
        lukText.text = lukPoint.ToString();
        AbilityPoint.instance.pointAbility.text = pointAbility.ToString();
    }
}
