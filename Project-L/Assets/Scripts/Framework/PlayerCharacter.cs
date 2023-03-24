using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;


public class PlayerCharacter : Entity
{

    public Animator Animator;

    public float RunBlendSpeed;

    public Vector3 MoveVec;

    public Vector3 NextDir;

    public Quaternion LookPosition;

    public CharacterState CharacterState;
    void OnEnable()
    {
        //TODO:初始为待机状态
        Animator = GetComponentInChildren<Animator>();
        Idle();
    }


    void FixedUpdate()
    {
        RotateBody();
        Move();
    }

    public void Idle()
    {
        CharacterState = CharacterState.Idle;
    }

    public void StopMove()
    {
        MoveVec.x = 0f;
        MoveVec.z = 0f;
        Animator.SetFloat("Run", 0f);
        Idle();
    }

    public void MoveStop()
    {
        Idle();
    }

    public void RotateBody(){
        if (MoveVec.x < 0.2f && MoveVec.x > -0.2f && MoveVec.z < 0.2f && MoveVec.z > -0.2f) {
            //移动速度不够，不旋转
            return;
        }

        base.transform.rotation = Quaternion.Slerp(base.transform.rotation, LookPosition, Time.deltaTime * 20f);
    }

    public void Move()
    {
        if (MoveVec.x < 0.2f && MoveVec.x > -0.2f && MoveVec.z < 0.2f && MoveVec.z > -0.2f) {
            //移动速度不够，不移动
            if (RunBlendSpeed > 0)
            {
                RunBlendSpeed -= Time.deltaTime * 5f;
            }

            if (CharacterState == CharacterState.Idle || CharacterState == CharacterState.Run)
            {
                Idle();
            }

        }
        else
        {
            if (RunBlendSpeed < 1f)
            {
                RunBlendSpeed += Time.deltaTime * 5f;
            }
            Vector3 forward = Camera.main.transform.forward;
            Vector3 right = Camera.main.transform.right;
            forward.y = 0;
            right.y = 0;
            NextDir = MoveVec.x * right + MoveVec.z * forward;
            LookPosition = Quaternion.LookRotation(NextDir);

            if (CharacterState == CharacterState.Idle || CharacterState == CharacterState.Run)
            {
                CharacterState = CharacterState.Run;
            }

            base.transform.Translate(Vector3.forward * Time.deltaTime * State.CurMoveSpeed);
        }
        Animator.SetFloat("Run", RunBlendSpeed);

    }

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        float leftOrRight = 0f;
        float upOrDown = 0f;
        if (Input.GetKey(KeyBinding.LeftKeyCode)) {
            leftOrRight = -1f;
        }
        if (Input.GetKey(KeyBinding.RightKeyCode))
        {
            leftOrRight = 1;
        }
        if (Input.GetKey(KeyBinding.UpKeyCode)) {
            upOrDown = 1f;
        }
        if (Input.GetKey(KeyBinding.DownKeyCode)) {
            upOrDown = -1f;
        }

        MoveVec.x = leftOrRight;
        MoveVec.z = upOrDown;
    }
}
