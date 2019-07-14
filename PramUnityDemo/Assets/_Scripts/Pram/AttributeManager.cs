using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pram {

    public class AttributeManager : MonoBehaviour {
        public static AttributeManager instance;

        private void Awake() {
            if (AttributeManager.instance != null) {
                Destroy(AttributeManager.instance);
            }
        }

        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }
    }

}