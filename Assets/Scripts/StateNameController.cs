using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StateNameController : MonoBehaviour
{

    public static string PlayerUsername;

    public void ReadStringInput(string s)
    {
        PlayerUsername = s;
        Debug.Log(PlayerUsername);
    }

}

