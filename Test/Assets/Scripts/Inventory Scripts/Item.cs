using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem",menuName = "Item/CreateNewItem")]
public class Item : ScriptableObject
{
    public string Name;
    public Color Color;
    public Sprite Icon;
    public ItemType Type;
    
    public enum ItemType
    {
        HEALTH
    }

    public void UseItem()
    {
        switch (Type)
        {
            case ItemType.HEALTH:
            {
                Debug.Log("IncreaseHealth");
                break;
            }
        }
        
    }
}
