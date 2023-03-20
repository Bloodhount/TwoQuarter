using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelfGO : MonoBehaviour
{
    [SerializeField] private  int _timeToSelfdestruct = 1;

    void Start()
    {
        Destroy(gameObject, _timeToSelfdestruct);
    }
}
