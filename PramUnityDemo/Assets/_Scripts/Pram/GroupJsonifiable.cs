using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pram {
    [System.Serializable]
    public class GroupJsonifiable {

        public List<string> attributeKeys;
        public List<string> attributeValues;
        public string site;
        public double n;

        public GroupJsonifiable(Group g) {
            attributeKeys = new List<string>(g.attributeKeys);
            attributeValues = new List<string>(g.attributeValues);
            site = g.site;
            n = g.n;
        }

    }
}
