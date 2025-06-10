using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float PlayerHP;
    public float MaxPlayerHP;
    public float PlayerDamage;
    public float CollectItems = 0f;
    public float PlayerMoney;
    public float PlayerOhco;
    public float MaxKvota;

    public Text Item;
    public Text HP;
    public Text Stamina;

    private GameObject player;
    private Transform Spawn;
    private bool ShowLossHp;
    private PlayerController controller;
    private int _Kvota;

    public void Start()
    {
        player = GameObject.Find("Player");
        Spawn = GameObject.Find("SpawnPlayer").transform;
        controller = player.GetComponent<PlayerController>();
        player.transform.position = Spawn.position;

    }

    public void Update()
    {
        Item.text = "Предметов:" + CollectItems;
        HP.text = "HP:" + PlayerHP;
        Stamina.text = "" + controller.Stamine;       

        if (PlayerHP == 0f)
        {
            ShowLossHp = true;
            Debug.Log("Игрок погиб");
            //После поражения игрока телепортирует в лобби, игрок теряет весь набранный лут, а также теряет 1 день
        }

        if (ShowLossHp)
        {
            //рестартим уровень с этого дня, и отбираем весь лут
            SceneManager.LoadScene("SampleScene");
            //вызываем окно смерти
        }
    }

    

  
}
