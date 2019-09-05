using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Pram {

    public class Agent : MonoBehaviour {
        public Group group;
        public Site site;
        private NavMeshAgent ai;
        private int counter = 0;
        bool template = true;
        Collider col;
        Rigidbody rb;

        public float objectPerMass = 1f;

        public void Init() {
            template = false;
            ai = gameObject.GetComponent<NavMeshAgent>();
            col = gameObject.GetComponent<Collider>();
            rb = gameObject.GetComponent<Rigidbody>();

            if (!ai.isOnNavMesh) {
                if (site != null) {
                    transform.position = site.GetPosition();
                } else {
                    transform.position = PramManager.instance.GetPosition();
                }
                gameObject.SetActive(false);
                gameObject.SetActive(true);
            }

            if (site != null) {
                ai.destination = site.GetPosition();
            } else {
                ai.destination = PramManager.instance.GetPosition();
            }
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        // Update is called once per frame
        void Update() {
            if (!template) {
                if (ai.remainingDistance < 0.2f) {
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                    if (site != null) {
                        ai.destination = site.GetPosition();
                    } else {
                        ai.destination = PramManager.instance.GetPosition();
                    }
                }
            }
        }
    }

}
