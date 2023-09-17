using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveObject : MonoBehaviour
{
    [SerializeField]
    private float deactiveTime;

    void Update()
    {
        Invoke("Deactive", deactiveTime);
    }

    void Deactive()
    {
        gameObject.SetActive(false);
    }
}
