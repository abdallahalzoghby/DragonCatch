using UnityEngine;

public class ClawAttack : StateMachineBehaviour
{
    private Transform player;
    public float attackRange = 2f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject p = GameObject.FindWithTag("Player");
        if (p != null)
            player = p.transform;

        // وقف الحركة أثناء الضرب
        animator.SetBool("isattacking", true);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player == null) return;

        float distance = Vector3.Distance(animator.transform.position, player.position);

        // لو اللاعب بعد أثناء الضرب
        if (distance > attackRange)
        {
            animator.SetBool("isattacking", false);
        }

        // خلي العدو باصص على اللاعب
        Vector3 dir = (player.position - animator.transform.position).normalized;
        if (dir != Vector3.zero)
        {
            animator.transform.rotation = Quaternion.Slerp(
                animator.transform.rotation,
                Quaternion.LookRotation(dir),
                Time.deltaTime * 8f
            );
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // مهم جدًا: منع Loop
        animator.SetBool("isattacking", false);
    }
}
