using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Shop : MonoBehaviour
{
    [System.Serializable] class ShopItem {
        public Sprite Image;
        public int Price;
        public string Con;
        public bool IsPurchased = false;
    }

    [SerializeField] List<ShopItem> ShopItemsList;
    // Start is called before the first frame update
    GameObject ItemTemplate;
    GameObject g;
    [SerializeField] Transform ShopScrollView;
    Button buyBtn;
    private GameData gameData;
    public MainMenuManager mainMenuManager;

    private void Awake()
    {
        gameData = SaveSystem.Load();
    }
    void Start()
    {
        ItemTemplate = ShopScrollView.GetChild(0).gameObject;
        int len = ShopItemsList.Count;
        for(int i = 0; i < len; i++)
        {
            g = Instantiate(ItemTemplate, ShopScrollView);
            g.transform.GetChild(0).GetComponent<Image>().sprite = ShopItemsList[i].Image;
            g.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = ShopItemsList[i].Price.ToString();
            g.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = ShopItemsList[i].Con.ToString();
            buyBtn = g.transform.GetChild(2).GetComponent<Button>();
            buyBtn.interactable = !GameManager.instance.abilities[i];
            //gameData.abilitiesUnlocked[i] = !GameManager.instance.abilities[i];
            buyBtn.AddEventListener(i, OnShopItemBtnClicked);
        }
        Destroy(ItemTemplate);
    }

    void OnShopItemBtnClicked(int itemIndex)
    {
        //구입
        ShopItemsList[itemIndex].IsPurchased = true;
        //기록
        gameData.abilitiesUnlocked[itemIndex] = ShopItemsList[itemIndex].IsPurchased;
        gameData.totalCoins -= ShopItemsList[itemIndex].Price;
        mainMenuManager.uicoins.text = gameData.totalCoins.ToString();
        GameManager.instance.abilities[itemIndex] = ShopItemsList[itemIndex].IsPurchased;
        //세이브
        SaveSystem.Save(gameData);
        //버튼 비활성
        buyBtn = ShopScrollView.GetChild(itemIndex).GetChild(2).GetComponent<Button>();
        buyBtn.interactable = false;
        //buyBtn.transform.GetChild(0).GetComponent<Text>().text = "PURCHASED";
    }
}
