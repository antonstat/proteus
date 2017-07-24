using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject ship;
    private GameObject turret;

    void Start()
    {
        ship = GameObject.Find("Enemy/Ship");
        turret = GameObject.Find("Enemy/Turret");
    }

    void Update()
    {
        MoveRandomly();
        SyncTurretAndShipPositions();
        AimAtPlayer();
    }

    void MoveRandomly()
    {
        const float speed = 5.0f;
        float moveHorizontal = Random.Range(-1.0f, 1.0f);
        float moveVertical = Random.Range(-1.0f, 1.0f);

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        var shipRigidBody = ship.GetComponent<Rigidbody2D>();
        shipRigidBody.AddForce(movement * speed);
    }

    void SyncTurretAndShipPositions()
    {
        turret.transform.position = ship.transform.position;
    }

    void AimAtPlayer()
    {
        var playerPosition = GameObject.Find("Player/Ship").transform.position;
        Vector3 position = turret.transform.position;

        Vector3 relative = new Vector3(playerPosition.x - position.x, playerPosition.y - position.y);
        float angle = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg;

        var turretRigidBody = turret.GetComponent<Rigidbody2D>();
        turretRigidBody.rotation = angle;
    }
}
