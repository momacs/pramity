using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pram {
    [System.Serializable]
    public class Group {
        //public Dictionary<string, string> attributes;
        public string[] attributeKeys;
        public string[] attributeValues;
        public string site;
        public double n;

        public Group() {
            //this.attributes = new Dictionary<string, string>();
            this.attributeKeys = new string[0];
            this.attributeValues = new string[0];
            this.site = null;
            this.n = 0;
        }

        public Group(double mass) {
            //this.attributes = new Dictionary<string, string>();
            this.attributeKeys = new string[0];
            this.attributeValues = new string[0];
            this.site = null;
            this.n = mass;
        }

        public Group(string[] attributeKeys, string[] attributeValues, string site, double mass) {
            //this.attributes = attributes;
            this.attributeKeys = attributeKeys;
            this.attributeValues = attributeValues;
            this.site = site;
            this.n = mass;
        }

        public Group(Dictionary<string, string> attributes, string site, double mass) {
            this.attributeKeys = new string[attributes.Count];
            this.attributeValues = new string[attributes.Count];

            int i = 0;
            foreach (KeyValuePair<string, string> p in attributes) {
                attributeKeys[i] = p.Key;
                attributeValues[i++] = p.Value;
            }

            this.site = site;
            this.n = mass;
        }

        public string ToString() {
            string attributesString = "{ ";
            for (int i = 0; i < attributeKeys.Length; i++) {
                attributesString += attributeKeys[i] + ": " + attributeValues[i] + ", ";
            }
            attributesString += " }";
            return "{ attributes: " + attributesString + ", site: " + site + ", mass: " + n + " }";
        }

        /// <summary>
        /// Returns true if this group is equivalent to the other (it has the same attributes/relations).
        /// </summary>
        /// <param name="other">The other group to compare this one to.</param>
        /// <returns></returns>
        public bool Equivalent(Group other) {
            if (!this.site.Equals(other.site)) {
                return false;
            }

            return this.EquivalentAttributes(other);
        }

        public Dictionary<string, string> attributes() {
            Dictionary<string, string> d = new Dictionary<string, string>();
            for (int i = 0; i < attributeKeys.Length; i++) {
                d.Add(attributeKeys[i], attributeValues[i]);
            }
            return d;
        }

        public bool EquivalentAttributes(Group other) {
            Dictionary<string, string> a1 = this.attributes();
            Dictionary<string, string> a2 = other.attributes();

            foreach (string k in a1.Keys) {
                if (!a2.ContainsKey(k) || !a1[k].Equals(a2[k])) {
                    return false;
                }
            }

            foreach (string k in a2.Keys) {
                if (!a1.ContainsKey(k) || !a1[k].Equals(a2[k])) {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Returns a deep copy of this group
        /// </summary>
        /// <returns>A Group object identical to this one.</returns>
        public Group GetCopy() {
            Dictionary<string, string> attributesCopy = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> kvp in this.attributes()) { attributesCopy.Add(kvp.Key, kvp.Value); }
            return new Group(attributesCopy, this.site, this.n);
        }
    }

}
