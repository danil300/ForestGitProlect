using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.UI;
using UnityEngine.SceneManagement;
=======
>>>>>>> alex_proto

public class GameManager : MonoBehaviour
{
    public float PlayerHP;
<<<<<<< HEAD
    public float MaxPlayerHP;
=======
>>>>>>> alex_proto
    public float PlayerDamage;
    public float CollectItems = 0f;
    public float PlayerMoney;
    public float PlayerOhco;
<<<<<<< HEAD
    public float MaxKvota;

    public Text Item;
    public Text HP;
    public Text Stamina;

    private GameObject player;
    private Transform Spawn;
    private bool ShowLossHp;
    private PlayerController controller;
    private int _Kvota;
=======

    private GameObject player;
    private Transform Spawn;
>>>>>>> alex_proto

    public void Start()
    {
        player = GameObject.Find("Player");
        Spawn = GameObject.Find("SpawnPlayer").transform;
<<<<<<< HEAD
        controller = player.GetComponent<PlayerController>();
        player.transform.position = Spawn.position;

=======

        player.transform.position = Spawn.position;
>>>>>>> alex_proto
    }

    public void Update()
    {
<<<<<<< HEAD
        Item.text = "���������:" + CollectItems;
        HP.text = "HP:" + PlayerHP;
        Stamina.text = "" + controller.Stamine;       

        if (PlayerHP == 0f)
        {
            ShowLossHp = true;
            Debug.Log("����� �����");
            //����� ��������� ������ ������������� � �����, ����� ������ ���� ��������� ���, � ����� ������ 1 ����
        }

        if (ShowLossHp)
        {
            //��������� ������� � ����� ���, � �������� ���� ���
            SceneManager.LoadScene("SampleScene");
            //�������� ���� ������
        }
    }

    

  
=======
       if (PlayerHP == 0f)
       {
            player.transform.position = Spawn.position;
            PlayerHP += 3;
            Debug.Log("����� �����");
            //����� ��������� ������ ������������� � �����, ����� ������ ���� ��������� ���, � ����� ������ 1 ����
       }
    }
>>>>>>> alex_proto
}
