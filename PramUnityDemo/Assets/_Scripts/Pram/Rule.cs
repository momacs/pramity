using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pram {

    public class Rule {
        public string name;
        private string description;
        private string instructions;

        /// <summary>
        /// Creates a rule, getting its instructions and descriptions from the pram server.
        /// </summary>
        /// <param name="name">Name of the rule.</param>
        public Rule(string name) {
            this.name = name;
            this.description = this.GetDescription();
            this.instructions = this.GetInstructions();
        }

        /// <summary>
        /// Creates a rule, sending its instructions and descriptions to the pram server.
        /// </summary>
        /// <param name="name">Name of the rule.</param>
        /// <param name="description">Description of the rule (just for documentation purposes)</param>
        /// <param name="instructions">Instructions that drive the rule. Written in pram's proprietary language.</param>
        public Rule(string name, string description, string instructions) {
            this.name = name;
            SetDescription(description);
            SetInstructions(instructions);
        }

        public string GetInstructions() {
            if (this.instructions == null) {
                //TODO: retrieve from pram server
                return null;
            }
            return this.instructions;
        }

        public string GetDescription() {
            if (this.description == null) {
                //TODO: retrieve from pram server
                return null;
            }
            return this.description;
        }

        public void SetDescription(string d) {
            this.description = d;

            //TODO: send to pram server
        }

        public void SetInstructions(string r) {
            this.instructions = r;

            //TODO: send to pram server
        }
    }

}
