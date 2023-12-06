using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    public static DeliveryCounter Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public override void Interact(Player player)
    {
        if (player.HasKitchenObject())
        {
            if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject platekitchenObject))
            {
                // Only accepts Plates

                DeliveryManager.Instance.DeliverRecipe(platekitchenObject);

                player.GetKitchenObject().DestroySelf();

            }
        }
    }
        

}