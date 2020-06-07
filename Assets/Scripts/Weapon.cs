using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float fireRate = 0;
    public float Damage = 10;
    public LayerMask whatToHit;


    public Transform ProjectileTrailPrefab;
    public Transform HitPrefab;

    float timeToFire = 0;
    Transform firePoint;
    private AudioManager audioManager;
    public string shootSoundName;

    // Start is called before the first frame update
    void Awake()
    {
        firePoint = transform.Find("FirePoint");
        if (firePoint == null){
            Debug.LogError("No firepoint!");
        }

        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogError("No no");
        }


    }

    // Update is called once per frame
    void Update()
    {

        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot ();
                audioManager.PlaySound(shootSoundName);
            }
        }
        else
        {
            if (Input.GetButton ("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
                audioManager.PlaySound(shootSoundName);
            }
        }
        
    }
    void Shoot ()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition-firePointPosition, 100, whatToHit);
       
        Debug.DrawLine(firePointPosition, (mousePosition-firePointPosition)*200);
        if (hit.collider != null)
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
        }
        Vector3 hitPos;
        Vector3 hitNormal;
        if (hit.collider == null)
        {
            hitPos = (mousePosition - firePointPosition) * 200;
            hitNormal = new Vector3(9999, 9999, 9999);
        }
        else
        {
            hitPos = hit.point;
            hitNormal = hit.normal;
        }
        Effect(hitPos, hitNormal);
    }
    void Effect(Vector3 hitPos, Vector3 hitNormal) 
    {
        Transform trail = Instantiate(ProjectileTrailPrefab, firePoint.position, firePoint.rotation) as Transform;
        LineRenderer lr = trail.GetComponent<LineRenderer>();


        if (lr != null)
        {
            lr.SetPosition(0, firePoint.position);
            lr.SetPosition(1, hitPos);

        }
        Destroy(trail.gameObject, 0.08f);

        if (hitNormal != new Vector3 (9999, 9999, 9999))
        {
            Transform hitParticle = Instantiate(HitPrefab, hitPos, Quaternion.FromToRotation(Vector3.right, hitNormal)) as Transform;
            Destroy(hitParticle.gameObject, 1f);
        }

    }
}
