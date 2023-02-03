using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private kitchenObjectScriptableObject kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;

    public void Interact()
    {
        Debug.Log("Interact!");
        Transform kitchenObjetcTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
        kitchenObjetcTransform.localPosition = Vector3.zero;

        Debug.Log(kitchenObjetcTransform.GetComponent<KitchenObject>().GetKitchenObjectSO().objectName);
    }
}
