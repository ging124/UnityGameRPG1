using UnityEngine;
using TMPro;

public class UpdateLightningSkill : MonoBehaviour
{
    private TMP_Text lightningSkillText;
    [SerializeField]
    private int lightningSkillPoint;
    [SerializeField]
    private int pointSkill;

    void Awake()
    {
        lightningSkillText = GameObject.Find("LightningSkill_Point").GetComponent<TMP_Text>();
    }

    public void ButtonPressed()
    {
        pointSkill = int.Parse(SkillPoint.instance.pointSkill.text);
        lightningSkillPoint++;
        pointSkill--;
        // increase fire skill damage;
        lightningSkillText.text = lightningSkillPoint.ToString();
        SkillPoint.instance.pointSkill.text = pointSkill.ToString();
        SkillPoint.instance.chooseLightningSkill = true;
    }
}
