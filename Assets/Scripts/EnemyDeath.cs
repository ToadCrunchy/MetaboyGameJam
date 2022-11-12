using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{

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
        if (co.gameObject.tag == "Enemy")
        {
            Debug.Log("You killed a monster!");
            co.gameObject.SetActive(false);
        }
    }
}
