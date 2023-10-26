using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorBehavior : MonoBehaviour
{
    public string sceneToLoad;

    [SerializeField] private Text doorText;

    private bool playerInside = false;

    [SerializeField] InventoryManager.AllItems requiredItem;

    public bool HasRequiredItem(InventoryManager.AllItems itemRequired)
    {
        if (InventoryManager.Instance._inventoryItems.Contains(itemRequired))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInside = true;
            if (!HasRequiredItem(requiredItem))
            {
                doorText.text = "Door Locked. Need Key.";
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInside = false;
            doorText.text = "";
        }
    }

    private void Update()
    {
        if (playerInside)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (HasRequiredItem(requiredItem))
                {
                    SceneManager.LoadScene(sceneToLoad);
                }
            }
        }
    }
}
