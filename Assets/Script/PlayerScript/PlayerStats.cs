using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public int maxHp;
    public int currentHp;
    public int attack;
    public int strength = 5;
    public int dexterity = 5;
    public int intelligence = 5;
    public int luck = 5;

    public TMP_Text textHp;
    public TMP_Text textAttack;
    public TMP_Text textStr;
    public TMP_Text textDex;
    public TMP_Text textInt;
    public TMP_Text textLuk;

    static public PlayerStats instance;

    void Awake()
    {
        PlayerStats.instance = this;
        textHp = GameObject.Find("HP").GetComponent<TMP_Text>();
        textAttack = GameObject.Find("Attack").GetComponent<TMP_Text>();
        textStr = GameObject.Find("STR").GetComponent<TMP_Text>();
        textDex = GameObject.Find("DEX").GetComponent<TMP_Text>();
        textInt = GameObject.Find("INT").GetComponent<TMP_Text>();
        textLuk = GameObject.Find("LUK").GetComponent<TMP_Text>();
    }

    void Update()
    {
        maxHp = PlayerController.instance.playerHurt.maxHp;
        currentHp = PlayerController.instance.playerHurt.currentHp;
        attack = PlayerController.instance.playerAttack.attackDamage;

        UpdateHpStat();
        UpdateAttackStat();
        UpdateStrStat();
        UpdateDexStat();
        UpdateIntStat();
        UpdateLukStat();
    }

    void UpdateHpStat()
    {
        textHp.text = currentHp.ToString() + "/" + maxHp.ToString();
    }

    void UpdateAttackStat()
    {
        textAttack.text = attack.ToString();
    }

    void UpdateStrStat()
    {
        textStr.text = strength.ToString();
    }

    void UpdateDexStat()
    {
        textDex.text = dexterity.ToString();
    }

    void UpdateIntStat()
    {
        textInt.text = intelligence.ToString();
    }

    void UpdateLukStat()
    {
        textLuk.text = luck.ToString();
    }

}
