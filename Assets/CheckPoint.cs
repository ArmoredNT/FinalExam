using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private Player _player;
    private void OnTriggerEnter(Collider other)
    {
        _player.SetCheckPoint(transform.position);
    }
}
