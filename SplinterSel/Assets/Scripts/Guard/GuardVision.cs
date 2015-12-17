using UnityEngine;
using System.Collections;

public class GuardVision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
            return;
        else
        {
            RaycastHit hit;
            Vector3 direction = other.gameObject.transform.position - transform.position;

            if (Physics.Raycast(transform.position, direction, out hit, 100))
            {
                if (hit.collider.gameObject.tag != "Player")
                    return;
                this.GetComponentInParent<Guard>().alert();
            }
        }
    }
}
