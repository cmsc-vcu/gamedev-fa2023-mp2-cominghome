using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavesAnimation : MonoBehaviour
{
    private Animator anim;

    public string animationName = "Leaves";

    public InventoryManager.AllItems requiredItem = InventoryManager.AllItems.Shovel;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.speed = 0;
    }

    private bool HasRequiredItem(InventoryManager.AllItems itemRequired)
    {
        return InventoryManager.Instance.HasItem(itemRequired);
    }

    private void Update()
    {
         if (Input.GetKeyDown(KeyCode.E))
         {
              if (HasRequiredItem(requiredItem))
              {
                anim.speed = 1;
                anim.Play(animationName);
              }
         }
    }
}
