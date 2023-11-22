using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMotor : MonoBehaviour
{
    [SerializeField] private PlayerInput inputs;

    private InputAction moveAction;

    private Animator anim;

    private GameManager manager;

    private Vector2 velocity = Vector2.zero;
    private int direction = 0;
    [SerializeField] private float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.getInstance();
        inputs = manager.GetInputs();
        moveAction = inputs.actions.FindAction("Move");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 _moveValue = moveAction.ReadValue<Vector2>();

        _moveValue = ChooseDirection(_moveValue);

        velocity = _moveValue * speed;

        transform.position += new Vector3(velocity.x * Time.fixedDeltaTime, velocity.y * Time.fixedDeltaTime, 0);

        anim.SetInteger("direction", direction);
    }

    private Vector2 ChooseDirection(Vector2 _value)
    {
        Vector2 _result = Vector2.zero;

        if(Mathf.Abs(_value.x) >= Mathf.Abs(_value.y))
        {
               _result = new Vector2(_value.x, 0);
        }
        else
        {
            _result = new Vector2(0, _value.y);
        }

        direction = SetDirection(_result);

        return _result;
    }

    private int SetDirection(Vector2 _vector)
    {
        if(_vector.x > 0)
        {
            return 6;
        }
        else if(_vector.x < 0)
        {
            return 4;
        }

        if (_vector.y > 0)
        {
            return 8;
        }
        else if (_vector.y < 0)
        {
            return 2;
        }

        return 0;
    }
}
