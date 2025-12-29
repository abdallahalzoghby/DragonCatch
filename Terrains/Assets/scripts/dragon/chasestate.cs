using UnityEngine;

public class chasestate : StateMachineBehaviour
{
    public float speed = 4f;
    public float attackDistance = 2f;
    public float chaseDistance = 8f;

    private Transform player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject p = GameObject.FindWithTag("Player");
        if (p != null)
            player = p.transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player == null) return;

        float distance = Vector3.Distance(animator.transform.position, player.position);

        // ❌ اللاعب بعيد → ارجع Patrol
        if (distance > chaseDistance)
        {
            animator.SetBool("ischaseing", false);
            animator.SetBool("isattacking", false);
            return;
        }

        // ⚔️ قريب → هجوم
        if (distance <= attackDistance)
        {
            animator.SetBool("isattacking", true);
            return;
        }

        // 🏃‍♂️ Chase
        animator.SetBool("isattacking", false);

        Vector3 dir = (player.position - animator.transform.position).normalized;
        animator.transform.position += dir * speed * Time.deltaTime;

        if (dir != Vector3.zero)
        {
            animator.transform.rotation = Quaternion.Slerp(
                animator.transform.rotation,
                Quaternion.LookRotation(dir),
                Time.deltaTime * 5f
            );
        }
    }
}
