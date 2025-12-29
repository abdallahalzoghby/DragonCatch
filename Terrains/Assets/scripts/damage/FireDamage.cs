using UnityEngine;

public class FireDamage : MonoBehaviour
{
    public int damage = 20;

    private void OnTriggerEnter(Collider other)
    {
        // لو اللي اتخبط عليه تاج dragon
        if (other.CompareTag("dragon"))
        {
            dragon d = other.GetComponent<dragon>();

            if (d != null)
            {
                
                d.TakeDamage(damage);
            }

            // دمّر النار بعد الإصابة
            Destroy(gameObject);
        }
    }
}
