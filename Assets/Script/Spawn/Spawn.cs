using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObject;

    protected void Reset()
    {
        this.LoadComponent();
    }

    protected virtual void LoadComponent()
    {
    }

}
