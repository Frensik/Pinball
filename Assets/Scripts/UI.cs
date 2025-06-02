using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] Button restart;
    [SerializeField] Canvas deathCanvas;

    void Start()
    {
        deathCanvas.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            deathCanvas.gameObject.SetActive(true);
        }
    }
}
