using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private CharacterMovement characterMovement;

    [SerializeField]    //既是私有又可以赋值
    private Photographer photographer;

    [SerializeField]
    private Transform followingTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        characterMovement = GetComponent<CharacterMovement>();
        photographer.InitCamera(followingTarget);   //摄影机跟随点
    }

    // Update is called once per frame
    void Update()
    {
        UpdataMovementInput();
    }

    private void UpdataMovementInput()
    {
        Quaternion rot = Quaternion.Euler(0, photographer.Yaw, 0);  //Yaw代表水平旋转量，即可代表当前摄影机的朝向
        
        characterMovement.SetMovementInput(rot * Vector3.forward * Input.GetAxis("Vertical") + 
                                           rot * Vector3.right * Input.GetAxis("Horizontal"));
    }
}
