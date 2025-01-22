using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 velocity;
    [SerializeField] private float moveSpeed = 3f;

    [SerializeField] private int healtPoints = 3;

    //private Renderer renderer;

    private MeshRenderer meshRenderer;
    private Material material;

    private Transform player;



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
        material = meshRenderer.material;
        material.color = Color.red;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        RotateTowardsPlayer();
        MoveForward();
    }

    private void RotateTowardsPlayer()
    {
        Vector3 playerDirection = player.position - transform.position;
        float angle = Mathf.Atan2(playerDirection.x, playerDirection.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }

    private void MoveForward()
    {
        Vector3 moveDirection = transform.forward;

        velocity.x = moveDirection.x * moveSpeed;
        velocity.z = moveDirection.z * moveSpeed;
        velocity.y = rb.velocity.y;

        rb.velocity = velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            healtPoints -= 1;

            material.color = Color.white;
            StartCoroutine(ResetMaterialColor());

        }
    }

    private IEnumerator ResetMaterialColor()
    {

        yield return new WaitForSeconds(0.15f);

        material.color = Color.red;
    }

    private void CheckHealth()
    {
        if(healtPoints <= 0)
        {
            Destroy(gameObject);
            Destroy(this);
        }
    }
}
