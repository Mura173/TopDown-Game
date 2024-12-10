using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;

    private Rigidbody2D rb;

    private float initialSpeed;
    private bool _isRunning;
    private bool _isRolling;
    private bool _isCutting;
    private bool _isDigging;

    private int handlingObj;

    private Vector2 _direction;

    // Propriedade para acessar o valor do direction em outro script
    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    public bool isRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }

    public bool isRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }

    public bool isCutting
    {
        get { return _isCutting; }
        set { _isCutting = value; }
    }

    public bool isDigging
    {
        get { return _isDigging; }
        set { _isDigging = value; }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            handlingObj = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            handlingObj = 2;
        }

        OnInput();
        OnRun();
        OnRolling();
        OnCutting();
        OnDig();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    #region Movement

    void OnDig()
    {
        if (handlingObj == 2)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isDigging = true;
                speed = 0;
            }

            if (Input.GetMouseButtonUp(0))
            {
                _isDigging = false;
                speed = initialSpeed;
            }
        }       
    }

    void OnCutting()
    {
        if (handlingObj == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isCutting = true;
                speed = 0;
            }

            if (Input.GetMouseButtonUp(0))
            {
                _isCutting = false;
                speed = initialSpeed;
            }
        }        
    }

    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove()
    {
        rb.MovePosition(rb.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            _isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            isRunning = false;
        }
    }

    void OnRolling()
    {
        // 0: Botao esquerdo do mouse
        // 1: Botao direito do mouse
        if (Input.GetMouseButtonDown(1))
        {
            speed = runSpeed;
            _isRolling = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            speed = initialSpeed;
            _isRolling = false;
        }
    }
    #endregion
}
