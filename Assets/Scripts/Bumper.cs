using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField] ParticleSystem successVFX;
    
    // plays the vfx when the bumper collides with the player
    //this was moved to a seperate script so that it could be put on each bumper
    //made it so the vfx was individual for each one
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            successVFX.Play();
        }
    }
}
