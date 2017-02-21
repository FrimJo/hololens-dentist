// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using HoloToolkit.Unity.InputModule;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
namespace HoloToolkit.Unity
{
    /// <summary>
    /// THIS IS A CUSTOM SCRIPT DERIVED FROM THE TapToPlace script in holotoolkit
    /// The TapToPlace class is a basic way to enable users to move objects 
    /// and place them on real world surfaces.
    /// Put this script on the object you want to be able to move. 
    /// Users will be able to tap objects, gaze elsewhere, and perform the
    /// tap gesture again to place.
    /// This script is used in conjunction with GazeManager, GestureManager,
    /// and SpatialMappingManager.
    /// TapToPlace also adds a WorldAnchor component to enable persistence.
    /// </summary>

    public class DentistItem_TapToPlace : MonoBehaviour//, IInputClickHandler
    {
        [Tooltip("Supply a friendly name for the anchor as the key name for the WorldAnchorStore.")]
        public string SavedAnchorFriendlyName = "movableCube";

        /// <summary>
        /// Manages persisted anchors.
        /// </summary>
        private WorldAnchorManager anchorManager;

        /// <summary>
        /// Controls spatial mapping.  In this script we access spatialMappingManager
        /// to control rendering and to access the physics layer mask.
        /// </summary>
        private SpatialMappingManager spatialMappingManager;

        /// <summary>
        /// Keeps track of if the user is moving the object or not.
        /// </summary>
		private bool placing;



        private void Start()
        {
			
            // Make sure we have all the components in the scene we need.
            anchorManager = WorldAnchorManager.Instance;
            if (anchorManager == null)
            {
                Debug.LogError("This script expects that you have a WorldAnchorManager component in your scene.");
            }

            spatialMappingManager = SpatialMappingManager.Instance;
            if (spatialMappingManager == null)
            {
                Debug.LogError("This script expects that you have a SpatialMappingManager component in your scene.");
            }

            if (anchorManager != null && spatialMappingManager != null)
            {
                anchorManager.AttachAnchor(this.gameObject, SavedAnchorFriendlyName);
            }
            else
            {
                // If we don't have what we need to proceed, we may as well remove ourselves.
                Destroy(this);
            }
        }

        private void Update()
        {
			

            //placing = gameObject.GetComponent<DentistItemScript>().GetStatus().Equals(DentistItemScript.Statuses.Placing);
            // If the user is in placing mode,
            // update the placement to match the user's gaze.
			if (placing) {
				// Do a raycast into the world that will only hit the Spatial Mapping mesh.
				var headPosition = Camera.main.transform.position;
				var gazeDirection = Camera.main.transform.forward;
				
				RaycastHit hitInfo;
				if (Physics.Raycast (headPosition, gazeDirection, out hitInfo,
					    30.0f, spatialMappingManager.LayerMask)) {

					// Determin if the gaze hit wall or, floor or sealing
					float prod = Math.Abs (Vector3.Dot (hitInfo.normal, Vector3.up));

					// The product is less then 0.5 then we're gazing at a wall
					// else floor or sealing
					if (prod < 0.5f) {
						
						// Rotate this object to face away from the wall (the normal)
						this.transform.forward = -hitInfo.normal;

					} else {
						
						// Rotate this object to face the camera as
						// if the camera were at the same y-position as the object.
						Vector3 cameraPos = Camera.main.transform.position;
						cameraPos.y = transform.position.y;
						this.transform.LookAt(cameraPos);
					}

					// Get half the size of the object
					float halfDepth = this.transform.lossyScale.z / 2.0f;

					// Get the normal of the hit object
					Vector3 norm = hitInfo.normal;

					// Remove the y-axis
					norm.y = 0.0f;

					// Renormalize again
					norm.Normalize();

					// Move this object to where the raycast
					// hit the Spatial Mapping mesh.
					this.transform.position = hitInfo.point + (norm * halfDepth);

					// Rotate this object to face the user.
					/*Quaternion toQuat = Camera.main.transform.localRotation;
					toQuat.x = 0;
					toQuat.z = 0;
					this.transform.rotation = toQuat;*/
				}

				var snapPointLayer = 8;
				var layermask = 1 << snapPointLayer;

				// If reycast hit snap-point
				if (Physics.Raycast (headPosition, gazeDirection, out hitInfo,
					30.0f, layermask)) {

					// Get the hitt transforms position
					this.transform.position = hitInfo.transform.position;

					// Rotate this object to face the user.
					Quaternion toQuat = Camera.main.transform.localRotation;
					toQuat.x = 0;
					toQuat.z = 0;
					this.transform.rotation = toQuat;
				}
			}
        }

        /* public void OnInputClicked(InputEventData eventData)
         {
            TogglePlacingStatus();
         }
         */
        public void SetPlacingStatus(bool NewPlacingStatus)
        {
			print ("DentistItem_TapToPlace: SetPlacingStatus");
			print (NewPlacingStatus);
            // On each tap gesture, toggle whether the user is in placing mode, and toggle kinematic.
			 placing = NewPlacingStatus;

            // If the user is in placing mode, display the spatial mapping mesh.
            if (placing)
            {
	

                spatialMappingManager.DrawVisualMeshes = true;

                Debug.Log(gameObject.name + " : Removing existing world anchor if any.");

                anchorManager.RemoveAnchor(gameObject);
            }
            // If the user is not in placing mode, hide the spatial mapping mesh.
            else
            {
				
                spatialMappingManager.DrawVisualMeshes = false;
                // Add world anchor when object placement is done.
                anchorManager.AttachAnchor(gameObject, SavedAnchorFriendlyName);
                //Chnage status of item to enabled
                /*
                DentistItemScript dis = gameObject.GetComponent<DentistItemScript>();
                dis.ChangeStatus(DentistItemScript.Statuses.Enabled);
                */
            }
        }
        public void TogglePlacingStatus()
        {
			print ("DentistItem_TapToPlace: TogglePlacingStatus");
            SetPlacingStatus(!placing);
        }
    }
}