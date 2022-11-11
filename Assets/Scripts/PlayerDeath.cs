using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider co)
    {
        if (co.gameObject.tag == "DeathBox")
        {
            Debug.Log("Oh dear, you died!");
            Player.SetActive(false);
        }
    }
}
