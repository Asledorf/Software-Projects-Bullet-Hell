using UnityEngine;

public class Shotgun : Powerup
{
    public float shoot_speed = 100;
    public GameObject bullet_prefab = null;
    float fire_rate = 0.3f;
    float accumulator = 0;
    // Update is called once per frame

    public float lifeTime = 5f;
    private float timer = 0;

    private void OnEnable()
    {
        timer = 0;
        gameObject.GetComponent<Gun>().enabled = false;
    }
    void Update()
    {
        if ((accumulator += Time.deltaTime) >= fire_rate && bullet_prefab)
        {
            Shoot();
            accumulator = 0;
        }
        if ((timer += Time.deltaTime) >= lifeTime)
        {
            gameObject.GetComponent<Gun>().enabled = true;
            this.enabled = false;
        }
    }

    void Shoot()
    {
        Vector3 shoot_direction = whiteboard.instance.rightJoystick.Direction;
        if (shoot_direction.y > 0)
        {
            if (shoot_direction.x > 0)
            {
                GameObject left = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
                left.GetComponent<bullet>().move = (Vector3.right + Vector3.up + Vector3.up).normalized * shoot_speed;
                Destroy(left, 3);
                GameObject middle = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
                middle.GetComponent<bullet>().move = (Vector3.right + Vector3.up).normalized * shoot_speed;
                Destroy(middle, 3);
                GameObject right = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
                right.GetComponent<bullet>().move = (Vector3.right + Vector3.right + Vector3.up).normalized * shoot_speed;
                Destroy(right, 3);
            }
            else if (shoot_direction.x < 0)
            {
                GameObject left = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
                left.GetComponent<bullet>().move = (Vector3.left + Vector3.up + Vector3.up).normalized * shoot_speed;
                Destroy(left, 3);
                GameObject middle = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
                middle.GetComponent<bullet>().move = (Vector3.left + Vector3.up).normalized * shoot_speed;
                Destroy(middle, 3);
                GameObject right = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
                right.GetComponent<bullet>().move = (Vector3.left + Vector3.left + Vector3.up).normalized * shoot_speed;
                Destroy(right, 3);
            }
            else
            {
                Up();
            }
        }

        else if (shoot_direction.y < 0)
        {
            if (shoot_direction.x > 0)
            {
                GameObject left = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
                left.GetComponent<bullet>().move = (Vector3.right + Vector3.down + Vector3.down).normalized * shoot_speed;
                Destroy(left, 3);
                GameObject middle = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
                middle.GetComponent<bullet>().move = (Vector3.right + Vector3.down).normalized * shoot_speed;
                Destroy(middle, 3);
                GameObject right = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
                right.GetComponent<bullet>().move = (Vector3.right + Vector3.right + Vector3.down).normalized * shoot_speed;
                Destroy(right, 3);
            }
            else if (shoot_direction.x < 0)
            {
                GameObject left = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
                left.GetComponent<bullet>().move = (Vector3.left + Vector3.down + Vector3.down).normalized * shoot_speed;
                Destroy(left, 3);
                GameObject middle = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
                middle.GetComponent<bullet>().move = (Vector3.left + Vector3.down).normalized * shoot_speed;
                Destroy(middle, 3);
                GameObject right = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
                right.GetComponent<bullet>().move = (Vector3.left + Vector3.left + Vector3.down).normalized * shoot_speed;
                Destroy(right, 3);
            }
            else
            {
                Down();
            }
        }

        else if (shoot_direction.x > 0)
        {
            Right();
        }

        else if (shoot_direction.x < 0)
        {
            Left();
        }
    }

    void Up()
    {
        GameObject up = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
        up.GetComponent<bullet>().move = Vector3.up.normalized * shoot_speed;
        Destroy(up, 3);
        GameObject left = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
        left.GetComponent<bullet>().move = (Vector3.left + Vector3.up + Vector3.up).normalized * shoot_speed;
        Destroy(left, 3);
        GameObject right = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
        right.GetComponent<bullet>().move = (Vector3.right + Vector3.up + Vector3.up).normalized * shoot_speed;
        Destroy(right, 3);
    }

    void Down()
    {
        GameObject down = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
        down.GetComponent<bullet>().move = Vector3.down.normalized * shoot_speed;
        Destroy(down, 3);
        GameObject left = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
        left.GetComponent<bullet>().move = (Vector3.left + Vector3.down + Vector3.down).normalized * shoot_speed;
        Destroy(left, 3);
        GameObject right = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
        right.GetComponent<bullet>().move = (Vector3.right + Vector3.down + Vector3.down).normalized * shoot_speed;
        Destroy(right, 3);
    }

    void Right()
    {
        GameObject right = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
        right.GetComponent<bullet>().move = Vector3.right.normalized * shoot_speed;
        Destroy(right, 3);
        GameObject up = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
        up.GetComponent<bullet>().move = (Vector3.right + Vector3.right + Vector3.up).normalized * shoot_speed;
        Destroy(up, 3);
        GameObject down = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
        down.GetComponent<bullet>().move = (Vector3.right + Vector3.right + Vector3.down).normalized * shoot_speed;
        Destroy(down, 3);
    }

    void Left()
    {
        GameObject left = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
        left.GetComponent<bullet>().move = Vector3.left.normalized * shoot_speed;
        Destroy(left, 3);
        GameObject up = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
        up.GetComponent<bullet>().move = (Vector3.left + Vector3.left + Vector3.up).normalized * shoot_speed;
        Destroy(up, 3);
        GameObject down = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
        down.GetComponent<bullet>().move = (Vector3.left + Vector3.left + Vector3.down).normalized * shoot_speed;
        Destroy(down, 3);
    }

    public override void PowerupEffect(GameObject target)
    {
        throw new System.NotImplementedException();
    }
}
