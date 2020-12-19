/*using System.Collections;
using System;
using internal Atma;

namespace Atma
{
	public class RenderableComponentList
	{
		typealias FastList<T> = System.Collections.List<T>;
		typealias RenderList = (int RenderLayer, List<Renderable> Renderables, Comparison<Renderable> Sorter);

		// global updateOrder sort for the IRenderable lists
		public static Comparison<Renderable> DefaultRenderableSort = (new => Renderable.Compare) ~ delete _;

		private List<RenderList> _renderList = new .();

		#region array access

		private int _count = 0;
		public int Count => _count;// _components.Count;

		//public Renderable this[int index] => _components.Ptr[index];
		public List<RenderList>.Enumerator GetEnumerator() => _renderList.GetEnumerator();

		#endregion

		public ~this()
		{
			for (var it in _renderList)
			{
				delete it.Renderables;
				delete it.Sorter;
			}

			delete _renderList;
		}


		public void Add(Renderable component)
		{
			_count++;

			if (component._renderList != null)
				Remove(component);

			component._renderList = this;
			let layer = GetLayer(component.RenderLayer);
			layer.Renderables.Add(component);
		}

		public void Remove(Renderable component)
		{
			_count--;
			let layer = GetLayer(component.RenderLayer);
			layer.Renderables.RemoveFast(component);
		}

		private RenderList GetLayer(int renderLayer)
		{
			for (var it in _renderList)
				if (it.RenderLayer == renderLayer)
					return it;

			RenderList layer = (renderLayer, new .(), null);
			_renderList.Add(layer);
			_renderList.Sort(scope (lhs, rhs) => lhs.RenderLayer <=> rhs.RenderLayer);
			return layer;
		}

		public void UpdateLists()
		{
			for (var it in _renderList)
			{
				let sorter = it.Sorter ?? DefaultRenderableSort;
				it.Renderables.Sort(sorter);
			}
		}
	}
}*/