using System;
using UnityEngine;

public class ScissorsBehaviour : MonoBehaviour
{
    [SerializeField] private AudioSource ScissorsSound;
    [SerializeField] public LeafBehaviour LeafInContact;
    public void OnButtonPress()
    {
        Debug.Log("Листья");
        
        if (LeafInContact != null)
        {
            LeafInContact.FallFromStem();
            
        }
           
    }
}
