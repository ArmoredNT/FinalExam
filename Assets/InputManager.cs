using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static Controls _controls;

    public static void init(Player _player)
    {

        _controls = new Controls();

        _controls.Game.Movement.performed += ctx => {

            _player.SetMoveDirection(ctx.ReadValue<Vector3>());
        
        };

        _controls.Game.Jump.performed += _ => {
        
         
            _player.Jump();
        
        };
        //
        // _controls.Permanent.Enable();

    }
    
    public static void gameMode()
    {

        _controls.Game.Enable();

    }
}
