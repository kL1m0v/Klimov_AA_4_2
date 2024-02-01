using System;
using UnityEngine;

namespace Arkanoid
{
    internal class Touch: MonoBehaviour
    {
        internal event Action touchTheGate;

       
        void OnTriggerEnter(Collider other)
        {
            Vector3 direction = transform.position - other.ClosestPoint(transform.position);
            transform.forward = Vector3.Reflect(transform.forward, direction.normalized);

            if(other.gameObject.tag != "indestructible")
            {
                other.gameObject.SetActive(false);
                Destroy(other.gameObject);
            }

            if(other.gameObject.tag == "Gate")
            {
                touchTheGate();
            }
        }

    }
}
