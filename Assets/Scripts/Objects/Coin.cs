using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Coin : MonoBehaviour
{

    [SerializeField] private Item[] content;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            EmptyChest();
            Destroy(gameObject);
        }
    }

    private void EmptyChest()
    {
        foreach (var _item in content)
        {
            CharacterInfos.AddItem(_item._id, _item.number);
            _item.number = 0;
        }
    }
}
