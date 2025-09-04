using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UiInvenSlot : MonoBehaviour
{
    public Image imageIcon;
    public TextMeshProUGUI textName;
    public int slotIndex { get; set; }
    
    private SaveItemData itemData;

    public void SetEmpty()
    {
        imageIcon.sprite = null;
        textName.text = string.Empty;
    }

    public void SetItem(SaveItemData data)
    {
        itemData = data;
        imageIcon.sprite = itemData.itemData.SpriteIcon;
        textName.text = itemData.itemData.StringName;
    }


}
