using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UiInvenSlotList : MonoBehaviour
{

    public UiInvenSlot prefab;
    public ScrollRect scrollRect;

    public int maxCount = 30;
    private int itemCount = 0;

    private List<UiInvenSlot> slotList = new List<UiInvenSlot>();
    private List<SaveItemData> testItemList = new List<SaveItemData>();

    public void Save()
    {
        var filePath = Path.Combine(Application.persistentDataPath, "test.json");
        var jsonText = JsonConvert.SerializeObject(testItemList);
        File.
    }


    private void Awake()
    {

    }

    private void Awake()
    {
        for (int i = 0; i < maxCount; ++i)
        {
            var newSlot = Instantiate(prefab, scrollRect.content);
            newSlot.slotIndex = i;
            newSlot.SetEmpty();
            newSlot.gameObject.SetActive(false);
            slotList.Add(newSlot);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddRandomItem();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            RemoveItem(0);
        }
    }

    private void UpdateSlots(List<SaveItemData> itemList)
    {
        if (slotList.Count < itemList.Count)
        {
            for (int i = slotList.Count; i < itemList.Count; i++)
            {
                var newSlot = Instantiate(prefab, scrollRect.content);
                newSlot.slotIndex = i;
                newSlot.SetEmpty();
                newSlot.gameObject.SetActive(false);
                slotList.Add(newSlot);
            }
        }

        for (int i = 0; i < slotList.Count; ++i)
        {
            if (i < itemList.Count)
            {
                slotList[i].SetItem(itemList[i]);
                slotList[i].gameObject.SetActive(true);
            }
            else
            {
                slotList[i].SetEmpty();
                slotList[i].gameObject.SetActive(false);
            }
        }
    }

    public void AddRandomItem()
    {
        var itemInstance = new SaveItemData();
        itemInstance.itemData = DataTableManger.ItemTable.GetRandom();

        testItemList.Add(itemInstance);
        UpdateSlots(testItemList);
    }

    public void RemoveItem(int slotIndex)
    {
        testItemList.RemoveAt(slotIndex);
        UpdateSlots(testItemList);
    }
}