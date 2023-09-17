using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    public int currentHp;
    public int maxHp;
    [SerializeField]
    private Material matWhite;
    [SerializeField]
    private Material matDefault;
    [SerializeField]
    SpriteRenderer sr;

    public PlayerDead playerDead;

    void Awake()
    {
        playerDead = GetComponent<PlayerDead>();
        currentHp = maxHp;
        sr = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;
    }


    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        sr.material = matWhite;
        Invoke("ResetMaterial", 0.2f);
        if (currentHp <= 0)
        {
            playerDead.Dead();
        }
    }

    void ResetMaterial()
    {
        sr.material = matDefault;
    }
}
