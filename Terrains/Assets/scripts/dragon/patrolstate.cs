using System.Collections.Generic;
using UnityEngine;

public class patrolstate : StateMachineBehaviour
{
    public float speed = 5f;
    public float chaseDistance = 8f;

    private Transform[] waypoints;
    private int currentWaypointIndex;
    private bool forward = true;

    private Transform player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isptrolling", true);

        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;

        dragon dr = animator.GetComponent<dragon>();
        if (dr != null && dr.waypointGroup != null)
        {
            List<Transform> list = new List<Transform>();
            foreach (Transform child in dr.waypointGroup)
                list.Add(child);

            waypoints = list.ToArray();
        }
        else
        {
            waypoints = new Transform[0];
        }

        currentWaypointIndex = 0;
        forward = true;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetBool("ischaseing"))
            return;

        if (player != null)
        {
            float distance = Vector3.Distance(animator.transform.position, player.position);
            if (distance <= chaseDistance)
            {
                animator.SetBool("ischaseing", true);
                animator.SetBool("isptrolling", false);
                return;
            }
        }

        if (waypoints.Length == 0) return;

        Transform target = waypoints[currentWaypointIndex];
        Vector3 direction = target.position - animator.transform.position;
        direction.y = 0; // نتجنب مشاكل الارتفاع

        if (direction.magnitude > 0.05f)
        {
            // تحريك العدو نحو النقطة
            Vector3 move = direction.normalized * speed * Time.deltaTime;
            animator.transform.position += move;

            // دوران سلس نحو النقطة
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            animator.transform.rotation = Quaternion.Slerp(animator.transform.rotation, lookRotation, 5f * Time.deltaTime);
        }
        else
        {
            // الوصول للنقطة
            if (waypoints.Length > 1)
            {
                if (forward)
                {
                    currentWaypointIndex++;
                    if (currentWaypointIndex >= waypoints.Length)
                    {
                        currentWaypointIndex = waypoints.Length - 2;
                        forward = false;
                    }
                }
                else
                {
                    currentWaypointIndex--;
                    if (currentWaypointIndex < 0)
                    {
                        currentWaypointIndex = 1;
                        forward = true;
                    }
                }
            }
        }
    }
}
