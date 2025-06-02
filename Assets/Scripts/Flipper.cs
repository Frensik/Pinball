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
    HingeJoint hinge;

    private void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
    }

    private void Update()
    {
        //this determines how fast the flipper moves
        JointSpring spring = new JointSpring();
        spring.spring = hitStrength;
        spring.damper = flipperDamper;

        //moves the flipper to the max rotation when the key is pressed
        if(Input.GetAxis(inputName)==1)
        {
            spring.targetPosition = pressedPosition;
        }
        //moves it back when key is let go
        else
        {
            spring.targetPosition = restPosition;
        }
        hinge.spring = spring;
        hinge.useLimits = true;
    }
}

