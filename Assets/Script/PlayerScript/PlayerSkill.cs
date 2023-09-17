using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    private Animator animator;

    private bool canSkill = true;

    [SerializeField]
    private int fireSkillDamage = 0;
    [SerializeField]
    private int waterSkillDamage = 0;
    [SerializeField]
    private int lightningSkillDamage = 0;
    [SerializeField]
    private int shadowSkillDamage = 0;
    [SerializeField]
    private float fireSkillRange = 0.4f;
    [SerializeField]
    private float waterSkillRange = 0.5f;
    [SerializeField]
    private float lightningSkillRange = 0.5f;
    [SerializeField]
    private float shadowSkillRange = 0.5f;
    [SerializeField]
    private GameObject fireAttackPoint;
    [SerializeField]
    private GameObject waterAttackPoint;
    [SerializeField]
    private float waterAttackRotation;
    [SerializeField]
    private GameObject lightningAttackPoint;
    [SerializeField]
    private GameObject shadowAttackPoint;
    [SerializeField]
    private float shadowAttackRotation;
    [SerializeField]
    private GameObject thunder;
    [SerializeField]
    private GameObject water;
    [SerializeField]
    private GameObject shadow;
    private float cooldown = 0.5f;
    private float lastAttackedAt = -9999f;
    public LayerMask enemyLayer;

    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        shadowAttackRotation = waterAttackRotation;
    }

    void Update()
    {
        if (SkillPoint.instance.chooseFireSkill)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                FireSpin();
            }
        }
        else
        {
            if (Time.time > lastAttackedAt + cooldown)
            {
                if (Input.GetKeyDown(KeyCode.K))
                {
                    Skill();
                    lastAttackedAt = Time.time;
                }
            }
        }
    }

    void Skill()
    {
        if (canSkill)
        {
            if(SkillPoint.instance.chooseWaterSkill)
            {
                waterSkillDamage = PlayerController.instance.playerAttack.attackDamage + PlayerController.instance.playerStats.intelligence + int.Parse(SkillPoint.instance.waterSkillPoint.text);
                animator.SetTrigger("Skill");
                animator.SetBool("ChooseWaterSkill", true);
                Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(waterAttackPoint.transform.position, waterSkillRange, enemyLayer);
                if (animator.GetFloat("Horizontal") <= -1 && animator.GetFloat("Vertical") >= 1 || PlayerController.instance.playerMovement.movement.x <= -1 && PlayerController.instance.playerMovement.movement.y >= 1)
                {
                    waterAttackRotation = 225;
                }
                Instantiate(water, waterAttackPoint.transform.position, Quaternion.Euler(0, 0, waterAttackRotation));
                foreach (Collider2D enemy in hitEnemy)
                {
                    enemy.GetComponent<EnemyController>().enemyHurt.TakeDamage(waterSkillDamage);
                }
            }
            else if(SkillPoint.instance.chooseLightningSkill)
            {
                lightningSkillDamage = PlayerController.instance.playerAttack.attackDamage + PlayerController.instance.playerStats.dexterity + int.Parse(SkillPoint.instance.lightningSkillPoint.text);
                animator.SetTrigger("Skill");
                animator.SetBool("ChooseLightningSkill", true);
                Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(lightningAttackPoint.transform.position, lightningSkillRange, enemyLayer);
                foreach (Collider2D enemy in hitEnemy)
                {
                    Instantiate(thunder, enemy.transform.position, Quaternion.identity);
                    enemy.GetComponent<EnemyController>().enemyHurt.TakeDamage(lightningSkillDamage);
                }
            }
            else if(SkillPoint.instance.chooseShadowSkill)
            {
                shadowSkillDamage = PlayerController.instance.playerAttack.attackDamage + PlayerController.instance.playerStats.luck + int.Parse(SkillPoint.instance.shadowSkillPoint.text);
                animator.SetTrigger("Skill");
                animator.SetBool("ChooseShadowSkill", true);
                Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(shadowAttackPoint.transform.position, shadowSkillRange, enemyLayer);
                if (animator.GetFloat("Horizontal") <= -1 && animator.GetFloat("Vertical") >= 1 || PlayerController.instance.playerMovement.movement.x <= -1 && PlayerController.instance.playerMovement.movement.y >= 1)
                {
                    shadowAttackRotation = 225;
                }
                Instantiate(shadow, shadowAttackPoint.transform.position, Quaternion.Euler(0, 0, shadowAttackRotation));
                foreach (Collider2D enemy in hitEnemy)
                {
                    enemy.GetComponent<EnemyController>().enemyHurt.TakeDamage(shadowSkillDamage);
                }
            }
        }
    }



    void FireSpin()
    {
        if (canSkill)
        {
            fireSkillDamage = PlayerController.instance.playerAttack.attackDamage + PlayerController.instance.playerStats.strength + int.Parse(SkillPoint.instance.fireSkillPoint.text);
            animator.SetTrigger("Skill");
            animator.SetBool("ChooseFireSkill", true);
            Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(fireAttackPoint.transform.position, fireSkillRange, enemyLayer);
            foreach (Collider2D enemy in hitEnemy)
            {
                enemy.GetComponent<EnemyController>().enemyHurt.TakeDamage(fireSkillDamage);
            }
        }
    }
}
