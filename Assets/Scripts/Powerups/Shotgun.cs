using UnityEngine;

public class Shotgun : BasicShoot
{
    public float shoot_speed = 100;

    RightJoystick joystick;

    public float lifeTime = 5f;
    private float timer = 0;

    public void Awake()
    {
        joystick = GetComponent<RightJoystick>();
        fire_rate = 0.15f;
    }

    public void OnEnable()
    {
        if (joystick == null) joystick = GetComponent<RightJoystick>();
        if (joystick.shotType != null) joystick.shotType.enabled = false;

        joystick.shotType = this;
        joystick.fire_rate = fire_rate;
    }

    private void Update()
    {
        if ((timer += Time.deltaTime) >= lifeTime)
        {
            GetComponent<Gun>().enabled = true;
            this.enabled = false;
        }
    }

    public override bool Shoot(Vector2 direction, GameObject bullet)
    {
        GameObject middle = Instantiate(bullet, transform.position, Quaternion.identity, null);
        middle.GetComponent<bullet>().move = direction.normalized * shoot_speed;
        Destroy(middle, 3);
        GameObject left = Instantiate(bullet, transform.position, Quaternion.identity, null);
        left.GetComponent<bullet>().move = rotate(direction, Mathf.Deg2Rad * 30).normalized * shoot_speed;
        Destroy(left, 3);
        GameObject right = Instantiate(bullet, transform.position, Quaternion.identity, null);
        right.GetComponent<bullet>().move = rotate(direction, Mathf.Deg2Rad * -30).normalized * shoot_speed;
        Destroy(right, 3);
            

        return false;
    }

    private void OnDisable()
    {
        timer = 0;
    }

    Vector2 rotate(Vector2 v, float delta)
    {
        return new Vector2(
            v.x * Mathf.Cos(delta) - v.y * Mathf.Sin(delta),
            v.x * Mathf.Sin(delta) + v.y * Mathf.Cos(delta)
        );
    }
}
