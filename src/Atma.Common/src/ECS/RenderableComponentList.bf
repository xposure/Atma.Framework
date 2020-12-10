using System.Collections;
using System;
namespace Atma
{

	public class RenderableComponentList
	{
		typealias FastList<T> = System.Collections.List<T>;

		// global updateOrder sort for the IRenderable lists	
		public static Comparison<Renderable> DefaultRenderableSort = (new => Renderable.Compare) ~ delete _;

		/// <summary>
		/// list of components added to the entity
		/// </summary>
		FastList<Renderable> _components = new FastList<Renderable>() ~ delete _;

		/// <summary>
		/// tracks components by renderLayer for easy retrieval
		/// </summary>
		Dictionary<int, FastList<Renderable>> _componentsByRenderLayer = new .() ~ DeleteDictionaryAndItems!(_);

		private Dictionary<int, Comparison<Renderable>> _sortLayer = new .() ~ DeleteDictionaryAndItems!(_);

		#region array access

		public int Count => _components.Count;

		public Renderable this[int index] => _components.Ptr[index];

		#endregion


		public void Add(Renderable component)
		{
			_components.Add(component);
			AddToRenderLayerList(component, component.RenderLayer);
		}

		public void Remove(Renderable component)
		{
			_components.Remove(component);
			_componentsByRenderLayer[component.RenderLayer].Remove(component);
		}

		public void UpdateRenderableRenderLayer(Renderable component, int oldRenderLayer, int newRenderLayer)
		{
			// a bit of care needs to be taken in case a renderLayer is changed before the component is "live". this can happen when a component
			// changes its renderLayer immediately after being created
			if (_componentsByRenderLayer.ContainsKey(oldRenderLayer) && _componentsByRenderLayer[oldRenderLayer].Contains(component))
			{
				_componentsByRenderLayer[oldRenderLayer].Remove(component);
				AddToRenderLayerList(component, newRenderLayer);
			}
		}

		void AddToRenderLayerList(Renderable component, int renderLayer)
		{
			var list = ComponentsWithRenderLayer(renderLayer);
			Assert.IsFalse(list.Contains(component), "Component renderLayer list already contains this component");

			list.Add(component);
		}

		/// <summary>
		/// fetches all the Components with the given renderLayer. The component list is pre-sorted.
		/// </summary>
		public FastList<Renderable> ComponentsWithRenderLayer(int renderLayer)
		{
			if (_componentsByRenderLayer.TryAdd(renderLayer, ?, var ptr))
				*ptr = new .();

			return *ptr;
		}

		public void UpdateLists()
		{
			for(var it in _componentsByRenderLayer)
			{
				if(_sortLayer.TryGetValue(it.key, let comparer))
					it.value.Sort(comparer);
				else
					it.value.Sort(DefaultRenderableSort);
			}
		}
	}
}