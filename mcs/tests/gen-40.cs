public interface INode<T>
{
	void Hello (T t);
}

public class Stack<T>
{
	public T TheData;
	public readonly Foo<T> TheFoo;

	public Stack (T t)
	{
		this.TheData = t;
		this.TheFoo = new Foo<T> (t);
	}

	public INode<T> GetNode ()
	{
		return new Node (this);
	}

	public Foo<T> GetFoo (T t)
	{
		return new Foo<T> (t);
	}

	public Bar<T> GetBar (T t)
	{
		return new Bar<T> (t);
	}

	protected class Node : INode<T>
	{
		public readonly Stack<T> Stack;

		public Node (Stack<T> stack)
		{
			this.Stack = stack;
		}

		public void Hello (T t)
		{
		}
	}

	public class Foo<T>
	{
		public readonly T Data;

		public Bar<T> GetBar ()
		{
			return new Bar<T> (Data);
		}

		public Foo (T t)
		{
			this.Data = t;
		}
	}

	public class Bar<U>
	{
		public readonly U Data;

		public Bar (U u)
		{
			this.Data = u;
		}

		public Foo<T> GetFoo (Stack<T> stack)
		{
			return stack.TheFoo;
		}

		public class Baz<V>
		{
			public readonly V Data;

			public Foo<T> GetFoo (Stack<T> stack)
			{
				return new Foo<T> (stack.TheData);
			}

			public Bar<V> GetBar ()
			{
				return new Bar<V> (Data);
			}

			public Baz (V v)
			{
				this.Data = v;
			}
		}
	}
}

class X
{
	static void Main ()
	{
		Stack<int> stack = new Stack<int> (1);
		INode<int> node = stack.GetNode ();
		Stack<int>.Foo<int> foo = stack.GetFoo (7);
		Stack<int>.Bar<int> bar = stack.GetBar (8);
	}
}
