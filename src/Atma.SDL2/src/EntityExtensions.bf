using System;
using internal Atma;
namespace Atma
{
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
			name.AppendF("{3} (ID: {0}, Entities: {1}, Components: {2})", ID, _entities.Count, _components.Count, typeName);

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
