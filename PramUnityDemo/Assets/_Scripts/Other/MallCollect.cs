using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MallCollect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            ((Pram.Managers.TyphoidMaryManager)Pram.Managers.PramManager.instance).RemoveObject(gameObject);
        }
    }
}
