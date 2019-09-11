using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pram {
    [System.Serializable]
    public class GroupJsonifiable {

        public List<string> attributeKeys;
        public List<string> attributeValues;
        public List<string> relationKeys;
        public List<string> relationValues;
        public string site;
        public double n;

        public GroupJsonifiable(Group g) {
            attributeKeys = new List<string>(g.attributeKeys);
            attributeValues = new List<string>(g.attributeValues);
            relationKeys = new List<string>(g.relationKeys);
            relationValues = new List<string>(g.relationValues);
            site = g.site;
            n = g.n;
        }

    }
}
