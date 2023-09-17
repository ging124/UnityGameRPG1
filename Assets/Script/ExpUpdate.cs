using UnityEngine;
using TMPro;

public class ExpUpdate : MonoBehaviour
{
    private TMP_Text exp;

    void Awake()
    {
        exp = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        exp.text = PlayerController.instance.playerLvUp.currentExp.ToString() + "/" + PlayerController.instance.playerLvUp.maxExp.ToString();
    }
}
