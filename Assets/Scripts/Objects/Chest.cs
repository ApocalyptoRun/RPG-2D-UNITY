using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Chest : MonoBehaviour
{
    [SerializeField] private Item[] content;

    [SerializeField] private SpriteRenderer[] graphisms;
    [SerializeField] private Sprite[] openSprite;
    [SerializeField] private Sprite[] closedSprite;

    private GameManager manager;

    private InputAction interactAction;

    private bool isReach = false;
    private bool open = false;

    private void Start()
    {
        manager = GameManager.getInstance();
        interactAction = manager.GetInputs().actions.FindAction("Interact");
    }

    private void Update() 
    {
        float _interact = interactAction.ReadValue<float>();

        if (isReach && _interact > 0)
        {
            Open();
        }
        else if (!isReach)
        {
            Close();
        }
    }

    private void Close()
    {
        open = false;
        for (int i = 0; i < graphisms.Length; i++)
        {
            graphisms[i].sprite = closedSprite[i];
        }
    }

    private void Open()
    {

        open = true;

        EmptyChest();

        for (int i = 0; i < graphisms.Length; i++)
        {
            graphisms[i].sprite = openSprite[i];
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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            isReach = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            isReach = false; 
        }
    }
}
