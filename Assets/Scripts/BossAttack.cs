using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour 
{
    void Start()
    {
        StartCoroutine("AttackCoroutine");
    }

    void Update()
    {

    }
    IEnumerator AttackCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            Attack();
        }
    }
    
    void Attack()
    {
        transform.localScale = new Vector3(Random.Range(4f, 14f), Random.Range(4f, 14f), 2);
    }

}
