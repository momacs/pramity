using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenFlu : MonoBehaviour
{
    public Material fluMaterial;
    public SkinnedMeshRenderer body;

    public void ShowFlu() {
        body.material = fluMaterial;
    }
}
