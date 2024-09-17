using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scanStarterKey : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ﬂ –¿¡Œ“¿ﬁ");
        }    
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
