using UnityEngine;

public class SaveLoadTest : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SaveLoadManager.Data = new SaveDataV3();

            int maxCount = UiInvenSlotList.maxCount;

            for (int i = 0; i < maxCount; i++)
            {
                var item = new SaveItemData();
                item.itemData = DataTableManger.ItemTable.GetRandom();
                SaveLoadManager.Data.Items.Add(item);
            }

            SaveLoadManager.Save();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SaveLoadManager.Load();

            Debug.Log(SaveLoadManager.Data.Items);
        }
    }
}
