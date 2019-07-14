using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pram {

    public class SiteManager : MonoBehaviour {
        public static SiteManager instance;
        private Dictionary<string, Site> sites;

        /// <summary>
        /// On awake, make singleton
        /// </summary>
        private void Awake() {
            if (SiteManager.instance != null) {
                Destroy(SiteManager.instance);
            }
            SiteManager.instance = this;
        }

        /// <summary>
        /// Creates the dictionary of sites based on which sites are children of this object.
        /// </summary>
        void InitializeSiteDictionary() {
            sites = new Dictionary<string, Site>();
            Site[] children = gameObject.GetComponentsInChildren<Site>();
            foreach (Site child in children) {
                sites.Add(child.name, child);
            }
        }

        /// <summary>
        /// On start, initialize the site dictionary
        /// </summary>
        void Start() {
            InitializeSiteDictionary();
        }

        public Site GetSite(string nm) {
            if (nm == null) { return sites["default"]; }
            return sites[nm];
        }
    }

}
