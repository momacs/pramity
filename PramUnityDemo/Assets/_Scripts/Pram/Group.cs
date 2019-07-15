using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pram {

    public class Group {
        public Dictionary<string, string> attributes;
        public string site;
        public double n;

        public Group() {
            this.attributes = new Dictionary<string, string>();
            this.site = null;
            this.n = 0;
        }

        public Group(double mass) {
            this.attributes = new Dictionary<string, string>();
            this.site = null;
            this.n = mass;
        }

        public Group(Dictionary<string,string> attributes, string site, double mass) {
            this.attributes = attributes;
            this.site = site;
            this.n = mass;
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

            if (!this.attributes.Equals(other.attributes)) {
                return false;
            }

            return true;
        }

        public bool EquivalentAttributes(Group other) {
            if (!this.attributes.Equals(other.attributes)) {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Returns a deep copy of this group
        /// </summary>
        /// <returns>A Group object identical to this one.</returns>
        public Group GetCopy() {
            Dictionary<string, string> attributesCopy = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> kvp in this.attributes) { attributesCopy.Add(kvp.Key, kvp.Value); }
            return new Group(attributesCopy, this.site, this.n);
        }
    }

}
