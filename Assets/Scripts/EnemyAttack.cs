using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private bool reload;
    public GameObject Bullet;
    public Transform firepoint1;
 

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ShootCoroutine");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ShootCoroutine()
    {
        while (true) // this just equates to "repeat forever"
        {
            yield return new WaitForSeconds(2f); // "pauses" for 2 seconds.. note, the actual game doesn't pause..
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(Bullet, firepoint1.position, firepoint1.rotation);
    }

}

