using UnityEngine;
using System;

public class SaveItemData
{
    public Guid instanceId;
    public ItemData itemData;
    public DateTime creationTime;

    public SaveItemData()
    {
        instanceId = Guid.NewGuid();
        creationTime = DateTime.Now;
    }
}
