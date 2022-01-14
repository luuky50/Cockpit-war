using System.Collections;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField]
    PlaneInfo planeInfo;

    [SerializeField]
    Shooting shooting;

    public new Rigidbody2D rigidbody2D;

    float currentVelocity;
    string axisVertical = "Vertical";
    string axisHorizontal = "Horizontal";
    KeyCode brake = KeyCode.S;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        currentVelocity = planeInfo.velocity;
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
            planeInfo.velocity = currentVelocity - 1.4f;
        }
        else
        {
            planeInfo.velocity = currentVelocity;
        }




    }


    public void ReceivePower(Power power, int expireTime)
    {
        StartCoroutine(ExpirePower(power, expireTime));
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
    }

    public IEnumerator ExpirePower(Power power, int seconds)
    {
        print("Waiting");
        yield return new WaitForSeconds(seconds);
        print("Expire");
        switch (power)
        {
            case Power.Speed:
                planeInfo.velocity = 3;
                break;
            case Power.RapidFire:
                shooting.fireSpeed = 0.15f;
                break;
            case Power.Shield:

                break;
            case Power.Turning:
                planeInfo.turningSpeed = 2;
                break;
            default:
                break;
        }
        yield return null;
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
