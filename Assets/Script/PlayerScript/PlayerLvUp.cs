using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerLvUp : MonoBehaviour
{
    public int currentExp = 0;
    public int maxExp = 3;
    private int pointAbility;
    private int pointSkill;
    public int level = 1;
    [SerializeField]
    private Image lvBar;

    void Awake()
    {
        lvBar = GameObject.Find("Exp_Base").GetComponent<Image>();
    }

    void Update()
    {
        pointAbility = int.Parse(AbilityPoint.instance.pointAbility.text);
        pointSkill = int.Parse(SkillPoint.instance.pointSkill.text);
    }

    public void ExpGain(int exp)
    {
        currentExp += exp;
        if (currentExp >= maxExp)
        {
            LevelUp();
        }
        lvBar.fillAmount = (float)currentExp / maxExp;
    }

    void LevelUp()
    {
        level++;
        PlayerController.instance.playerAttack.attackDamage += 1;
        currentExp = 0;
        maxExp = (int)(0.4f * Mathf.Pow((float)level, 2f) + 0.8 * Mathf.Pow((float)level, 2f) + 2 * level);
        pointAbility += 3;
        pointSkill += 1;
        AbilityPoint.instance.pointAbility.text = pointAbility.ToString();
        SkillPoint.instance.pointSkill.text = pointSkill.ToString();
    }
}
