using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPos;
    [SerializeField] Vector3 movementPos;
    float movementFactor;

    private void Start()
    {
        startingPos = transform.position;
    }
    private void Update()
    {
        movementFactor = Mathf.Sin(Time.time);
        Vector3 offset = movementPos * movementFactor;
        transform.position = startingPos + offset;
    }

}
