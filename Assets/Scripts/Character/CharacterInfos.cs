using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CharacterInfos : MonoBehaviour
{
    public int moneyCount = 0;
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
        initHealth();
        TakeDamage(4);
    }

    private void Update()
    {
        moneyText.text = " : " + moneyCount;
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

}
