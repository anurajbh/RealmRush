using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{
    [Range(1,20f)]
    [SerializeField] float gridSize = 10f;
    void Update()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize);

        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize);

        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);
    }
}
