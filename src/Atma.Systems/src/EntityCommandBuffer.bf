namespace Atma.Entities
{
	using System;

	public struct EntityCommandBuffer : IDisposable
	{
		private enum CommandTypes
		{
			Create,
			Delete,
			Set,
			Assign,
			Update,
			Replace,
			Remove,
			Move
		}

		private struct Command
		{
			public CommandTypes CommandType;
			public int Size;

			public this(CommandTypes type)
			{
				CommandType = type;
				Size = sizeof(Command);
			}

			public void Process(EntityManager entityManager)
			{
				throw new NotImplementedException();
			}
		}

		private struct SetCommand
		{
			public CommandTypes CommandType;
			public int Size;
			public int EntityCount;

			public this(int entityCount)
			{
				CommandType = CommandTypes.Set;
				Size = sizeof(Command);
				EntityCount = entityCount;
			}

			public static Span<uint> Process(EntityManager entityManager, SetCommand* it)
			{
				return new Span<uint>(it + 1, it.EntityCount);
			}
		}

		private struct CreateCommand
		{
			public CommandTypes CommandType;
			public int Size;
			public int ComponentCount;

			public this(int componentCount)
			{
				CommandType = CommandTypes.Create;
				Size = 0;
				ComponentCount = componentCount;
			}

			public static void Process(EntityManager entityManager, CreateCommand* it, Span<uint> lastEntities)
			{
				System.Span<ComponentType> componentTypes = new System.Span<ComponentType>(it + 1, it.ComponentCount);
				entityManager.Create(componentTypes, lastEntities);
			}
		}

		private struct DeleteCommand
		{
			public CommandTypes CommandType;
			public int Size;

			public this(int dummy)
			{
				CommandType = CommandTypes.Delete;
				Size = 0;
			}

			public static void Process(EntityManager entityManager, DeleteCommand* it, Span<uint> lastEntities)
			{
				Assert.GreaterThan(lastEntities.Length, 0);
				entityManager.Delete(lastEntities);
			}
		}

		private struct MoveCommand
		{
			public CommandTypes CommandType;
			public int Size;
			public int ComponentCount;
			public this(int componentCount)
			{
				CommandType = CommandTypes.Move;
				Size = 0;
				ComponentCount = componentCount;
			}

			public static void Process(EntityManager entityManager, MoveCommand* it, Span<uint> lastEntities)
			{
				Assert.GreaterThan(lastEntities.Length, 0);
				Assert.GreaterThan(it.ComponentCount, 0);
				entityManager.MoveInternal(lastEntities, Span<ComponentType>(it, 1), true);
			}
		}


		private struct ReplaceCommand
		{
			public CommandTypes CommandType;
			public int Size;
			public ComponentType ComponentType;
			public int DataCount;

			public this(ComponentType componentType, int dataCount)
			{
				CommandType = CommandTypes.Replace;
				Size = 0;
				ComponentType = componentType;
				DataCount = dataCount;
			}

			public static void Process(EntityManager entityManager, ReplaceCommand* it, Span<uint> lastEntities)
			{
				Assert.GreaterThan(lastEntities.Length, 0);
				entityManager.SetComponentData(&it.ComponentType, lastEntities, it + 1, it.DataCount != 1, false);
			}
		}

		private struct UpdateCommand
		{
			public CommandTypes CommandType;
			public int Size;
			public ComponentType ComponentType;
			public int DataCount;

			public this(ComponentType componentType, int dataCount)
			{
				CommandType = CommandTypes.Update;
				Size = 0;
				ComponentType = componentType;
				DataCount = dataCount;
			}

			public static void Process(EntityManager entityManager, UpdateCommand* it, Span<uint> lastEntities)
			{
				Assert.GreaterThan(lastEntities.Length, 0);
				entityManager.SetComponentData(&it.ComponentType, lastEntities, it + 1, it.DataCount != 1, true);
			}
		}

		private struct AssignCommand
		{
			public CommandTypes CommandType;
			public int Size;
			public ComponentType ComponentType;
			public int DataCount;

			public this(ComponentType componentType, int dataCount)
			{
				CommandType = CommandTypes.Assign;
				Size = 0;
				ComponentType = componentType;
				DataCount = dataCount;
			}

			public static void Process(EntityManager entityManager, AssignCommand* it, Span<uint> lastEntities)
			{
				Assert.GreaterThan(lastEntities.Length, 0);
				entityManager.AssignInternal(lastEntities, &it.ComponentType, it + 1, it.DataCount != 1);
			}
		}

		private struct RemoveCommand
		{
			public CommandTypes CommandType;
			public int Size;
			public int ComponentCount;

			public this(int componentCount)
			{
				CommandType = CommandTypes.Remove;
				Size = 0;
				ComponentCount = componentCount;
			}

			public static void Process(EntityManager entityManager, RemoveCommand* it, Span<uint> lastEntities)
			{
				Assert.GreaterThan(lastEntities.Length, 0);
				Assert.GreaterThan(it.ComponentCount, 0);
				entityManager.Remove(lastEntities, Span<ComponentType>(it + 1, it.ComponentCount));
			}
		}

		private readonly NativeBuffer _buffer;
		private readonly EntityManager _entityManager;

		//internal NativeSlice<EntityRef> _currentEntites;

		public this(EntityManager entityManager, int sizeInBytes = 65536)
		{
			_entityManager = entityManager;
			_buffer = new NativeBuffer(sizeInBytes);
		}

		public void Create(System.Span<ComponentType> componentTypes, int count = 1)
		{
			//old code did not store the components and there is overhead to this
			//but its the only way to make sure the em doesn't crash if it never 
			//seen the spec before (old system stored all specs in a static array)

			ReserveSetEntity(count);

			var ptr = _buffer.Add(new CreateCommand(componentTypes.Length));
			var data = _buffer.Add(componentTypes);

			ptr.Value.Size = ptr.SizeInBytes + data.SizeInBytes;
		}


		public void Create(EntitySpec spec, int count = 1)
		{
			Span<ComponentType> componentTypes = spec.ComponentTypes;
			Create(componentTypes, count);
		}

		private Span<uint> ReserveSetEntity(int count)
		{
			var ptr = _buffer.Add(new SetCommand(count));
			var data = _buffer.Take<uint>(count);
			ptr.Value.Size = ptr.SizeInBytes + data.SizeInBytes;
			return Span<uint>(data.Value, count);
		}

		public void Set(uint entity)
		{
			var data = ReserveSetEntity(1);
			data[0] = entity;
		}

		public void Set(Span<uint> entities)
		{
			var data = ReserveSetEntity(entities.Length);
			for (var i = 0; i < entities.Length; i++)
				data[i] = entities[i];
		}

		public void Delete(uint entity)
		{
			Set(entity);
			var ptr = _buffer.Add(new DeleteCommand(0));
			ptr.Value.Size = ptr.SizeInBytes;
		}

		public void Delete(Span<uint> entities)
		{
			Set(entities);
			var ptr = _buffer.Add(new DeleteCommand(0));
			ptr.Value.Size = ptr.SizeInBytes;
		}

		public void Replace<T>(T t)
			where T : struct
		{
			var type = ComponentType<T>.Type;
			var ptr = _buffer.Add(new ReplaceCommand(type, 1));
			var data = _buffer.Add(t);
			ptr.Value.Size = ptr.SizeInBytes + data.SizeInBytes;
		}

		public void Replace<T>(uint entity, T t)
			where T : struct
		{
			Set(entity);

			var type = ComponentType<T>.Type;
			var ptr = _buffer.Add(new ReplaceCommand(type, 1));
			var data = _buffer.Add(t);
			ptr.Value.Size = ptr.SizeInBytes + data.SizeInBytes;
		}

		public void Replace<T>(Span<uint> entity, T t)
			where T : struct
		{
			Set(entity);

			var type = ComponentType<T>.Type;
			var ptr = _buffer.Add(new ReplaceCommand(type, 1));
			var data = _buffer.Add(t);
			ptr.Value.Size = ptr.SizeInBytes + data.SizeInBytes;
		}

		public void Replace<T>(Span<uint> entity, Span<T> t)
			where T : struct
		{
			Set(entity);

			var type = ComponentType<T>.Type;
			var ptr = _buffer.Add(new ReplaceCommand(type, t.Length));
			var data = _buffer.Add(t);
			ptr.Value.Size = ptr.SizeInBytes + data.SizeInBytes;
		}

		public void Remove<T>()
			where T : struct
		{
			var type = ComponentType<T>.Type;
			var ptr = _buffer.Add(new RemoveCommand(1));
			var data = _buffer.Add(type);
			ptr.Value.Size = ptr.SizeInBytes + data.SizeInBytes;
		}

		public void Remove<T>(uint entity)
			where T : struct
		{
			Set(entity);

			var type = ComponentType<T>.Type;
			var ptr = _buffer.Add(new RemoveCommand(1));
			var data = _buffer.Add(type);
			ptr.Value.Size = ptr.SizeInBytes + data.SizeInBytes;
		}

		public void Remove<T>(Span<uint> entities)
			where T : struct
		{
			Set(entities);

			var type = ComponentType<T>.Type;
			var ptr = _buffer.Add(new RemoveCommand(1));
			var data = _buffer.Add(type);
			ptr.Value.Size = ptr.SizeInBytes + data.SizeInBytes;
		}

		public void Remove(uint entity, Span<ComponentType> componentTypes)
		{
			Set(entity);

			var ptr = _buffer.Add(new RemoveCommand(componentTypes.Length));
			var data = _buffer.Add(componentTypes);
			ptr.Value.Size = ptr.SizeInBytes + data.SizeInBytes;
		}

		public void Remove(Span<uint> entities, Span<ComponentType> componentTypes)
		{
			Set(entities);

			var ptr = _buffer.Add(new RemoveCommand(componentTypes.Length));
			var data = _buffer.Add(componentTypes);
			ptr.Value.Size = ptr.SizeInBytes + data.SizeInBytes;
		}

		public void Move(uint entity, Span<ComponentType> componentTypes)
		{
			Set(entity);

			var ptr = _buffer.Add(new MoveCommand(componentTypes.Length));
			var data = _buffer.Add(componentTypes);
			ptr.Value.Size = ptr.SizeInBytes + data.SizeInBytes;
		}

		public void Move(Span<uint> entities, Span<ComponentType> componentTypes)
		{
			Set(entities);

			var ptr = _buffer.Add(new MoveCommand(componentTypes.Length));
			var data = _buffer.Add(componentTypes);
			ptr.Value.Size = ptr.SizeInBytes + data.SizeInBytes;
		}

		public void Assign<T>(T t)
			where T : struct
		{
			var type = ComponentType<T>.Type;
			var ptr = _buffer.Add(new AssignCommand(type, 1));
			var data = _buffer.Add(t);
			ptr.Value.Size = ptr.SizeInBytes + data.SizeInBytes;
		}

		public void Assign<T>(uint entity, T t)
			where T : struct
		{
			Set(entity);

			var type = ComponentType<T>.Type;
			var ptr = _buffer.Add(new AssignCommand(type, 1));
			var data = _buffer.Add(t);
			ptr.Value.Size = ptr.SizeInBytes + data.SizeInBytes;
		}

		public void Assign<T>(Span<uint> entity, T t)
			where T : struct
		{
			Set(entity);

			var type = ComponentType<T>.Type;
			var ptr = _buffer.Add(new AssignCommand(type, 1));
			var data = _buffer.Add(t);
			ptr.Value.Size = ptr.SizeInBytes + data.SizeInBytes;
		}

		public void Assign<T>(Span<uint> entity, Span<T> t)
			where T : struct
		{
			Set(entity);

			var type = ComponentType<T>.Type;
			var ptr = _buffer.Add(new AssignCommand(type, t.Length));
			var data = _buffer.Add(t);
			ptr.Value.Size = ptr.SizeInBytes + data.SizeInBytes;
		}


		public void Update<T>(T t)
			where T : struct
		{
			var type = ComponentType<T>.Type;
			var ptr = _buffer.Add(new UpdateCommand(type, 1));
			var data = _buffer.Add(t);
			ptr.Value.Size = ptr.SizeInBytes + data.SizeInBytes;
		}

		public void Update<T>(uint entity, T t)
			where T : struct
		{
			Set(entity);

			var type = ComponentType<T>.Type;
			var ptr = _buffer.Add(new UpdateCommand(type, 1));
			var data = _buffer.Add(t);
			ptr.Value.Size = ptr.SizeInBytes + data.SizeInBytes;
		}

		public void Update<T>(Span<uint> entity, T t)
			where T : struct
		{
			Set(entity);

			var type = ComponentType<T>.Type;
			var ptr = _buffer.Add(new UpdateCommand(type, 1));
			var data = _buffer.Add(t);
			ptr.Value.Size = ptr.SizeInBytes + data.SizeInBytes;
		}

		public void Update<T>(Span<uint> entity, Span<T> t)
			where T : struct
		{
			Set(entity);

			var type = ComponentType<T>.Type;
			var ptr = _buffer.Add(new UpdateCommand(type, t.Length));
			var data = _buffer.Add(t);
			ptr.Value.Size = ptr.SizeInBytes + data.SizeInBytes;
		}

		public void Execute()
		{
			var em = _entityManager;
			var rawPtr = _buffer.RawPointer;
			Span<uint> lastEntities = Span<uint>.Empty;
			while (rawPtr < _buffer.EndPointer)
			{
				var cmd = (Command*)rawPtr;
				switch (cmd.CommandType)
				{
				case CommandTypes.Set:
					lastEntities = SetCommand.Process(em, (SetCommand*)cmd);
					break;
				case CommandTypes.Create:
					CreateCommand.Process(em, (CreateCommand*)cmd, lastEntities);
					break;
				case CommandTypes.Delete:
					DeleteCommand.Process(em, (DeleteCommand*)cmd, lastEntities);
					lastEntities = Span<uint>.Empty;
					break;
				case CommandTypes.Assign:
					AssignCommand.Process(em, (AssignCommand*)cmd, lastEntities);
					break;
				case CommandTypes.Replace:
					ReplaceCommand.Process(em, (ReplaceCommand*)cmd, lastEntities);
					break;
				case CommandTypes.Remove:
						//removing the last component of an entity has the side effect of deleting it, could cause bugs
					RemoveCommand.Process(em, (RemoveCommand*)cmd, lastEntities);
					break;
				case CommandTypes.Move:
						//removing the last component of an entity has the side effect of deleting it, could cause bugs
					MoveCommand.Process(em, (MoveCommand*)cmd, lastEntities);
					break;
				case CommandTypes.Update:
					UpdateCommand.Process(em, (UpdateCommand*)cmd, lastEntities);
					break;

				default:
					throw new NotImplementedException();
				}
				Assert.GreatherThan(cmd.Size, 0);
				rawPtr += cmd.Size;
			}

			_buffer.Reset();
		}

		public void Dispose()
		{
			_buffer.Dispose();
		}
	}
}