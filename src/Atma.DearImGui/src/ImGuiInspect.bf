namespace Atma
{
	using System;

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
	}*/

	/*public extension PostProcessor<T>
	{
		protected override void OnInspect()
		{
			base.OnInspect();
			_effect.Inspect();
		}
	}

	public extension PostProcessor
	{
		using ImGui;
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
	}*/

	/*public extension Camera
	{
		public override void Inspect()
		{
			base.Inspect();

			_renderTarget.Inspect();

			for (var it in _postProcessors)
				it.Inspect();
		}
	}*/

	/*public extension GraphicsComponent
	{
		using ImGui
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

	public extension Texture
	{
		public void Inspect()
		{
			ImGui.PushID(Internal.UnsafeCastToPtr(this));

			ImGui.Text(scope $"Texture [{ID}] Size: {Size}");
			if (ImGui.IsItemHovered())
			{
				ImGui.BeginTooltip();
				ImGui.Image((.)_id, .(200, 200));
				ImGui.EndTooltip();
			}

			if (ImGui.BeginCombo("Filter", scope $"{filter}"))
			{
				if (ImGui.Selectable("Linear", Filter == .Linear)) Filter = .Linear;
				if (ImGui.Selectable("Nearest", Filter == .Nearest)) Filter = .Nearest;
				ImGui.EndCombo();
			}

			if (ImGui.BeginCombo("WrapX", scope $"{wrapX}"))
			{
				if (ImGui.Selectable("Wrap", wrapX == .Wrap)) WrapX = .Wrap;
				if (ImGui.Selectable("Clamp", wrapX == .Clamp)) WrapX = .Clamp;
				ImGui.EndCombo();
			}

			if (ImGui.BeginCombo("WrapY", scope $"{wrapY}"))
			{
				if (ImGui.Selectable("Wrap", wrapY == .Wrap)) WrapY = .Wrap;
				if (ImGui.Selectable("Clamp", wrapY == .Clamp)) WrapY = .Clamp;
				ImGui.EndCombo();
			}

			ImGui.PopID();
		}
	}

	public extension RenderTexture
	{
		public void Inspect()
		{
			ImGui.PushID(Internal.UnsafeCastToPtr(this));

			ImGui.Text(scope $"RenderTexture [{ID}]");
			for (var it in _attachments)
				it.Inspect();

			ImGui.PopID();
		}
	}

	public extension PostEffect
	{
		public void Inspect()
		{
			ImGui.PushID(Internal.UnsafeCastToPtr(this));
			let name = scope String();
			let type = this.GetType();
			type.GetName(name);

			//if (ImGui.CollapsingHeader(name, .DefaultOpen))
			ImGui.Text(scope $"{name}:");
			{
				ImGui.Indent();
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
				ImGui.Unindent();
			}
			ImGui.PopID();
		}

		protected virtual void OnInspect()
		{
		}
	}

	/*public extension EntityList
	{
		public void Inspect()
		{
			_root.Inspect();
		}
	}

	public extension Component{
		private bool _inspectOpen = true;
		internal void InternalInspect()
		{
			let type = this.GetType();

			let name = scope String();
			type.GetFullName(name);

			ig.PushID(Internal.UnsafeCastToPtr(this));
			if (ig.CollapsingHeader(name))
			{
				Inspect();
			}
			ig.PopID();
		}

		public virtual void Inspect()
		{
		}
	}*/

	/*public extension Entity
	{
		public void Inspect()
		{
			let name = scope String();
			let typeName = scope String();
			let type = this.GetType();
			type.GetName(typeName);

			ig.PushID(Internal.UnsafeCastToPtr(this));
			name.AppendF("{3} (ID: {0}, Entities: {1}, Components: {2})", ID, _entities.Count, _components.Count,
typeName);

			if (_components.Count > 0)
			{
				ig.Checkbox("", &_inspectComponents);
				ig.SameLine();
			}

			if (_entities.Count == 0)
			{
				ig.Indent();
				ig.Text(name);
				ig.Unindent();
			}
			else if (ig.TreeNode(StackStringFormat!("{0}###{1}_{2}", name, ID, typeName)))
			{
				for (var it in _entities)
					it.Inspect();

				OnInspect();

				ig.TreePop();
			}

			if (_inspectComponents)
			{
				name.Clear();
				type.GetFullName(name);
				name.AppendF("[{0}]", ID);

				if (ig.Begin(name, &_inspectComponents))
				{
					ig.PushID("Transform");
					if (ig.CollapsingHeader("Transform"))
					{
						ig.InputFloat2("Position", _localPosition.values);
						ig.SliderAngle("Rotation", &_localRotation);
					}
					ig.PopID();

					_components.Inspect();
					ig.End();
				}
			}
			ig.PopID();
		}
	}*/
}
