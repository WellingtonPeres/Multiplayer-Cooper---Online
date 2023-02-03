using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerGrabbedObject;

    [SerializeField] private kitchenObjectScriptableObject kitchenObjectSO;


    public override void Interact(Player player)
    {
        Transform kitchenObjetcTransform = Instantiate(kitchenObjectSO.prefab);
        kitchenObjetcTransform.GetComponent<KitchenObject>().SetKitchenObjetcParent(player);
        if (OnPlayerGrabbedObject != null)
        {
            OnPlayerGrabbedObject(this, EventArgs.Empty);
        }        
    }
}
