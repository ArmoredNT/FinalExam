using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static Controls _controls;

    public static void init(BallController _player)
    {

        _controls = new Controls();

        // _controls.Game.Movement.performed += ctx => {
        //
        //     _player.SetMoveDirection(ctx.ReadValue<Vector3>());
        //
        // };

        _controls.BallGame.Switch.performed += _ => {
        
         
            _player.Switch();
        
        };
        //
        // _controls.Permanent.Enable();

    }
    
    public static void gameMode()
    {

        _controls.BallGame.Enable();

    }
}
