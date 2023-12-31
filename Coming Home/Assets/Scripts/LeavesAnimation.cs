using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavesAnimation : MonoBehaviour
{
    
    private Animator anim;

    public string animationName = "Leaves";

    private bool playerInside = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.speed = 0;
    }

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
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInside = false;
        }
    }

    private void Update()
    {
        if (playerInside)
        {
            anim.Play(animationName);
            Destroy(gameObject);
        }
    }
}
