using UnityEngine;

public class MenuScene : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.8f;
    private Vector3 loopPosition;


    void Awake()
    {
        loopPosition = new Vector3(0, -6.228f, 0);
    }

    void Update()
    {
        Time.timeScale = 1;
    }

    void FixedUpdate()
    {
        if(transform.position.y >= 3.6f)
        {
            transform.position = loopPosition; 
        }
        transform.Translate(translation: Vector3.up * moveSpeed * Time.fixedDeltaTime);
    }
}
