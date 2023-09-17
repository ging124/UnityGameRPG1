using UnityEngine;
using TMPro;

public class UpdateFireSkill : MonoBehaviour
{
    private TMP_Text fireSkillText;
    [SerializeField]
    private int fireSkillPoint;
    [SerializeField]
    private int pointSkill;

    void Awake()
    {
        fireSkillText = GameObject.Find("FireSkill_Point").GetComponent<TMP_Text>();
    }

    public void ButtonPressed()
    {
        pointSkill = int.Parse(SkillPoint.instance.pointSkill.text);
        fireSkillPoint++;
        pointSkill--;
        // increase fire skill damage;
        fireSkillText.text = fireSkillPoint.ToString();
        SkillPoint.instance.pointSkill.text = pointSkill.ToString();
        SkillPoint.instance.chooseFireSkill = true;
    }
}
