using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int _direction; // Переменная направления движения
    public float maxSpeed = 5f; // Переменная максимальной скорости
    private bool _isGrounded; // Переменная отвечающая за то, стоим ли мы на земле
    public float jumpForce = 5f; // Переменная силы прыжка
    private Rigidbody2D _rigidbody2D; // Переменная физики
    void Start() // Выполняется при запуске скрипта (Создании объекта с этим компонентом)
    {
        _rigidbody2D = GetComponent<Rigidbody2D>(); // Устанавливаем физику
    }
    void Update() // Выполняется каждый кадр
    {
        if (Input.GetKey(KeyCode.D)) // Проверяем нажата ли клавиша D
        {
            _direction = 1; // Устанавливаем положительное направление
        }
        else if (Input.GetKey(KeyCode.A)) // Проверяем нажата ли клавиша A
        {
            _direction = -1; // Устанавливаем отрицательное направление
        }
        else // Проверяем, что клавиши A и D не нажаты
        {
            _direction = 0; // Устанавливаем направление на 0, то есть без движения
        }

        if (Input.GetKey(KeyCode.Space) && _isGrounded) // Проверяем стоим ли мы на земле и нажата ли клавиша пробела
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce); // Устанавливаем скорость по оси Y на силу прыжка
        }
    }
    private void FixedUpdate() // Выполняется каждые 0.2 секунды
    {
        _rigidbody2D.velocity = new Vector2(maxSpeed * _direction, _rigidbody2D.velocity.y); // Устанавливаем скорость по оси X на максимальную скорость, умноженную на направление
    }
    private void OnCollisionEnter2D(Collision2D other) // Выполняется при столкновении
    {
        if (other.gameObject.CompareTag("Ground")) // Если столкнулись с объектом с тэгом "Ground"
        {
            _isGrounded = true; // Устанавливаем, что мы стоим на земле
        }
    }
    private void OnCollisionExit2D(Collision2D other) // Выполняется при отпускании касания
    {
        if (other.gameObject.CompareTag("Ground")) // Если больше не касаемся объекта с тэгом "Ground"
        {
            _isGrounded = false; // Устанавливаем, что мы не стоим на земле
        }
    }
}