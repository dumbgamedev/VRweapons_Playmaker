﻿using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRweapons")]
	[Tooltip("Set magazines weapon type for VR Weapons.")]

	// the class must match the name of the action
	// if the action is named missleAction then that should be the name of the class
	public class  MagazineSetWeaponTypeAction : FsmStateAction
	{
		[RequiredField]
		// add the name of your script inside of typeof("yourScriptName"))
		[CheckForComponent(typeof(magazine))]    

		// this is the game object the script is on
		public FsmOwnerDefault gameObject;

		[Tooltip("Set magazines weapon type number.")]
		// add the variables you want in your action
		public FsmInt gunType;

		// you can usually leave this alone
		public FsmBool everyFrame;

		// you are making a custom variable with the scripts type
		magazine theScript;

		public override void Reset()
		{
			//its good practice to set your var to null at start
			gameObject = null;
			gunType = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			// you are grabbing the script from the game object and storing it in your custom variable type
			theScript = go.GetComponent<magazine>();

			if (!everyFrame.Value)
			{
				MakeItSo();
				Finish();
			}

		}

		public override void OnUpdate()
		{
			if (everyFrame.Value)
			{
				MakeItSo();
			}
		}

		//Name your method here
		void MakeItSo()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}

			//Playmaker variable to Script

			theScript.weaponType = gunType.Value;

			//Note! Playmaker var's need .Value after them or they won't work in some cases


		}

	}
}



