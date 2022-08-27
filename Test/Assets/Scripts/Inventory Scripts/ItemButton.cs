using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : MonoBehaviour
{
    public Item Item;


    public void Click()
    {
        Item.UseItem();
        Destroy(gameObject);
    }
}
