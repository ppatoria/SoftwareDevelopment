using System;

namespace MSPress.CSharpCoreRef.GcDemo
{
    /// <summary>
    /// A simulation of a class that manages an external resource.
    /// The class implements IDisposable, and will free its
    /// resources via either Dispose or the Finalizer.
    /// </summary>
	public class ResourceConnector: IDisposable
	{
		public ResourceConnector()
		{
			// Pretend to allocate our external resource here.
		}

		~ResourceConnector()
		{
			Dispose(false);
		}

		public void UseResource()
		{
		}

public void Dispose()
{
	Dispose(true);
}

		protected void Dispose(bool disposing)
		{
			if(disposing)
			{
				GC.SuppressFinalize(this);
			}
			// Release our external resources here.
		}
		public void CollectAndAudit(int generation, bool waitForGC)
		{
			int myGeneration = GC.GetGeneration(this);
			long totalMemory = GC.GetTotalMemory(waitForGC);
			Console.WriteLine("I am in generation {0}.", myGeneration);
			Console.WriteLine("Memory before collection {0}.", totalMemory);
			GC.Collect(generation);
			Console.WriteLine("Memory after collection {0}.", totalMemory);
		}

	}
}
