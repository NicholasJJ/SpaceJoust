using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Respawnable : MonoBehaviour
{
    [SerializeField] XRSocketInteractor holster;
    [SerializeField] public float respawnTime;

    public void Die()
    {
        Debug.Log("Die");
        transform.parent = null;
        ToolManager.Instance.StoreForRespawn(this);
    }

    public void Respawn()
    {
        holster.enabled = true;
        holster.interactionManager.SelectEnter(holster, gameObject.GetComponent<XRGrabInteractable>());
    }
}
