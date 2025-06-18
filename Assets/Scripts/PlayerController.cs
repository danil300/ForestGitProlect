using System.Collections;
using UnityEngine;
using System.Threading.Tasks;

public class PlayerController : MonoBehaviour
{
    //Специально для Александра пояснил, что здесь да как. Удачи понять!
    //Метод Mathf в c# считается методом сложной трёхмерной алгебры, в орсенале лежат вещи из профильной математики, поэтому не удивляйся если что-то не понятно, я посторался объяснить, но я сам особо за этот метод не щарю

    //нужно сделать:  привизать это всё к анимациям
    
    public float speedPlayer = 6f;//скорость
    public float speedJumpPlayer = 7f;//скорость прыжка
    public float gravity = -20f;//сила тяжести
    public float MouseSensivityPlayer = 2f;//чувствительность мыши

    public float maxStamine = 100f;
    public float regenStamine = 2f;
    public float Stamine;

    public Transform Eyes;
    public Transform ShiftPos;

    public Animator anim;

    private Camera PlayerCamera;//камера
    private CharacterController CharacterController;//компонент
    private Vector3 velocity;//главный вектор
    private bool IsGrounded; //находится ли игрок на земле
    private float xRotation = 0f;//хранение поворотов игрока
    private bool Sange;

    private Transform cameraPos;
    

    public void Start()
    {
        CharacterController = GetComponent<CharacterController>();//получаем компонент
        PlayerCamera = Camera.main;//получаем камеру
        cameraPos = GameObject.Find("View").transform;
        Cursor.lockState = CursorLockMode.Locked;//скрываем курсор
        Stamine = maxStamine;
        cameraPos.position = Eyes.transform.position;
        StartCoroutine(RegenStamin());

    }

    public void Update()
    {

      

        //гравитация
        if (IsGrounded && velocity.y < 0)
        {
            velocity.y = 0f; // Сбрасываем скорость по Y, если на земле
        }
        //прыжок, если нажат пробел и игрок на земле
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded && Stamine > 10)
        {
            velocity.y += Mathf.Sqrt(speedJumpPlayer * -2f * gravity); //меняем вектор по Y через вычисление квадратного корня из скорости и гравитации 
            Stamine -= 10;
        }


        float moveX = Input.GetAxis("Horizontal");//считывает нажатие A D
        float moveZ = Input.GetAxis("Vertical");//считывает нажатие W S

        Vector3 move = transform.right * moveX + transform.forward * moveZ;//объединяем считывание клавиш в одну перемменую
        velocity.y += gravity * Time.deltaTime;//приминяем гравитацию

        CharacterController.Move(move * speedPlayer * Time.deltaTime);//двигаем игрока
        CharacterController.Move(velocity * Time.deltaTime);//движение с учётом гравитации

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
            //ввод со стороны мыши
            float mouseX = Input.GetAxis("Mouse X") * MouseSensivityPlayer;
            float mouseY = Input.GetAxis("Mouse Y") * MouseSensivityPlayer;

            xRotation -= mouseY; // поворот камеры вверх/вниз
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);//ограничение угла поворота камеры

            PlayerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);//вращение с помощью метода чётырёх мерного вектора Эйлера, камеры
            transform.Rotate(Vector3.up * mouseX);//вращяем игрока в след за камерой

        }
       

        //спринт
        if (Input.GetKey(KeyCode.LeftShift) && Stamine >= 2 && Sange == false)
        {
            speedPlayer = 15f;
            Debug.Log("Игрок  бежит");          
            Stamine -= 0.055f;

            if (Stamine < 0)
            {
                Stamine = 0;
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || Stamine <= 2)
        {
            speedPlayer = 6f;
            Debug.Log("Игрок не бежит");
        }

        //присест
        if (Input.GetKey(KeyCode.C))
        {
            cameraPos.position = ShiftPos.position;
            speedPlayer = 3f;
            Sange = true;
            Debug.Log("Присел");
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            cameraPos.position = Eyes.position;
            speedPlayer = 6f;
            Sange = false;
            Debug.Log("Встал");
        }

    }
    //проверяем касается ли игрок земли(земля обозначаеться если на объекте есть тег Ground)
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            IsGrounded = true;// касается
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            IsGrounded = false;// не касается
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
