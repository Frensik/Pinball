using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Flipper : MonoBehaviour
{
    private Animator animator;
    private PlayerInput input;
    //[SerializeField] AnimationClip flip;

    public void OnFLip(InputAction input)
    {
        animator.SetTrigger("Flip");
    }
}

