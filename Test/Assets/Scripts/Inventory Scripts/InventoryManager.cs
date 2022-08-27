using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using  UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    
    public List<Item> Items = new List<Item>();
    public GameObject Content;

    public GameObject ItemButton;
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void AddItem(Item i)
    {
        Items.Add(i);
        GameObject item = Instantiate(ItemButton, Content.transform);

        item.GetComponent<ItemButton>().Item = i;
        item.GetComponent<Image>().sprite = i.Icon;
        item.transform.GetChild(0).GetComponent<Text>().text = i.Name;

    }
}
