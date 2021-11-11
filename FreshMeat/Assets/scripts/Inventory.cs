using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<ItemStack> items;
    public Text inventoryText;

    void AddItem (string item)
    {
        var alreadyHadIt = false;
        foreach (var i in items)
        {
            if (item == i.Name)
            {
                i.count++;
                alreadyHadIt = true;
            }
        }

        if (!alreadyHadIt)
        {
            items.Add(new ItemStack(item));
        }

        UpdateUI();
    }

    void UpdateUI ()
    {
        string text = "";
        foreach (var i in items)
        {
            text += i.Name + " x" + i.count + "\n";
        }
        inventoryText.text = text;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var animal = collision.gameObject.GetComponent<Animal>();
        if (animal != null) //if the player has hit an animal, add the animals meat to inventory and destroy animal
        {
            AddItem(animal.meat);
            Destroy(collision.gameObject);
        }
    }
}

[System.Serializable]
public class ItemStack
{
    public string Name;
    public int count;

    public ItemStack(string newName, int newCount = 1)
    {
        Name = newName;
        count = newCount;
    }
}

public class Menu
{
    public static List<string> meatList = new List<string>
    {
        "pork",
        "beef",
        "chicken"
    };
}
