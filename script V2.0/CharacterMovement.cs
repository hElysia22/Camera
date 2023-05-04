using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{

    private new Rigidbody rigidbody;

    public float maxMoveSpeed = 5;

    public Vector3 CurrentInput { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + CurrentInput * maxMoveSpeed * Time.fixedDeltaTime);
    }

    public void SetMovementInput(Vector3 input)
    {
        CurrentInput = Vector3.ClampMagnitude(input, 1);
    }
}
