using System.Collections;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField]
    PlaneInfo planeInfo;

    public Shooting shooting;

    public new Rigidbody2D rigidbody2D;

    public GameObject shield;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            print("Increasing fire speed");
            shooting.IcreaseFireSpeed();
        }
    }


    public void ReceivePower(Power power, int expireTime)
    {
        StartCoroutine(ExpirePower(power, expireTime));
        switch (power)
        {
            case Power.Speed:
                currentVelocity += 3;
                break;
            case Power.RapidFire:
                print("Rapid");
                planeInfo.fireSpeed -= 0.08f;
                break;
            case Power.Shield:
                shield.SetActive(true);
                break;
            case Power.Turning:
                planeInfo.turningSpeed += 1.5f;
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
                currentVelocity -= 3;
                break;
            case Power.RapidFire:
                planeInfo.fireSpeed += 0.08f;
                break;
            case Power.Shield:
                print("Shield can't expire");
                break;
            case Power.Turning:
                planeInfo.turningSpeed -= 1.5f;
                break;
            default:
                break;
        }
        yield return null;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Colliding with tag:" + collision.gameObject.tag);
        if (collision.gameObject.tag == "Player" && !shield.activeSelf)
        {
            PlaneHealthManagement planeHealth = GetComponent<PlaneHealthManagement>();
            Instantiate(planeHealth.explosionPreFab, transform.position, transform.rotation);
            GameManager.instance.Respawn(planeHealth.playerNumber.text, gameObject);
        }
        else if(collision.gameObject.tag == "Player")
        {
            GameManager.instance.puntentelling.AddPoint(planeInfo.isPlayer2);
            shield.SetActive(false);
        }
    }
}
