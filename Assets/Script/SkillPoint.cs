using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkillPoint : MonoBehaviour
{
    public TMP_Text pointSkill;
    public TMP_Text fireSkillPoint;
    public TMP_Text waterSkillPoint;
    public TMP_Text lightningSkillPoint;
    public TMP_Text shadowSkillPoint;
    private Button fireSkillButton;
    private Button waterSkillButton;
    private Button lightningSkillButton;
    private Button shadowSkillButton;
    public bool chooseFireSkill = false;
    public bool chooseWaterSkill = false;
    public bool chooseLightningSkill = false;
    public bool chooseShadowSkill = false;

    static public SkillPoint instance;

    void Awake()
    {
        SkillPoint.instance = this;
        pointSkill = GameObject.Find("SkillPoint_Text").GetComponent<TMP_Text>();
        fireSkillPoint = GameObject.Find("FireSkill_Point").GetComponent<TMP_Text>();
        waterSkillPoint = GameObject.Find("WaterSkill_Point").GetComponent<TMP_Text>();
        lightningSkillPoint = GameObject.Find("LightningSkill_Point").GetComponent<TMP_Text>();
        shadowSkillPoint = GameObject.Find("ShadowSkill_Point").GetComponent<TMP_Text>();
        fireSkillButton = GameObject.Find("Button_FireSkill").GetComponent<Button>();
        waterSkillButton = GameObject.Find("Button_WaterSkill").GetComponent<Button>();
        lightningSkillButton = GameObject.Find("Button_LightningSkill").GetComponent<Button>();
        shadowSkillButton = GameObject.Find("Button_ShadowSkill").GetComponent<Button>();
    }

    void Update()
    {
        if (int.Parse(pointSkill.text) == 0)
        {
            ActiveButton(false);
        }
        else
        {
            if(chooseFireSkill)
            {
                ChooseFireSkill();
            }
            else if(chooseWaterSkill)
            {
                ChooseWaterSkill();
            }
            else if(chooseLightningSkill)
            {
                ChooseLightningSkill();
            }
            else if(chooseShadowSkill)
            {
                ChooseShadowSkill();
            }
            else
            {
                ActiveButton(true);
            }
        }
    }

    void ActiveButton(bool active)
    {
        if (active == true)
        {
            fireSkillButton.interactable = true;
            waterSkillButton.interactable = true;
            lightningSkillButton.interactable = true;
            shadowSkillButton.interactable = true;
        }
        else
        {
            fireSkillButton.interactable = false;
            waterSkillButton.interactable = false;
            lightningSkillButton.interactable = false;
            shadowSkillButton.interactable = false;
        }
    }

    void ChooseFireSkill()
    {
        fireSkillButton.interactable = true;
        waterSkillButton.interactable = false;
        lightningSkillButton.interactable = false;
        shadowSkillButton.interactable = false;
    }

    void ChooseWaterSkill()
    {
        fireSkillButton.interactable = false;
        waterSkillButton.interactable = true;
        lightningSkillButton.interactable = false;
        shadowSkillButton.interactable = false;
    }

    void ChooseLightningSkill()
    {
        fireSkillButton.interactable = false;
        waterSkillButton.interactable = false;
        lightningSkillButton.interactable = true;
        shadowSkillButton.interactable = false;
    }

    void ChooseShadowSkill()
    {
        fireSkillButton.interactable = false;
        waterSkillButton.interactable = false;
        lightningSkillButton.interactable = false;
        shadowSkillButton.interactable = true;
    }
}
