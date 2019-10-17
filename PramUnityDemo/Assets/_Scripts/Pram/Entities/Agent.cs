using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Pram.Data;
using Pram.Managers;
using UnityEngine.AI;

namespace Pram.Entities {

    public class Agent : MonoBehaviour {
        public Group group;
        public Site site;
        private NavMeshAgent ai;
        private int counter = 0;
        bool template = true;
        Collider col;
        Rigidbody rb;

        bool placed = false;

        public float objectPerMass = 1f;

        public Vector3 destination;

        public void Init() {
            template = false;
            ai = gameObject.GetComponent<NavMeshAgent>();
            col = gameObject.GetComponent<Collider>();
            rb = gameObject.GetComponent<Rigidbody>();

            site = SiteManager.instance.GetSite(group.site);

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
                destination = site.GetPosition();
            } else {
                destination = PramManager.instance.GetPosition();
            }

            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        // Update is called once per frame
        void Update() {
            if (!template) {
                ai.destination = destination;

                if (ai.remainingDistance > 1000000000f) {
                    if (site != null) {
                        destination = site.GetPosition();
                    } else {
                        destination = PramManager.instance.GetPosition();
                    }

                    ai.destination = destination;

                    if (ai.remainingDistance > 1000000000f && !placed) {
                        ai.Warp(destination);
                    }
                }
                if (ai.remainingDistance < 0.5f) {
                    placed = true;
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                    if (site != null) {
                        destination = site.GetPosition();
                    } else {
                        destination = PramManager.instance.GetPosition();
                    }
                }
            }
        }
    }

}
