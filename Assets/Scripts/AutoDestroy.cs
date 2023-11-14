using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] private float destroyTime = 0f;
    void Start()
    {
        Destroy(this, destroyTime);
    }
}
