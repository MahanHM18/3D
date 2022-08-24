using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private Item[] items;

    private int currentItem;

    void Start()
    {
        currentItem = 0;

        foreach (var item in items)
        {
            item.gameObject.SetActive(false);
        }

        items[currentItem].gameObject.SetActive(true);
    }


    void Update()
    {
        SwithWithKeyboard();
        SwithWithScroll();
    }

    private void SelectItem(int index)
    {

        items[currentItem].gameObject.SetActive(false);
        items[index].gameObject.SetActive(true);
        currentItem = index;
    }


    private void SwithWithKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SelectItem(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SelectItem(1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            SelectItem(2);

    }

    private void SwithWithScroll()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentItem >= items.Length - 1)
                currentItem = 0;
            else
                currentItem++;

            foreach (var item in items)
            {
                item.gameObject.SetActive(false);
            }

            SelectItem(currentItem);

        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentItem <= 0)
                currentItem = items.Length -1  ;
            else
                currentItem--;

            foreach (var item in items)
            {
                item.gameObject.SetActive(false);
            }

            SelectItem(currentItem);

        }
    }

    public Item GetCurrentItem()
    {
        return items[currentItem];
    }
}
