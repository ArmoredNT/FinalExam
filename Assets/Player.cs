using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Vector3 _checkPoint = new Vector3(0, 5, 0);
    [SerializeField] private float _speed;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private TextMeshProUGUI _text1;
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private Rigidbody rb;

    private Vector3 _moveDir;
    private int _deaths;
    private float _clock;

    private bool _isGrounded;
    private float _depth;
    void Start()
    {
        InputManager.init(this);
        InputManager.gameMode();

        _text.text = "0";
        _depth = transform.localScale.y * 0.5f + 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5) Death();
        

        _clock += Time.deltaTime;
        _text1.text = TimeSpan.FromSeconds(_clock).ToString("g");
            //(((int)(_clock*0.01667f)) + ":" +_clock%60).ToString();
        
        transform.position += (Vector3) (_speed * Time.deltaTime * (_moveDir));
    }

    public void SetMoveDirection(Vector3 newDirection)
    {
        _moveDir = newDirection;
    }

    public void SetCheckPoint(Vector3 pos)
    {
        _checkPoint = pos;
    }

    public void Jump()
    {
        if (checkGround()) rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
    }
    
    void Death()
    {
        _deaths++;
        _text.text = _deaths.ToString();
        transform.position = _checkPoint;
    }
    
    bool checkGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, _depth, groundLayers);
        //Debug.DrawRay(transform.position, Vector3.down * _depth, Color.green, 0, false);
    }
}
