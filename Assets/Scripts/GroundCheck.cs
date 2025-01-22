using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class GroundCheck
    {
        private Transform groundCheckTransform;
        private float groundCheckRadius;
        private LayerMask groundLayer;

        public GroundCheck(Transform groundCheckTransform, float radius, LayerMask groundLayer)
        {
            this.groundCheckTransform = groundCheckTransform;
            this.groundCheckRadius = radius;
            this.groundLayer = groundLayer;
        }

        /// <summary>
        /// Determines if the player is grounded by checking for collisions within a sphere.
        /// </summary>
        /// <returns>True if grounded, otherwise false.</returns>
        public bool IsGrounded()
        {
            return Physics.CheckSphere(groundCheckTransform.position, groundCheckRadius, groundLayer);
        }
    }

}

