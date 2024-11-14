using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Drawing.Inspector.PropertyDrawers;
using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(Animator))]
public class PlayerMove : MonoBehaviour
{
    #region Private Components
    
    private CharacterController charCtrl;
    private Animator anim;
    #endregion

    #region Public Fiuelds
    
    public float walkSpeed;
    public float runSpeed;

    #endregion

    #region Private Fields

    private float currentSpeed;

    #endregion
    
    private void Awake()
    {
        charCtrl = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 inputValue = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // ClampMagnitude를 사용하여 대각선 이동 속도를 1로 제한
        // normalize로 하면 0 ~ 1도 1로 될것이기 때문에
        inputValue = Vector3.ClampMagnitude(inputValue, 1);
 
        float runValue = Input.GetAxis("Fire3");

        currentSpeed = inputValue.magnitude * walkSpeed + (runValue * (runSpeed - walkSpeed));

        Vector3 inputMoveDir = inputValue * currentSpeed;
        
        Vector3 acturalMove = transform.TransformDirection(inputMoveDir);
        
        charCtrl.Move(acturalMove * Time.deltaTime);
        
        anim.SetFloat("Xdir", inputValue.x);    
        anim.SetFloat("Ydir", inputValue.z);
        anim.SetFloat("Speed", inputValue.magnitude + runValue);
    }
}
