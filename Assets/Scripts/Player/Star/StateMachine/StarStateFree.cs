namespace PierreMizzi.Gameplay.Players
{
	using System;
	using System.Collections.Generic;
	using DG.Tweening;
	using PierreMizzi.SoundManager;
	using PierreMizzi.Useful;
	using PierreMizzi.Useful.StateMachines;
	using UnityEngine;
	using UnityEngine.InputSystem;

	public class StarStateFree : StarState
	{

		public StarStateFree(IStateMachine stateMachine)
			: base(stateMachine)
		{
			type = (int)StarStateType.Free;
		}


		protected override void DefaultEnter()
		{
			base.DefaultEnter();
			m_this.SetFree();
			m_this.SetVelocityFromEnergy();
			SoundManager.PlaySFX(SoundDataID.STAR_FREE);
			m_this.mouseClickAction.action.performed += CallbackMouseClick;
		}

		public override void Exit()
		{
			base.Exit();
			m_this.mouseClickAction.action.performed -= CallbackMouseClick;
		}

		public override void Update()
		{
			base.Update();
			m_this.UpdateRotationFromVelocity();
		}

		private void CallbackMouseClick(InputAction.CallbackContext context)
		{
			ChangeState((int)StarStateType.Returning);
		}


	}
}