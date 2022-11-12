using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareCollect : MonoBehaviour
{
    public int Share = 0;
    
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
        if (co.gameObject.tag == "Share")
        {
            Debug.Log("Share collected!");
            Share++;
            co.gameObject.SetActive(false);
        }
    }
}
