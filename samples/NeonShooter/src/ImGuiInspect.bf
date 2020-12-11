using System;

namespace Atma
{
	/*public extension Entity
	{
		public void Inspect()
		{
			UpdateFromParent();

			if (!Core.DebugRenderEnabled)
				DebugRender();

			if (ImGui.Begin(_name))
			{
				if (ImGui.CollapsingHeader("Transform"))
				{
					ImGui.SliderFloat2("Position", _localPosition.values, -1000, 1000);
					ImGui.SliderFloat("Rotation", _localRotation, -1, 1);
				}
				Components.Inspect();
				ImGui.End();
			}
		}

		private bool _inspectComponents = false;
	}

	public extension ComponentList
	{
		public void Inspect()
		{
			for (var i < _components.Count)
			{
				let name = scope String();
				let type = _components[i].GetType();
				type.GetName(name);

				ImGui.PushID(&_components[i]);
				if (ImGui.CollapsingHeader(name))
				{
					_components[i].Component.Inspect();
				}
				ImGui.PopID();
			}
		}

	}

	public extension PostProcessor<T>
	{
		protected override void OnInspect()
		{
			base.OnInspect();
			_effect.Inspect();
		}
	}

	public extension PostProcessor
	{
		public void Inspect()
		{
			ImGui.PushID(Internal.UnsafeCastToPtr(this));
			let name = scope String();
			let type = this.GetType();
			type.GetName(name);

			if (ImGui.CollapsingHeader(name))
			{
				ImGui.Checkbox("Enabled", &Enabled);
				if (!_captureInput && ImGui.Button("Capture Input"))
					_captureInput = true;
				else if (_debugInput != null)
				{
					ImGui.Text("Input:");
					_debugInput.Inspect();
				}

				if (!_captureOutput && ImGui.Button("Capture Output"))
					_captureOutput = true;
				else if (_debugOutput != null)
				{
					ImGui.Text("Output:");
					_debugOutput.Inspect();
				}

				OnInspect();
			}
			ImGui.PopID();
		}

		public virtual void OnInspect() { }
	}

	public extension Camera
	{
		public override void Inspect()
		{
			base.Inspect();

			_renderTarget.Inspect();

			for (var it in _postProcessors)
				it.Inspect();
		}
	}

	public extension GraphicsComponent
	{
		public override void Inspect()
		{
			base.Inspect();

			ImGui.SliderFloat("OriginX", &Origin.values[0], 0, Width);
			ImGui.SliderFloat("OriginY", &Origin.values[1], 0, Height);
			if (ImGui.Button("Center Origin"))
			{
				CenterOrigin();
			}
			ImGui.InputFloat2("Scale", Scale.values);
			ImGui.InputFloat2("Offset", Offset.values);
			ImGui.SliderAngle("Rotation", &SpriteRotation);

			ImGui.Checkbox("FlipX", &FlipX); ImGui.SameLine(); ImGui.Checkbox("FlipY", &FlipY);
			ImGui.Checkbox("Parent Rotation", &UseParentRotation);
		}
	}*/
}