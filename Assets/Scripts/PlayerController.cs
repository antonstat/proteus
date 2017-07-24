using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;

    private GameObject ship;
    private GameObject turret;

    private Rigidbody2D shipRigidBody;
    private Rigidbody2D turretRigidBody;

    private GameObject projectilePrefab;

    void Start()
    {
        ship = GameObject.Find("Player/Ship");
        turret = GameObject.Find("Player/Turret");

        shipRigidBody = ship.GetComponent<Rigidbody2D>();
        turretRigidBody = turret.GetComponent<Rigidbody2D>();

        projectilePrefab = Resources.Load("Projectile") as GameObject;
    }

    void Update()
    {
        MovePlayer();
        SyncTurretAndShipPositions();
        AimTowardsMouse();
        HandleFiring();
    }

    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        shipRigidBody.AddForce(movement * speed);
    }

    void SyncTurretAndShipPositions()
    {
        turret.transform.position = ship.transform.position;
    }

    void AimTowardsMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 position = turret.transform.position;

        Vector3 relative = new Vector3(mousePosition.x - position.x, mousePosition.y - position.y);
        float angle = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg;

        turretRigidBody.rotation = angle;
    }

    void HandleFiring()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject projectile = Instantiate(projectilePrefab) as GameObject;
            projectile.transform.position = turret.transform.position + turret.transform.forward * 10;

            var projectileRigidBody = projectile.GetComponent<Rigidbody2D>();
            projectileRigidBody.velocity = turret.transform.right * 40;
        }
    }
}
