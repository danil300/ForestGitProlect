using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //���������� ��� ���������� �������, ��� ����� �� ���. ����� ������!
    //����� Mathf � c# ��������� ������� ������� ��������� �������, � �������� ����� ���� �� ���������� ����������, ������� �� ��������� ���� ���-�� �� �������, � ���������� ��������� �� � ��� ����� �� ���� ����� �� ����
    
    public float speedPlayer = 6f;//��������
    public float speedJumpPlayer = 7f;//�������� ������
    public float gravity = -20f;//���� �������
    public float MouseSensivityPlayer = 2f;//���������������� ����
    

    private Camera PlayerCamera;//������
    private CharacterController CharacterController;//���������
    private Vector3 velocity;//������� ������
    private bool IsGrounded; //��������� �� ����� �� �����
    private float xRotation = 0f;//�������� ��������� ������

    public void Start()
    {
        CharacterController = GetComponent<CharacterController>();//�������� ���������
        PlayerCamera = Camera.main;//�������� ������
        Cursor.lockState = CursorLockMode.Locked;//�������� ������
    }

    public void Update()
    {
        //����������
        if (IsGrounded && velocity.y < 0)
        {
            velocity.y = 0f; // ���������� �������� �� Y, ���� �� �����
        }
        //������, ���� ����� ������ � ����� �� �����
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            velocity.y += Mathf.Sqrt(speedJumpPlayer * -2f * gravity); //������ ������ �� Y ����� ���������� ����������� ����� �� �������� � ���������� 
        }


        float moveX = Input.GetAxis("Horizontal");//��������� ������� A D
        float moveZ = Input.GetAxis("Vertical");//��������� ������� W S

        Vector3 move = transform.right * moveX + transform.forward * moveZ;//���������� ���������� ������ � ���� ����������
        velocity.y += gravity * Time.deltaTime;//��������� ����������

        CharacterController.Move(move * speedPlayer * Time.deltaTime);//������� ������
        CharacterController.Move(velocity * Time.deltaTime);//�������� � ������ ����������

        //���� �� ������� ����
        float mouseX = Input.GetAxis("Mouse X") * MouseSensivityPlayer;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensivityPlayer;

        xRotation -= mouseY; // ������� ������ �����/����
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);//����������� ���� �������� ������

        PlayerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);//�������� � ������� ������ ������ ������� ������� ������, ������
        transform.Rotate(Vector3.up * mouseX);//������� ������ � ���� �� �������
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




}
