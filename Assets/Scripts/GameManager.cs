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
        money.text = "�����:" + PlayerMoney;
        Item.text = "���������:" + CollectItems;
        HP.text = "��������" + PlayerHP;


        if (PlayerHP == 0f)
        {
            player.transform.position = Spawn.position;
            ShowLossHp = true;
            Debug.Log("����� �����");
            //����� ��������� ������ ������������� � �����, ����� ������ ���� ��������� ���, � ����� ������ 1 ����
        }

        if (ShowLossHp)
        {
           //�������� ���� ������
           //��������� ������� � ����� ���, � �������� ���� ���
        }
    }
}
