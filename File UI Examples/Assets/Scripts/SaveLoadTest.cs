using UnityEngine;

public class SaveLoadTest : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            SaveLoadManager.Data = new SaveDataV3();

            int maxCount = UiInvenSlotList.maxCount;

            for (int i = 0; i < maxCount; i++)
            {
                var item = new SaveItemData();
                item.itemData = DataTableManger.ItemTable.GetRandom();
                SaveLoadManager.Data.ItemList.Add(item);
            }
            SaveLoadManager.Save();
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            if (SaveLoadManager.Load())
            {
                Debug.Log($"Loaded {SaveLoadManager.Data.ItemList.Count} items");
            }
            else
            {
                Debug.LogError("Failed to load item data");
            }
        }
    }
}
