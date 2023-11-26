using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public enum ItemID
{
    Money = 0,
}

[System.Serializable]
public class Item
{
    [SerializeField] private string name;
    public ItemID _id;                
    public int number = 0;              
}

public class CharacterInfos : MonoBehaviour
{
    private static Item[] inventory; 
    private int maxHealth = 5;
    public int health = 5;

    [SerializeField] private Transform heartPrefab;
    [SerializeField] private Transform heartParent;
    private List<GameObject> heartsObj = new List<GameObject>();

    private GameManager manager;
    [SerializeField] private TextMeshProUGUI moneyText;

    private void Start()
    {
        manager = GameManager.getInstance();
        inventory = new Item[1];
        inventory[0] = new Item();
        initHealth();
        TakeDamage(0);
    }

    private void Update()
    {
        moneyText.text = " : " + inventory[((int)ItemID.Money)].number;
    }

    private void initHealth()
    {
        health = maxHealth;

        for (int i = 0; i < maxHealth; i++)
        {
            Transform curHeart = Instantiate(heartPrefab);
            curHeart.SetParent(heartParent);
            heartsObj.Add(curHeart.gameObject);
        }
    }

    private void TakeDamage(int _damage)
    {
        health -= _damage;

        for (int i = 0; i < maxHealth; i++)
        {
            bool _state = i < health ? true : false;

            heartsObj[i].SetActive(_state);
        }
    }

    public static void AddItem(ItemID _id, int _number)
    {
        inventory[(int)_id].number += _number;
    }
}
