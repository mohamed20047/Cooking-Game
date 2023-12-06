using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    public event EventHandler<OnEngredientAddedEventArgs> OnEngredientAdded;
    public class OnEngredientAddedEventArgs : EventArgs
    {
        public KitchenObjectSO kitchenObjectSO;
    }

    [SerializeField] private List<KitchenObjectSO> validKitchenObjectSOList;

    private List<KitchenObjectSO> kitchenObjectsSOList;
    private void Awake()
    {
        kitchenObjectsSOList = new List<KitchenObjectSO>();
    }
    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO)
    {
        if (!validKitchenObjectSOList.Contains(kitchenObjectSO))
        {
            // not a valid Ingredient
            return false;
        }
        if (kitchenObjectsSOList.Contains(kitchenObjectSO))
        {
            // Already has this type
            return false;
        }
        else
        {
            kitchenObjectsSOList.Add(kitchenObjectSO);
            OnEngredientAdded?.Invoke(this, new OnEngredientAddedEventArgs
            {
                kitchenObjectSO = kitchenObjectSO
            });

            return true;

        }
    }

    public List<KitchenObjectSO> GetKitchenObjectSOList()
    {
        return kitchenObjectsSOList;
    }
}
