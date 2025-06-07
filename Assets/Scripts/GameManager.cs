using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float PlayerHP;
    public float PlayerDamage;
    public float CollectItems = 0f;
    public float PlayerMoney;
    public float PlayerOhco;

    private GameObject player;
    private Transform Spawn;

    public void Start()
    {
        player = GameObject.Find("Player");
        Spawn = GameObject.Find("SpawnPlayer").transform;

        player.transform.position = Spawn.position;
    }

    public void Update()
    {
       if (PlayerHP == 0f)
       {
            player.transform.position = Spawn.position;
            PlayerHP += 3;
            Debug.Log("����� �����");
            //����� ��������� ������ ������������� � �����, ����� ������ ���� ��������� ���, � ����� ������ 1 ����
       }
    }
}
