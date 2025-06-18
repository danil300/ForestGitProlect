using System.Collections;
using UnityEngine;
using System.Threading.Tasks;

public class PlayerController : MonoBehaviour
{
    //���������� ��� ���������� �������, ��� ����� �� ���. ����� ������!
    //����� Mathf � c# ��������� ������� ������� ��������� �������, � �������� ����� ���� �� ���������� ����������, ������� �� ��������� ���� ���-�� �� �������, � ���������� ���������, �� � ��� ����� �� ���� ����� �� ����

    //����� �������:  ��������� ��� �� � ���������
    
    public float speedPlayer = 6f;//��������
    public float speedJumpPlayer = 7f;//�������� ������
    public float gravity = -20f;//���� �������
    public float MouseSensivityPlayer = 2f;//���������������� ����

    public float maxStamine = 100f;
    public float regenStamine = 2f;
    public float Stamine;

    public Transform Eyes;
    public Transform ShiftPos;

    public Animator anim;

    private Camera PlayerCamera;//������
    private CharacterController CharacterController;//���������
    private Vector3 velocity;//������� ������
    private bool IsGrounded; //��������� �� ����� �� �����
    private float xRotation = 0f;//�������� ��������� ������
    private bool Sange;

    private Transform cameraPos;
    

    public void Start()
    {
        CharacterController = GetComponent<CharacterController>();//�������� ���������
        PlayerCamera = Camera.main;//�������� ������
        cameraPos = GameObject.Find("View").transform;
        Cursor.lockState = CursorLockMode.Locked;//�������� ������
        Stamine = maxStamine;
        cameraPos.position = Eyes.transform.position;
        StartCoroutine(RegenStamin());

    }

    public void Update()
    {

      

        //����������
        if (IsGrounded && velocity.y < 0)
        {
            velocity.y = 0f; // ���������� �������� �� Y, ���� �� �����
        }
        //������, ���� ����� ������ � ����� �� �����
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded && Stamine > 10)
        {
            velocity.y += Mathf.Sqrt(speedJumpPlayer * -2f * gravity); //������ ������ �� Y ����� ���������� ����������� ����� �� �������� � ���������� 
            Stamine -= 10;
        }


        float moveX = Input.GetAxis("Horizontal");//��������� ������� A D
        float moveZ = Input.GetAxis("Vertical");//��������� ������� W S

        Vector3 move = transform.right * moveX + transform.forward * moveZ;//���������� ���������� ������ � ���� ����������
        velocity.y += gravity * Time.deltaTime;//��������� ����������

        CharacterController.Move(move * speedPlayer * Time.deltaTime);//������� ������
        CharacterController.Move(velocity * Time.deltaTime);//�������� � ������ ����������

        if (moveX > 0 || moveZ > 0 || moveX < 0 || moveZ < 0)
        {
            anim.SetBool("motion", true);
        }
        else if (moveX == 0 || moveZ == 0)
        {
            anim.SetBool("motion", false);
        }

        if (Pause.IsPause == false)
        {
            //���� �� ������� ����
            float mouseX = Input.GetAxis("Mouse X") * MouseSensivityPlayer;
            float mouseY = Input.GetAxis("Mouse Y") * MouseSensivityPlayer;

            xRotation -= mouseY; // ������� ������ �����/����
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);//����������� ���� �������� ������

            PlayerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);//�������� � ������� ������ ������ ������� ������� ������, ������
            transform.Rotate(Vector3.up * mouseX);//������� ������ � ���� �� �������

        }
       

        //������
        if (Input.GetKey(KeyCode.LeftShift) && Stamine >= 2 && Sange == false)
        {
            speedPlayer = 15f;
            Debug.Log("�����  �����");          
            Stamine -= 0.055f;

            if (Stamine < 0)
            {
                Stamine = 0;
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || Stamine <= 2)
        {
            speedPlayer = 6f;
            Debug.Log("����� �� �����");
        }

        //�������
        if (Input.GetKey(KeyCode.C))
        {
            cameraPos.position = ShiftPos.position;
            speedPlayer = 3f;
            Sange = true;
            Debug.Log("������");
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            cameraPos.position = Eyes.position;
            speedPlayer = 6f;
            Sange = false;
            Debug.Log("�����");
        }

    }
    //��������� �������� �� ����� �����(����� ������������� ���� �� ������� ���� ��� Ground)
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            IsGrounded = true;// ��������
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            IsGrounded = false;// �� ��������
        }
    }

    IEnumerator RegenStamin()
    {
        while (true)
        {
            if (Stamine < maxStamine)
            {
                Stamine += regenStamine;
                yield return new WaitForSeconds(1f);
            }
            else
            {
                yield return null;
            }
        }
    }

   

    



}
