using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private kitchenObjectScriptableObject kitchenObjectSO;

    public kitchenObjectScriptableObject GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }
}
