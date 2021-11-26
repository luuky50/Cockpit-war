using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField]
    PlaneInfo planeInfo;

    public new Rigidbody2D rigidbody2D;

    string axisVertical = "Vertical";
    string axisHorizontal = "Horizontal";
    KeyCode brake = KeyCode.S;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (planeInfo.isPlayer2)
        {
            axisVertical = "Vertical2";
            axisHorizontal = "Horizontal2";
            brake = KeyCode.DownArrow;

        }

        float vertical = Input.GetAxis(axisVertical);
        float horizontal = Input.GetAxis(axisHorizontal) * planeInfo.turningSpeed;
    
        rigidbody2D.rotation += -horizontal * planeInfo.turningSpeed;
        Vector2 speed = rigidbody2D.velocity = rigidbody2D.transform.up * planeInfo.velocity;
        if (Input.GetKey(brake))
        {
            planeInfo.velocity = 1.3f;
        }
        else
        {
            planeInfo.velocity = 3;
        }
        print(vertical);




    }
}