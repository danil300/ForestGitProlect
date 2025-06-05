using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //—пециально дл€ јлександра по€снил, что здесь да как. ”дачи пон€ть!
    //ћетод Mathf в c# считаетс€ методом сложной трЄхмерной алгебры, в орсенале лежат вещи из профильной математики, поэтому не удивл€йс€ если что-то не пон€тно, € посторалс€ объ€снить но € сам особо за этот метод не щарю
    
    public float speedPlayer = 6f;//скорость
    public float speedJumpPlayer = 7f;//скорость прыжка
    public float gravity = -20f;//сила т€жести
    public float MouseSensivityPlayer = 2f;//чувствительность мыши
    

    private Camera PlayerCamera;//камера
    private CharacterController CharacterController;//компонент
    private Vector3 velocity;//главный вектор
    private bool IsGrounded; //находитс€ ли игрок на земле
    private float xRotation = 0f;//хранение поворотов игрока

    public void Start()
    {
        CharacterController = GetComponent<CharacterController>();//получаем компонент
        PlayerCamera = Camera.main;//получаем камеру
        Cursor.lockState = CursorLockMode.Locked;//скрываем курсор
    }

    public void Update()
    {
        //гравитаци€
        if (IsGrounded && velocity.y < 0)
        {
            velocity.y = 0f; // —брасываем скорость по Y, если на земле
        }
        //прыжок, если нажат пробел и игрок на земле
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            velocity.y += Mathf.Sqrt(speedJumpPlayer * -2f * gravity); //мен€ем вектор по Y через вычисление квадратного корн€ из скорости и гравитации 
        }


        float moveX = Input.GetAxis("Horizontal");//считывает нажатие A D
        float moveZ = Input.GetAxis("Vertical");//считывает нажатие W S

        Vector3 move = transform.right * moveX + transform.forward * moveZ;//объедин€ем считывание клавиш в одну перемменую
        velocity.y += gravity * Time.deltaTime;//примин€ем гравитацию

        CharacterController.Move(move * speedPlayer * Time.deltaTime);//двигаем игрока
        CharacterController.Move(velocity * Time.deltaTime);//движение с учЄтом гравитации

        //ввод со стороны мыши
        float mouseX = Input.GetAxis("Mouse X") * MouseSensivityPlayer;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensivityPlayer;

        xRotation -= mouseY; // поворот камеры вверх/вниз
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);//ограничение угла поворота камеры

        PlayerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);//вращение с помощью метода чЄтырЄх мерного вектора Ёйлера, камеры
        transform.Rotate(Vector3.up * mouseX);//вращ€ем игрока в след за камерой
    }
    //провер€ем касаетс€ ли игрок земли(земл€ обозначаетьс€ если на объекте есть тег Ground)
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            IsGrounded = true;// касаетс€
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            IsGrounded = false;// не касаетс€
        }
    }




}
