using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField]
    PlaneInfo planeInfo;

    [SerializeField]
    Shooting shooting;

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
        float currentVelocity = planeInfo.velocity;
        if (Input.GetKey(brake))
        {
            planeInfo.velocity = 1.3f;
        }
        else
        {
            planeInfo.velocity = currentVelocity;
        }
        print(vertical);




    }

    public void ReceiverPower(Power power)
    {
        switch (power)
        {
            case Power.Speed:
                planeInfo.velocity = 6;
                break;
            case Power.RapidFire:
                print("Rapid");
                shooting.fireSpeed = 0.08f;
                break;
            case Power.Shield:

                break;
            case Power.Turning:
                planeInfo.turningSpeed = 4;
                break;
            default:
                break;
        }
        print(power);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
