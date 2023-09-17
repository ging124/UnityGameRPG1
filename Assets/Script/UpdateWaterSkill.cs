using UnityEngine;
using TMPro;

public class UpdateWaterSkill : MonoBehaviour
{
    private TMP_Text waterSkillText;
    [SerializeField]
    private int waterSkillPoint;
    [SerializeField]
    private int pointSkill;

    void Awake()
    {
        waterSkillText = GameObject.Find("WaterSkill_Point").GetComponent<TMP_Text>();
    }

    public void ButtonPressed()
    {
        pointSkill = int.Parse(SkillPoint.instance.pointSkill.text);
        waterSkillPoint++;
        pointSkill--;
        // increase fire skill damage;
        waterSkillText.text = waterSkillPoint.ToString();
        SkillPoint.instance.pointSkill.text = pointSkill.ToString();
        SkillPoint.instance.chooseWaterSkill = true;
    }
}
