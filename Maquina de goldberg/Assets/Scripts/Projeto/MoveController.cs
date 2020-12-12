using UnityEngine.SceneManagement;
using UnityEngine;

public class MoveController : MonoBehaviour
{

    public float speed = 6.0F;
    public float jumpSpeed = 20.0F;
    public float gravity = 20.0F;

    private Vector3 moveDir = Vector3.zero;
    CharacterController controller;

    public int maxHealth = 100;
    public int currentHealth;
    public Health healthbar;

    public Camera cam;
    public Pendulo pendulo;

    Vector3 previousPosition;
    Vector3 hitPos;

    float distGround;

    enum State { Voando, Caindo, Andando };
    State state;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        state = State.Andando;
        pendulo.playerTrans.transform.parent = pendulo.pivot.pivotTrans;
        previousPosition = transform.localPosition;

        distGround = GetComponent<CapsuleCollider>().bounds.extents.y;

        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    void Update()
    {

        PlayerState();

        switch (state)
        {
            case State.Voando:
                Voando();
                break;
            case State.Caindo:
                Caindo();
                break;
            case State.Andando:
                Andando();
                break;
        }
        previousPosition = transform.localPosition;
    }

    bool Grounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distGround + 0.1f);
    }

    void PlayerState()
    {
        if (Grounded())
        {
            state = State.Andando;
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (state == State.Andando)
                {
                    pendulo.player.velocity = moveDir;
                }
                pendulo.MudarPivot(hit.point);
                state = State.Voando;

            }
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            if (state == State.Voando)
            {
                state = State.Caindo;
            }
        }
    }

    void Voando()
    {
        if (Input.GetKey(KeyCode.W))
        {
            pendulo.player.velocity += pendulo.player.velocity.normalized * 2;
        }
        
        transform.localPosition = pendulo.MovePlayer(transform.localPosition, previousPosition, Time.deltaTime);
        previousPosition = transform.localPosition;
    }

    void Caindo()
    {
        pendulo.corda.length = Mathf.Infinity;
        transform.localPosition = pendulo.Cair(transform.localPosition, Time.deltaTime);
        previousPosition = transform.localPosition;
    }

    void Andando()
    {
        pendulo.player.velocity = Vector3.zero;
        if (controller.isGrounded)
        {
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDir = Camera.main.transform.TransformDirection(moveDir);
            moveDir.y = 0.0f;
            moveDir *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDir.y = jumpSpeed;
            }

        }
        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 colisMove = collision.contacts[0].normal * Vector3.Dot(pendulo.player.velocity, collision.contacts[0].normal);
        pendulo.player.velocity = pendulo.player.velocity - (colisMove * 1.2f);
        hitPos = transform.position;  
        
        if(collision.gameObject.tag == "shot")
        {
            Debug.Log("colidiu");
            TakeDamage(25);
           if(currentHealth <= 0)
           {
                SceneManager.LoadScene("FinalScene");
           }
        }
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }
}
