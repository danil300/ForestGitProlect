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
        Item.text = "���������:" + CollectItems;
        HP.text = "HP:" + PlayerHP;
        Stamina.text = "" + controller.Stamine;

        Kvota.text = "�����:" + " " + PlayerMoney + "/" + MaxKvota;
        Money.text = "�����:" + " " + PlayerMoney;
        Ohci.text = "�����:" + " " + PlayerOhco;
        Days.text = "����:" + " " + Day;
    }

    public void HPManager()
    {
        if (PlayerHP == 0f)
        {
            ShowLossHp = true;
            Debug.Log("����� �����");
            //����� ��������� ������ ������������� � �����, ����� ������ ���� ��������� ���, � ����� ������ 1 ����
        }

        if (ShowLossHp)
        {
            PlayerHP += 3;
            CollectItems = 0;
            Start();
            ResultDay();
            starter.FinishGame();
            ShowLossHp = false;
            //�������� ���� ������
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
        

        FinalMoneys.text = "�������� �����" + " " + PlayerOhco / 100;
        FinalOhco.text = "�������� �����:" + " " + PlayerOhco;
        FinalItems.text = "������� ���������:" + " " + MaxCollectItems;
        FinalKvota.text = "�����:" + PlayerMoney + "/" + MaxKvota;
        
        if (PlayerMoney >= MaxKvota)
        {
            FinalStatus.text = "������: ���������";
            ButtonNextKvota.SetActive(true);
        }
        else
        {
            FinalStatus.text = "������: ���������";
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
        ResultDays.text = "���� ��������:" + " " + leftDay;
        ResultDayItems.text = "��������� �������:" + " " + MaxCollectItemsDays;
        ResultDayKvota.text = "�����:" + " " + PlayerMoney + "/" + MaxKvota;
        ResultDayMoneys.text = "��������:" + " " + salary;
        ResultDayOhci.text = "�������� �����:" + " " + PlayerOhco;

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
