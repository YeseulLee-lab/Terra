using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float rotateAngle = 30f;

    private void Update()
    {
        transform.Rotate(0, 0, rotateAngle * Time.deltaTime * speed);
    }
}
