using UnityEngine;

public class idelstate : StateMachineBehaviour
{
    float timer;
    public float waitTime = 2f;
    public float chaseDistance = 8f;

    private Transform player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0f;
        animator.SetBool("isptrolling", false);

        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // لو بالفعل في Chase → ما نعملش حاجة
        if (animator.GetBool("ischaseing"))
            return;

        // فحص اللاعب
        if (player != null)
        {
            float distance = Vector3.Distance(animator.transform.position, player.position);
            if (distance <= chaseDistance)
            {
                animator.SetBool("ischaseing", true);
                return;
            }
        }

        // العداد الطبيعي
        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            animator.SetBool("isptrolling", true);
        }
    }
}
