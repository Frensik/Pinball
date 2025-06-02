using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPos;
    [SerializeField] Vector3 movementPos;
    float movementFactor;
    bool delay = false;

    private void Start()
    {
        StartCoroutine("Bazinga");
        startingPos = transform.position;
    }
    private void Update()
    {
        {
            movementFactor = Mathf.Sin(Time.time);
            Vector3 offset = movementPos * movementFactor;
            transform.position = startingPos + offset;
        }

    }

    private IEnumerator Bazinga()
    {
        yield return new WaitForSeconds(1);
        delay = true;
    }
}
