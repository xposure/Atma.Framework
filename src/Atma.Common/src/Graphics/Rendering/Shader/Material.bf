using System;
using System.Collections;
using internal Atma;

namespace Atma
{
	public class MaterialParam<T>
	{
		private Material _material;
		internal String _name = new .() ~ delete _;
		//private static T _dummy = default;

		public this(Material material, StringView name)
		{
			_material = material;
			_name.Set(name);
		}

		public T Value
		{
			get
			{
				if (!_material.TryGetParameter(_name, let p))
					return default;

				return *(T*)p.Ptr;
			}
			set
			{
				if (_material.TryGetParameter(_name, let p))
					*(T*)p.Ptr = value;
			}
		}

		public Span<T> AsSpan()
		{
			if (_material.TryGetParameter(_name, let p))
				return .((T*)p.Ptr, Length);

			return .();
		}

		public void CopyFrom(T[] data)
		{
			if (_material.TryGetParameter(_name, let p))
			{
				Assert.IsTrue(data.Count == p.Length);
				let span = Span<T>((T*)p.Ptr, Length);
				data.CopyTo(span);
			}
		}

		public void IfExists<K>(K dlg) where K : delegate void(T* ptr)
		{
			if (_material.TryGetParameter(_name, let p))
				dlg((T*)p.Ptr);
		}

		public int Length
		{
			get
			{
				if (!_material.TryGetParameter(_name, let p))
					return -1;

				return p.Length;
			}
		}
	}

	/// <summary>
	/// A Material is used to store the state of a Shader
	/// </summary>
	public class Material
	{
		public abstract class Parameter
		{
			public class Parameter<T> : Parameter
			{
				private T[] _value ~ delete _;

				public this(ShaderUniform uniform, T[] data)
				{
					name.Set(uniform.Name);
					Uniform = uniform;
					_value = data;
				}

				public override void* Ptr => &_value[0];

				public override Type BeefType => typeof(T);

			}

			//private void* _value ;//~ delete _;
			protected String name = new .() ~ delete _;

			/// <summary>
			/// Reference to the Parameter's Uniform
			/// </summary>
			public readonly ShaderUniform Uniform;

			/// <summary>
			/// The Name of the Parameter
			/// </summary>
			public StringView Name => name;

			/// <summary>
			/// The Shader Uniform Type of the Parameter
			/// </summary>
			public UniformType Type => Uniform.Type;


			public abstract Type BeefType { get; }

			/// <summary>
			/// Array Length (1 for single values)
			/// </summary>
			public int Length => Uniform.Length;

			/// <summary>
			/// Whether the Parameter is an Array
			/// </summary>
			public bool IsArray => Length > 1;

			/// <summary>
			/// Determines if the data should be normalized first
			/// </summary>
			public bool Normalize => false;

			/// <summary>
			/// The Value of the Parameter
			/// </summary>
			public abstract void* Ptr { get; }

			public static Parameter Create(ShaderUniform uniform)
			{
				if (uniform.Type == .Int)
					return new Parameter<int>(uniform, new int[uniform.Length]);
				else if (uniform.Type.IsFloat)
					return new Parameter<float>(uniform, new float[uniform.Type.Elements * uniform.Length]);
				else if (uniform.Type == .Sampler)
				{
					return new Parameter<Texture>(uniform, new Texture[uniform.Length]);
				}
				else
				{
					Runtime.Assert(false, "Unknown uniform type");
				}

				Runtime.Assert(false, "Not implemented");
				return default;
			}

			[Inline]
			protected void AssertParameters(UniformType expected, int index)
			{
				Runtime.Assert(Type == expected);
				Runtime.Assert(index >= 0 && index < Length);
			}

			public void Set(Texture value) => Set(0, value);
			public void Set(int index, Texture value)
			{
				AssertParameters(UniformType.Sampler, index);

				let values = (Texture*)Ptr;
				values[index] = value;
			}

			public Texture GetTexture(int index = 0)
			{
				AssertParameters(UniformType.Sampler, index);

				let values = (Texture*)Ptr;
				return values[index];
			}

			public void Set(int value) => Set(0, value);
			public void Set(int index, int value)
			{
				AssertParameters(UniformType.Int, index);

				let values = (int*)Ptr;
				values[index] = value;
			}

			public int GetInt(int index = 0)
			{
				AssertParameters(UniformType.Int, index);

				let values = (int*)Ptr;
				return values[index];
			}

			public void Set(float value) => Set(0, value);
			public void Set(int index, float value)
			{
				AssertParameters(UniformType.Float, index);

				let values = (float*)Ptr;
				values[index] = value;
			}

			public float GetFloat(int index = 0)
			{
				AssertParameters(UniformType.Float, index);

				let values = (float*)Ptr;
				return values[index];
			}

			public void Set(float2 value) => Set(0, value);
			public void Set(int index, float2 value)
			{
				AssertParameters(UniformType.Float2, index);

				let values = (float2*)Ptr;
				values[index] = value;
			}

			public float2 GetFloat2(int index = 0)
			{
				AssertParameters(UniformType.Float2, index);

				let values = (float2*)Ptr;
				return values[index];
			}

			public void Set(float3 value) => Set(0, value);

			public void Set(int index, float3 value)
			{
				AssertParameters(UniformType.Float3, index);

				let values = (float3*)Ptr;
				values[index] = value;
			}

			public float3 GetFloat3(int index = 0)
			{
				AssertParameters(UniformType.Float3, index);
				let values = (float3*)Ptr;
				return values[index];
			}

			public void Set(float4 value) => Set(0, value);

			public void Set(int index, float4 value)
			{
				AssertParameters(UniformType.Float4, index);
				let values = (float4*)Ptr;
				values[index] = value;
			}

			public float4 GetFloat4(int index = 0)
			{
				AssertParameters(UniformType.Float4, index);
				let values = (float4*)Ptr;
				return values[index];
			}

			public void Set(float3x2 value) => Set(0, value);

			public void Set(int index, float3x2 value)
			{
				AssertParameters(UniformType.Matrix3x2, index);
				let values = (float3x2*)Ptr;
				values[index] = value;
			}

			public float3x2 GetFloat3x2(int index = 0)
			{
				AssertParameters(UniformType.Matrix3x2, index);

				let values = (float3x2*)Ptr;
				return values[index];
			}

			public void Set(float4x4 value) => Set(0, value);

			public void Set(int index, float4x4 value)
			{
				AssertParameters(UniformType.Matrix4x4, index);

				let values = (float4x4*)Ptr;
				values[index] = value;
			}

			public float4x4 GetFloat4x4(int index = 0)
			{
				AssertParameters(UniformType.Matrix4x4, index);

				let values = (float4x4*)Ptr;
				return values[index];
			}

			public void Set(Color value) => Set(0, value);

			public void Set(int index, Color value)
			{
				AssertParameters(UniformType.Float4, index);
				let values = (float*)Ptr;
				values[index] = value.Rf;
				values[index + 1] = value.Bf;
				values[index + 2] = value.Gf;
				values[index + 3] = value.Af;
			}

			public Color GetColor(int index = 0)
			{
				AssertParameters(UniformType.Float4, index);
				let values = (float*)Ptr;
				return .(values[index], values[index + 1], values[index + 2], values[index + 3]);
			}
		}

		/// <summary>
		/// The Shader this Material uses
		/// </summary>
		public readonly Shader Shader;

		/// <summary>
		/// The list of all Parameters within this Material
		/// </summary>
		public ReadOnlyList<Parameter> Parameters => .(_parameters);

		private readonly List<Parameter> _parameters = new List<Parameter>() ~ DeleteContainerAndItems!(_);
		private int shaderVersion = -1;

		public this(Shader shader)
		{
			Shader = shader;
			ValidateShaderVersion();
		}

		private void ValidateShaderVersion()
		{
			if (shaderVersion != Shader.Version)
			{
				DeleteAndClearItems!(_parameters);

				for (var uniform in Shader.Uniforms)
					_parameters.Add(Parameter.Create(uniform));

				shaderVersion = Shader.Version;
			}
		}
		/*/// <summary>
		/// Gets the Parameter with the given name and returns true if found
		/// </summary>
		public bool GetParameter<T>(StringView name, out MaterialParam<T> p)
		{
			for (var i < _parameters.Count)
				if (_parameters[i].Name == name && _parameters[i].BeefType == typeof(T))
				{
					p = .(_parameters[i]);
					return true;
				}

			p = default;
			return false;
		}*/

		/// <summary>
		/// Gets the Parameter with the given name and returns true if found
		/// </summary>
		public bool TryGetParameter(StringView name, out Parameter parameter)
		{
			ValidateShaderVersion();
			for (var i < _parameters.Count)
			{
				if (_parameters[i].Name == name)
				{
					parameter = _parameters[i];
					return true;
				}
			}

			parameter = default;
			return false;
		}

		/// <summary>
		/// Gets the Parameter with the given name
		/// </summary>
		public Parameter this[StringView name]
		{
			get
			{
				ValidateShaderVersion();
				if (TryGetParameter(name, let p))
					return p;
				return null;
			}
		}
	}

	public static
	{
		public static void Inspect(this MaterialParam<float> it, float min, float max)
		{
			it.IfExists( (p) => ImGui.SliderFloat(it._name, p, 0, 5));
		}

		public static void Inspect(this MaterialParam<float2> it, float min, float max)
		{
			it.IfExists( (p) => ImGui.SliderFloat2(it._name, p.values, 0, 5));
		}
	}
}

