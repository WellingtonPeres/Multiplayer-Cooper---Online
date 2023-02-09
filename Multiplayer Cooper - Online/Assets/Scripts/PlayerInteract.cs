using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float distanceRay = 2;
    [SerializeField] private LayerMask interactLayer;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, distanceRay, interactLayer))
        {
            Debug.Log("Pegando a layer com Hit" + hit.collider.gameObject.layer);

        }
    }
}
