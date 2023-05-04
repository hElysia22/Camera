using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private CharacterMovement characterMovement;

    [SerializeField]    //����˽���ֿ��Ը�ֵ
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
        photographer.InitCamera(followingTarget);   //��Ӱ�������
    }

    // Update is called once per frame
    void Update()
    {
        UpdataMovementInput();
    }

    private void UpdataMovementInput()
    {
        Quaternion rot = Quaternion.Euler(0, photographer.Yaw, 0);  //Yaw����ˮƽ��ת�������ɴ���ǰ��Ӱ���ĳ���
        
        characterMovement.SetMovementInput(rot * Vector3.forward * Input.GetAxis("Vertical") + 
                                           rot * Vector3.right * Input.GetAxis("Horizontal"));
    }
}
