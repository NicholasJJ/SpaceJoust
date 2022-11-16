using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Respawnable : MonoBehaviour
{
    [SerializeField] Transform holster;
    [SerializeField] public float respawnTime;

    public void Die()
    {
        Debug.Log("Die");
        transform.parent = null;
        ToolManager.Instance.StoreForRespawn(this);
    }

    public void Respawn()
    {
        if (holster.GetComponent<XRSocketInteractor>())
        {
            var socket = holster.GetComponent<XRSocketInteractor>();
            socket.enabled = true;
            socket.interactionManager.SelectEnter(socket, gameObject.GetComponent<XRGrabInteractable>());
        }
        else
        {
            transform.parent = holster;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
        
    }
}
