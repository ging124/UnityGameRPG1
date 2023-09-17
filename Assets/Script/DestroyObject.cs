using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float destroyTime;

    void Update()
    {
        Destroy(gameObject, destroyTime);
    }
}
