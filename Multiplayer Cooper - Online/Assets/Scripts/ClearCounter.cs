using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private kitchenObjectScriptableObject kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;

    private KitchenObject kitchenObject;

    public void Interact(Player player)
    {
        if (kitchenObject == null)
        {
            Transform kitchenObjetcTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            kitchenObjetcTransform.GetComponent<KitchenObject>().SetKitchenObjetcParent(this);
            kitchenObjetcTransform.localPosition = Vector3.zero;
        }
        else
        {
            // Give the object to the player
            kitchenObject.SetKitchenObjetcParent(player);
        }
    }
    
    public Transform GetKitchenObjectFollowTrnasform()
    {
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }
    
    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }    
}
