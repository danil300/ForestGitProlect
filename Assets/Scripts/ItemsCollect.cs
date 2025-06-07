using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsCollect : MonoBehaviour
{
    private bool itemComplet;//����� ��������� � ���� ������������ ��� ���?
    private GameManager manager;

    public void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            itemComplet = true;//����� � ����
            //��� ������� �� ������� �� ����� ��������������,� ����� ����� ���������� ������, ��� ���� ����� ���������
            Debug.Log("E ���������");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            itemComplet = false;//����� �� � ����
        }
    }

    public void Update()
    {
        //���� ����� � ���� ����� E 
        if (Input.GetKeyDown(KeyCode.E) && itemComplet)
        {
            Destroy(gameObject);//������ �����������
            manager.CollectItems += 1;
            Debug.Log("������� ������!");
        }
    }
}
