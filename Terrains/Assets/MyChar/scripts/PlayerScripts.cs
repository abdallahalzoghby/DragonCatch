using UnityEngine;

public class PlayerScripts : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;

    private Vector3 move;
    private Vector3 startPosition;

    public float speed = 5f;
    public float runSpeed = 10f;
    public float gravity = 20f;
    public float jumpHeight = 5f;

    public float rotationSpeed = 200f;

    public GameObject firePrefab;
    public Transform firePoint;

    private bool isAttacking = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        startPosition = transform.position;
    }

    void Update()
    {
        // الهجوم يمنع الحركة
        if (isAttacking)
        {
            AnimatorStateInfo st = animator.GetCurrentAnimatorStateInfo(0);

            if (!st.IsName("Magic Attack"))
                isAttacking = false;

            return;
        }

        float moveZ = Input.GetAxis("Vertical");
        float rotate = Input.GetAxis("Horizontal");

        // هجوم
        if (Input.GetKeyDown(KeyCode.F))
        {
            Attack();
            ShootFire();
            return;
        }

        // 🔁 دوران ناعم بدون تقطيع
        transform.Rotate(0f, rotate * rotationSpeed * Time.deltaTime, 0f);

        // حركة للأمام/للخلف حسب اتجاه الجسم
        Vector3 forward = transform.forward * moveZ * speed;

        // الجري
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
            animator.SetBool("isRunning", true);
        }
        else
        {
            speed = 5f;
            animator.SetBool("isRunning", false);
        }

        animator.SetBool("iswalking", moveZ != 0);

        // قفز
        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                move.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
                animator.SetBool("isjumping", true);
            }
            else
            {
                animator.SetBool("isjumping", false);
            }
        }

        // جاذبية
        move.y -= gravity * Time.deltaTime;

        // اجمع الاتجاه الأمامي مع الجاذبية
        Vector3 finalMove = new Vector3(forward.x, move.y, forward.z);

        controller.Move(finalMove * Time.deltaTime);

        // Reset لو وقع
        if (transform.position.y < -10)
        {
            controller.enabled = false;
            transform.position = startPosition;
            controller.enabled = true;
        }
    }

    void Attack()
    {
        isAttacking = true;
        animator.SetTrigger("attack");
    }

    void ShootFire()
    {
        if (firePrefab == null || firePoint == null) return;

        GameObject fire = Instantiate(firePrefab, firePoint.position, firePoint.rotation, firePoint);
        Destroy(fire, 0.8f);
    }
}
