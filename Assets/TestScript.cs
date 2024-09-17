using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class TouchDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OtherScript otherScript = other.GetComponent<OtherScript>();
            if (otherScript != null)
            {
                otherScript.ExecuteAction();
            }
        }
    }
}

