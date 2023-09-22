using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 5f;
    private Vector2 movement;
    public Vector2 _movement { get => movement; }
    protected float moveLimit = 0.7f;
    public bool isMovement = true;


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

        PlayerController.instance.animator.SetFloat("Speed", this.movement.sqrMagnitude);
        if (this.movement != Vector2.zero)
        {
            PlayerController.instance.animator.SetFloat("Horizontal", this.movement.x);
            PlayerController.instance.animator.SetFloat("Vertical", this.movement.y);
        }
        LimitMovement();
        PlayerController.instance.rb.MovePosition(PlayerController.instance.rb.position + this.movement * this.moveSpeed * Time.fixedDeltaTime);
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
