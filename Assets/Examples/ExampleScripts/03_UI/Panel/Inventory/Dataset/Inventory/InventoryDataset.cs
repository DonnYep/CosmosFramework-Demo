﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cosmos;
using System;
/// <summary>
/// 暂时不抽象，这个可能是背包，也可能是仓库，具体遇到再实现
/// </summary>
[CreateAssetMenu(fileName = "NewInventory", menuName = "CosmosFramework/Implement/InventoryDataSet/Inventory")]
[Serializable]
public class InventoryDataset : DatasetBase
{
    [SerializeField]
     int inventoryCapacity = 0;
    public int InventoryCapacity { get { return inventoryCapacity; } set { inventoryCapacity = value; } }
    [SerializeField]
    List<ItemDataset> itemDataSets = new List<ItemDataset>();
    public List<ItemDataset> ItemDataSets { get { return itemDataSets; } set { itemDataSets = value; } }
    public override void Dispose()
    {
        itemDataSets.Clear();
        inventoryCapacity = 0;
    }
    public void AddItemDataSet(ItemDataset item)
    {
        if(itemDataSets.Contains(item))
        {
            item.IncrementItemNumber();
        }
        else
        {
            if (itemDataSets.Count >= inventoryCapacity)
                return;
            itemDataSets.Add(item);
            item.IncrementItemNumber();
        }
    }
}
