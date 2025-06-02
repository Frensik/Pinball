using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Flipper : MonoBehaviour
{
    //private Animator animator;
    //private PlayerInput input;
    //[SerializeField] AnimationClip flip;

    //public void OnFLip(InputAction input)
    //{
    //    animator.SetTrigger("Flip");
    //}

    public float restPosition = 0f;
    public float pressedPosition = 45f;
    public float hitStrength = 10000f;
    public float flipperDamper = 150f;
    public string inputName;

    private void Update()
    {
        if(Input.GetAxis(inputName)==1)
        {

        }
    }
}

