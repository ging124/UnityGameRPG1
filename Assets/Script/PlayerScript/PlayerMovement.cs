using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    protected Animator animator;
    protected Rigidbody2D rb;
    [SerializeField] protected float moveSpeed = 5f;
    public Vector2 movement;
    protected float moveLimit = 0.7f;
    public bool isMovement = true;

    void Awake()
    {
        this.animator = gameObject.GetComponent<Animator>();
        this.rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        this.GetInputMovement();
    }

    void FixedUpdate()
    {
        this.Movement();
    }

    protected virtual void GetInputMovement()
    {
        this.movement.x = Input.GetAxisRaw("Horizontal");
        this.movement.y = Input.GetAxisRaw("Vertical");
    }

    protected virtual void Movement()
    {
        if (!this.isMovement) return;

        this.animator.SetFloat("Speed", this.movement.sqrMagnitude);
        if (this.movement != Vector2.zero)
        {
            this.animator.SetFloat("Horizontal", this.movement.x);
            this.animator.SetFloat("Vertical", this.movement.y);
        }
        LimitMovement();
        this.rb.MovePosition(this.rb.position + this.movement * this.moveSpeed * Time.fixedDeltaTime);
    }

    protected virtual void LimitMovement() //Hàm này sẽ giới hạn lại khi nhân vật đi chéo
    {
        if (this.movement.x != 0 && this.movement.y != 0)
        {
            this.movement.x *= this.moveLimit;
            this.movement.y *= this.moveLimit;
        }
    }
}
