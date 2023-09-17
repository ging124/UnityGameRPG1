using UnityEngine;
using TMPro;

public class TextLevelUpdate : MonoBehaviour
{
    private TMP_Text lvText;
    // Start is called before the first frame update
    void Awake()
    {
        lvText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLv();
    }

    private void UpdateLv()
    {
        lvText.text = PlayerController.instance.playerLvUp.level.ToString();
    }
}
