using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class TabletAttachment : MonoBehaviour
{
    public Transform leftHand, rightHand;
    public Transform leftHandAttachment;
    public Transform rightHandAttachment;
    public Transform sideAttachment;
    public bool firstEncounter;


    [Tooltip("Changed at runtime")]
    public Transform currentAttachment;

    void Start()
    {
        GetComponent<XRSimpleInteractable>()
            .selectEntered.AddListener(OnSelected);
        firstEncounter = false;
    }

    public void InteractWithSideAttachment()
    {
        SetAttachment(sideAttachment);
    }

   
    private void OnSelected(SelectEnterEventArgs args)
    {
     

        if (firstEncounter == false)
        {
            AudioManager.instance.Play("GrabTablet");
            firstEncounter = true;
        }

        Debug.Log(firstEncounter);
        var comp = args.interactorObject as Component;
        if (comp == null)
            return;

        var handRoot = comp.transform.parent;
        if (handRoot == leftHand)
            SetAttachment(leftHandAttachment);
        else if (handRoot == rightHand)
            SetAttachment(rightHandAttachment);
   
    }

    private void SetAttachment(Transform attachment)
    {
        if (currentAttachment == attachment)
            return;

        transform.parent = attachment;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        currentAttachment = attachment;
    }
}
