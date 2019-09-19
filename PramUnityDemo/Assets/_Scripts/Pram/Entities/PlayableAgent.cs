using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pram.Entities;
using Pram.Data;

public class PlayableAgent : MonoBehaviour
{
    public Group group;
    public Site site;
    public AgentPool pool;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Site")) {
            site = other.gameObject.GetComponent<Site>();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Site")) {
            site = null;
        }
    }


}
