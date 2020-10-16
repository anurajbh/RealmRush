using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform panObject;
    [SerializeField] Transform objectToLookAt;
    public bool isFiring = false;
    void Update()
    {
        LookAtEnemy(objectToLookAt);
    }
    public void LookAtEnemy(Transform objectToLook)
    {
        panObject.LookAt(objectToLook);
    }
}
