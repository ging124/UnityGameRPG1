using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    protected float timeDelay = 0.5f;
    protected float timeSpawn = 0;
    [SerializeField]
    private float moveSpeed = 0.5f;
    [SerializeField]
    protected float disLimit = 0.3f;
    private Animator animator;
    public bool canRun = true;

    void Awake()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {
        if (canRun)
        {
            Follow();
        }
    }

    void Follow()
    {
        if (player != null)
        {
            Vector3 distance = player.transform.position - transform.position;     //Keyword: unity 2d follow object smoothly
            if (distance.magnitude >= disLimit)
            {
                Vector2 targetPoint = player.transform.position - distance.normalized * disLimit;
                animator.SetFloat("Speed", moveSpeed);
                if (distance != Vector3.zero)
                {
                    animator.SetFloat("Horizontal", distance.x);
                    animator.SetFloat("Vertical", distance.y);
                }
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPoint, moveSpeed * Time.deltaTime);
            }
        }
    }
}

