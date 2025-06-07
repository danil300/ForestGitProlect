using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float PlayerHP;
    public float MaxPlayerHP;
    public float PlayerDamage;
    public float CollectItems = 0f;
    public float PlayerMoney;
    public float PlayerOhco;

    public Text money;
    public Text Item;
    public Text HP;

    private GameObject player;
    private Transform Spawn;
    private bool ShowLossHp;

    public void Start()
    {
        player = GameObject.Find("Player");
        Spawn = GameObject.Find("SpawnPlayer").transform;

        player.transform.position = Spawn.position;

    }

    public void Update()
    {
        money.text = "Монет:" + PlayerMoney;
        Item.text = "Предметов:" + CollectItems;
        HP.text = "Здоровье" + PlayerHP;


        if (PlayerHP == 0f)
        {
            player.transform.position = Spawn.position;
            ShowLossHp = true;
            Debug.Log("Игрок погиб");
            //После поражения игрока телепортирует в лобби, игрок теряет весь набранный лут, а также теряет 1 день
        }

        if (ShowLossHp)
        {
           //вызываем окно смерти
           //рестартим уровень с этого дня, и отбираем весь лут
        }
    }
}
