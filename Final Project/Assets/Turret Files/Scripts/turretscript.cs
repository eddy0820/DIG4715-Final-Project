using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretscript : MonoBehaviour
{
    
     public float Range;

    //public Transform Target;

    bool Detected = false;

    Vector2 Direction;

    public GameObject AlarmLight;

    public GameObject Gun;

    public GameObject Bullet;
        
    public float fireRate;

    public float nextTimeToFire;

    public float timeBetweenShots;

    public Transform ShootPoint;

    public float force;

    public GameObject CurrentTarget;

    public Transform pivot;
    public Transform barrel;



    // Start is called before the first frame update
    void Start()
    {
        nextTimeToFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateNearestEnemy();

        if (Time.time >= nextTimeToFire)
        {
            if (CurrentTarget != null)
            {
                Shoot();
                nextTimeToFire = Time.time + timeBetweenShots;
            }
        }
  /*  
        Vector2 targetPos = Target.position;

        Direction = targetPos - (Vector2)transform.position;
    
      

        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);

        if(rayInfo)
        {
            if(rayInfo.collider.gameObject.tag == "Enemy")
            {
                if(Detected == false)
                {
                    Detected = true;
                    AlarmLight.GetComponent<SpriteRenderer>().color = Color.red;
                }
            }
            else
            {
                if(Detected == true)
                {
                    Detected = false;
                    AlarmLight.GetComponent<SpriteRenderer>().color = Color.blue;
                }
            }

        }

        if(Detected)
        {
            Gun.transform.up = Direction;
            if(Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }*/
    }

    void UpdateNearestEnemy()
    {
        GameObject currentNearestEnemy =  null;

        float distance = Mathf.Infinity;

        foreach(GameObject enemy in Enemies.enemies)
        {
            if (enemy != null)
            {
                float _distance = (transform.position - enemy.transform.position).magnitude;

                if (_distance < distance)
                {
                    distance = _distance;
                    currentNearestEnemy = enemy;
                }
            }

            
        }

        if (distance <= Range)
        {
            CurrentTarget = currentNearestEnemy;
            AlarmLight.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            CurrentTarget = null;
            AlarmLight.GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }

    void Shoot()
    {
            enemy enemyscript = CurrentTarget.GetComponent<enemy>();
        GameObject bulletIns = Instantiate(Bullet, barrel.position, pivot.rotation);
        //bulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * force);


    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
     
}
