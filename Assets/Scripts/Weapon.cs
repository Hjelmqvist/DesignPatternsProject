using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    Character _user;

    public void SetUser(Character user)
    {
        _user = user;
    }
}
