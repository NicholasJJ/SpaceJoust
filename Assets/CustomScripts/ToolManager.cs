using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ToolManager : Singleton<ToolManager>
{
    private Dictionary<Respawnable, float> respawningItems = new Dictionary<Respawnable, float>();

    private void Start()
    {
        respawningItems = new Dictionary<Respawnable, float>();
    }

    private void Update()
    {
        List<Respawnable> toRemove = new List<Respawnable>();
        foreach (var item in respawningItems)
        {
            if (item.Value <= Time.time)
            {
                item.Key.transform.parent = null;
                item.Key.gameObject.SetActive(true);
                item.Key.Respawn();
                toRemove.Add(item.Key);
            }
        }
        foreach (var item in toRemove) respawningItems.Remove(item);
    }

    public void StoreForRespawn(Respawnable r)
    {
        r.transform.parent = transform;
        respawningItems.Add(r, r.respawnTime + Time.time);
        //r.GetComponent<XRGrabInteractable>().enabled = false;
        r.gameObject.SetActive(false);
    }
}