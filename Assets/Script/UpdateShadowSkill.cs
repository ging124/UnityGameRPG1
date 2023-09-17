using UnityEngine;
using TMPro;

public class UpdateShadowSkill : MonoBehaviour
{
    private TMP_Text shadowSkillText;
    [SerializeField]
    private int shadowSkillPoint;
    [SerializeField]
    private int pointSkill;

    void Awake()
    {
        shadowSkillText = GameObject.Find("ShadowSkill_Point").GetComponent<TMP_Text>();
    }

    public void ButtonPressed()
    {
        pointSkill = int.Parse(SkillPoint.instance.pointSkill.text);
        shadowSkillPoint++;
        pointSkill--;
        // increase fire skill damage;
        shadowSkillText.text = shadowSkillPoint.ToString();
        SkillPoint.instance.pointSkill.text = pointSkill.ToString();
        SkillPoint.instance.chooseShadowSkill = true;
    }
}
