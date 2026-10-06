using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    // Player Control variables
    private float _playerSpeed = 20;
    private float _xRange = 17;
    
    // Prefab objects
    [SerializeField]public GameObject projectilePrefab;
    
    // Input action variables
    [SerializeField]private InputActionAsset inputActionAsset;
    private InputAction _moveAction;
    private Vector2 _moveAmt;

    // Enabling the "Player" ActionMap
    private void OnEnable()
    {
        inputActionAsset.FindActionMap("Player").Enable();
    }

    // Disabling the "Player" ActionMap
    private void OnDisable()
    {
        inputActionAsset.FindActionMap("Player").Disable();
    }
    
    // Finding Action "Move" which is present by default in "Player" ActionMap
    private void Awake()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
    }

    private void Update()
    {
        // Taking inputs from user and storing in a variable
        Vector2 moveInput = _moveAction.ReadValue<Vector2>();
        float horizontal = moveInput.x;
        //float vertical = moveInput.y;
        
        // Movement left and right
        transform.Translate(Vector3.right * (horizontal * _playerSpeed * Time.deltaTime) );
        
        // Setting boundaries for player to not go outside the screen
        if (transform.position.x < -_xRange)
        {
            transform.position = new Vector3(-_xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > _xRange)
        {
            transform.position = new Vector3(_xRange, transform.position.y, transform.position.z);
        }
    }
}
