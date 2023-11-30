using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayers;
    
    private bool xAxis = true;
    private bool onGround = true;
    
    private float _depth;
    private Vector3 movDir;
    
    // Start is called before the first frame update
    void Start()
    {
        InputManager.init(this);
        InputManager.gameMode();
        
        _depth = transform.localScale.y * 0.5f + 0.2f;
        
        movDir = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        
        if (!CheckGround())
        {
            //onGround = false;
        }
        
        if (xAxis && onGround)
        {
            movDir = new Vector3(1, 0, 0);
        }
        else if (!xAxis && onGround)
        {
            movDir = new Vector3(0, 0, 1);
        }
        else
        {
            GetComponent<Rigidbody>().useGravity = true;
            print("hey");
        }

        transform.position += (speed * Time.deltaTime * movDir);
    }

    public void Switch()
    {
        xAxis = !xAxis;
    }
    
    bool CheckGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, _depth, groundLayers);
        //Debug.DrawRay(transform.position, Vector3.down * _depth, Color.green, 0, false);
    }
}
