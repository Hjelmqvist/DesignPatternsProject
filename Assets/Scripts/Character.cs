using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [SerializeField] Health _health;

    public void ModifyHealth(int value) => _health.ModifyHealth( value );
}