using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    int isTurningLeftHash;
    int isTurningRightHash;
    
    int isWalkingHash;
    int isRunningHash;

    int isWalkingBackHash;
    int isRunningBackHash;
    
    int isWalkingLeftHash;
    int isRunningLeftHash;

    int isWalkingRightHash;
    int isRunningRightHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
        isTurningLeftHash = Animator.StringToHash("isTurningLeft");
        isTurningRightHash = Animator.StringToHash("isTurningRight");

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");

        isWalkingBackHash = Animator.StringToHash("isWalkingBack");
        isRunningBackHash = Animator.StringToHash("isRunningBack");

        isWalkingLeftHash = Animator.StringToHash("isWalkingLeft");
        isRunningLeftHash = Animator.StringToHash("isRunningLeft");

        isWalkingRightHash = Animator.StringToHash("isWalkingRight");
        isRunningRightHash = Animator.StringToHash("isRunningRight");

        Debug.Log(animator);
    }

    // Update is called once per frame
    void Update()
    {
        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        bool leftTurnPressed = Input.GetKey(KeyCode.Q);
        bool isTurningLeft = animator.GetBool(isTurningLeftHash);

        bool RightTurnPressed = Input.GetKey(KeyCode.E);
        bool isTurningRight = animator.GetBool(isTurningRightHash);

        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool forwardPressed = Input.GetKey(KeyCode.W);

        bool isWalkingBack = animator.GetBool(isWalkingBackHash);
        bool isRunningBack = animator.GetBool(isRunningBackHash);
        bool backwardsPressed = Input.GetKey(KeyCode.S);

        bool isWalkingLeft = animator.GetBool(isWalkingLeftHash);
        bool isRunningLeft = animator.GetBool(isRunningLeftHash);
        bool leftWalkPressed = Input.GetKey(KeyCode.A);

        bool isWalkingRight = animator.GetBool(isWalkingRightHash);
        bool isRunningRight = animator.GetBool(isRunningRightHash);
        bool RightWalkPressed = Input.GetKey(KeyCode.D);

        // bool forwardPressed = System.Convert.ToBoolean(Input.GetAxis("Horizontal")) || System.Convert.ToBoolean(Input.GetAxis("Vertical"));
        if (!isWalking && forwardPressed) {
            animator.SetBool(isWalkingHash, true);
        }
        
        if (isWalking && !forwardPressed) {
            animator.SetBool(isWalkingHash, false);
        }

        if (!isRunning && (forwardPressed && runPressed)) {
            animator.SetBool(isRunningHash, true);
        }

        if (isRunning && (!forwardPressed || !runPressed)) {
            animator.SetBool(isRunningHash, false);
        }

        if (!isWalking && !isTurningLeft && leftTurnPressed) {
            animator.SetBool(isTurningLeftHash, true);
        }

        if (isTurningLeft && !leftTurnPressed) {
            animator.SetBool(isTurningLeftHash, false);
        }

        if (!isWalkingLeft && leftWalkPressed) {
            animator.SetBool(isWalkingLeftHash, true);
        }
        
        if (isWalkingLeft && !leftWalkPressed) {
            animator.SetBool(isWalkingLeftHash, false);
        }

        if (!isRunningLeft && (leftWalkPressed && runPressed)) {
            animator.SetBool(isRunningLeftHash, true);
        }

        if (isRunningLeft && (!leftWalkPressed || !runPressed)) {
            animator.SetBool(isRunningLeftHash, false);
        }


        if (!isWalking && !isTurningRight && RightTurnPressed) {
            animator.SetBool(isTurningRightHash, true);
        }

        if (isTurningRight && !RightTurnPressed) {
            animator.SetBool(isTurningRightHash, false);
        }

        if (!isWalkingRight && RightWalkPressed) {
            animator.SetBool(isWalkingRightHash, true);
        }
        
        if (isWalkingRight && !RightWalkPressed) {
            animator.SetBool(isWalkingRightHash, false);
        }

        if (!isRunningRight && (RightWalkPressed && runPressed)) {
            animator.SetBool(isRunningRightHash, true);
        }

        if (isRunningRight && (!RightWalkPressed || !runPressed)) {
            animator.SetBool(isRunningRightHash, false);
        }


        if (!isWalkingBack && backwardsPressed) {
            animator.SetBool(isWalkingBackHash, true);
        }
        
        if (isWalkingBack && !backwardsPressed) {
            animator.SetBool(isWalkingBackHash, false);
        }

        if (!isRunningBack && (backwardsPressed && runPressed)) {
            animator.SetBool(isRunningBackHash, true);
        }

        if (isRunningBack && (!backwardsPressed || !runPressed)) {
            animator.SetBool(isRunningBackHash, false);
        }

    }
}
