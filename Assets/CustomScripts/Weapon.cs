using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] UnityEvent breakWeapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("shield"))
        {
            breakWeapon.Invoke();
            return;
        }
        Health h = other.gameObject.GetComponent<Health>();
        if (h)
        {
            h.Damage(damage);
        }
    }
}
