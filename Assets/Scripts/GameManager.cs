using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float PlayerHP;
    public float MaxPlayerHP;
    public float PlayerDamage;
    public float CollectItems = 0f;
    public float MaxCollectItems;
    public float MaxCollectItemsDays;
    public float PlayerMoney;
    public float PlayerOhco;
    public float MaxKvota;
    public float Day;
    public GameObject FinalWindow;
    public GameObject ResultDayWindow;
    public GameObject ButtonNextKvota;

    public Text Item;
    public Text HP;
    public Text Stamina;

    public TextMeshPro Kvota;
    public TextMeshPro Money;
    public TextMeshPro Ohci;
    public TextMeshPro Days;

    public Text FinalMoneys;
    public Text FinalItems;
    public Text FinalOhco;
    public Text FinalKvota;
    public Text FinalStatus;

    public Text ResultDayMoneys;
    public Text ResultDayOhci;
    public Text ResultDayItems;
    public Text ResultDayKvota;
    public Text ResultDays;

    private GameObject player;
    private Transform Spawn;
    private bool ShowLossHp;
    private PlayerController controller;
    private ButtonStarter starter;


    public void Start()
    {
        player = GameObject.Find("Player");
        Spawn = GameObject.Find("SpawnPlayer").transform;
        controller = player.GetComponent<PlayerController>();
        player.transform.position = Spawn.position;
        starter = GameObject.Find("Button").GetComponent<ButtonStarter>();

        FinalWindow.SetActive(false);
        ButtonNextKvota.SetActive(false);
        ResultDayWindow.SetActive(false);

    }

    public void Update()
    {
        InfoText();
        HPManager();
        FinalDays();
    }

    public void InfoText()
    {
        Item.text = "Предметов:" + CollectItems;
        HP.text = "HP:" + PlayerHP;
        Stamina.text = "" + controller.Stamine;

        Kvota.text = "Квота:" + " " + PlayerMoney + "/" + MaxKvota;
        Money.text = "Денег:" + " " + PlayerMoney;
        Ohci.text = "Очков:" + " " + PlayerOhco;
        Days.text = "День:" + " " + Day;
    }

    public void HPManager()
    {
        if (PlayerHP == 0f)
        {
            ShowLossHp = true;
            Debug.Log("Игрок погиб");
            //После поражения игрока телепортирует в лобби, игрок теряет весь набранный лут, а также теряет 1 день
        }

        if (ShowLossHp)
        {
            PlayerHP += 3;
            CollectItems = 0;
            Start();
            ResultDay();
            starter.FinishGame();
            ShowLossHp = false;
            //вызываем окно смерти
        }
    }

    public void FinalDays()
    {
        if (Day > 3)
        {
            FinalWindow.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Pause.IsPause = true;
        }
        

        FinalMoneys.text = "Получено денег" + " " + PlayerOhco / 100;
        FinalOhco.text = "Получено очков:" + " " + PlayerOhco;
        FinalItems.text = "Собрано предметов:" + " " + MaxCollectItems;
        FinalKvota.text = "Квота:" + PlayerMoney + "/" + MaxKvota;
        
        if (PlayerMoney >= MaxKvota)
        {
            FinalStatus.text = "Статус: выполнена";
            ButtonNextKvota.SetActive(true);
        }
        else
        {
            FinalStatus.text = "Статус: провалена";
        }

    }

    public void NextKvota()
    {
        FinalWindow.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Pause.IsPause = false;
        player.transform.position = Spawn.position;
        Day = 1;
        PlayerMoney = 0;
        PlayerOhco = 0;
        MaxKvota *= 2;
        MaxCollectItems = 0;

    }

    public void ResultDay()
    {
        float salary = PlayerOhco / 100;

        float a = 4f;
        float leftDay = a -= Day;
        ResultDayWindow.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Pause.IsPause = true;

        PlayerMoney += salary;
        ResultDays.text = "Дней осталось:" + " " + leftDay;
        ResultDayItems.text = "Предметов собрано:" + " " + MaxCollectItemsDays;
        ResultDayKvota.text = "Квота:" + " " + PlayerMoney + "/" + MaxKvota;
        ResultDayMoneys.text = "Зарплата:" + " " + salary;
        ResultDayOhci.text = "получено очков:" + " " + PlayerOhco;

    }

    public void CloseResultDayWindow()
    {
        ResultDayWindow.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Pause.IsPause = false;
        PlayerOhco = 0;
        MaxCollectItemsDays = 0;

    }

    

  
}
