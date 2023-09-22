using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    public int currentHp;
    public int maxHp;
    [SerializeField]
    private Material matWhite;
    [SerializeField]
    private Material matDefault;
    protected SpriteRenderer sr; 

    public PlayerDead playerDead;

    void Awake()
    {
        playerDead = GameObject.Find("PlayerDead").GetComponent<PlayerDead>();
        sr = GameObject.Find("PlayerModel").GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        currentHp = maxHp;
        matDefault = sr.material;
    }


    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        sr.material = matWhite;
        if (currentHp <= 0)
        {
            ResetMaterial();
            playerDead.Dead();
        }
        Invoke(nameof(ResetMaterial), 0.2f);
    }

    void ResetMaterial()
    {
        sr.material = matDefault;
    }
}
