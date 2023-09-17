using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AbilityPoint : MonoBehaviour
{
    public TMP_Text pointAbility;
    private Button hpButton;
    private Button strButton;
    private Button dexButton;
    private Button intButton;
    private Button lukButton;

    static public AbilityPoint instance;

    void Awake()
    {
        pointAbility = GameObject.Find("Point_Text").GetComponent<TMP_Text>();
        hpButton = GameObject.Find("Button_Hp").GetComponent<Button>();
        strButton = GameObject.Find("Button_Str").GetComponent<Button>();
        dexButton = GameObject.Find("Button_Dex").GetComponent<Button>();
        intButton = GameObject.Find("Button_Int").GetComponent<Button>();
        lukButton = GameObject.Find("Button_Luk").GetComponent<Button>();
        AbilityPoint.instance = this;
    }

    void Update()
    {
        if(int.Parse(pointAbility.text) == 0)
        {
            ActiveButton(false);
        }
        else
        {
            ActiveButton(true);

        }
    }

    void ActiveButton(bool active)
    {
        if(active == true)
        {
            hpButton.interactable = true;
            strButton.interactable = true;
            dexButton.interactable = true;
            intButton.interactable = true;
            lukButton.interactable = true;
        }
        else
        {
            hpButton.interactable = false;
            strButton.interactable = false;
            dexButton.interactable = false;
            intButton.interactable = false;
            lukButton.interactable = false;
        }
    }
}
