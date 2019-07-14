using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiteManager : MonoBehaviour
{
    public static SiteManager instance;

    /// <summary>
    /// On awake, make singleton
    /// </summary>
    private void Awake() {
        if (SiteManager.instance != null) {
            Destroy(SiteManager.instance);
        }
        SiteManager.instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
