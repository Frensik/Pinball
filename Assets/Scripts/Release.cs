using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Release : MonoBehaviour
{
    private void Update()
    {
        //Deletes the cage the ball is held in when mouse is clicked so that it can drop
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);
        }
    }
}
