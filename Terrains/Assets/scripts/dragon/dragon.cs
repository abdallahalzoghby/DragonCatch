using UnityEngine;
using UnityEngine.UI;

public class dragon : MonoBehaviour
{
    private int HP = 100;
    public Animator animator;
    public Slider hb;

    // 👈 جروب الويبوينت الخاص بالعدو ده
    public Transform waypointGroup;

    private bool isDead = false;

    void Update()
    {
        hb.value = HP;
    }

    public void TakeDamage(int damageAmount)
    {
        if (isDead)
            return;

        HP -= damageAmount;

        if (HP <= 0)
        {
            isDead = true;
            HP = 0;
            animator.SetTrigger("die");
        }
        else
        {
            animator.SetTrigger("damage");
        }
    }
}
