using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private Transform shootpoint;
    [SerializeField] private GameObject bulletPreFab;
    //private EyeScript eyes;
    private float shootcooldown = 0.5f;
    private float cooldownTimer;

    private void Awake()
    {
        //eyes = GameObject.FindAnyObjectByType<EyeScript>();
    }
    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(eyes.hit.point);

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (cooldownTimer > shootcooldown)
            {
                WeaponShoot();
                cooldownTimer = 0;
            }
        }
        cooldownTimer += Time.deltaTime;
    }
    public void WeaponShoot()
    {
        Instantiate(bulletPreFab,shootpoint.position,Quaternion.identity);
    }
}
