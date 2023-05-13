
using System;
using System.Collections.Generic;

class GFG
{
	int n; // Number of processes
	int m; // Number of resources
	int[,] need;
	int[,] max;
	int[,] alloc;
	int[] avail;
	int[] safeSequence;
	String[] alpha;

	void initializeValues()
	{
		Console.WriteLine("Enter the number of processes: ");
		n = int.Parse(Console.ReadLine());
		Console.WriteLine("Enter the number of resources: ");
		m = int.Parse(Console.ReadLine());

		alpha = new String[m];
		need = new int[n, m];
		max = new int[n, m];
		alloc = new int[n, m];
		avail = new int[m];
		safeSequence = new int[n];
		
		for (int i = 0; i < m; i++)
		{
			alpha[i] = ((char)(65 + i)).ToString();
		}
		//allocated resources
		for (int i = 0; i < n; i++)
		{
			Console.WriteLine($"Enter the allocated resources for process {i}");
			for (int j = 0; j < m; j++)
			{
				Console.WriteLine($"Enter the allocation for resource"+" "+alpha[j]);
				alloc[i, j] = int.Parse(Console.ReadLine());
			}
		}

		// MAX Matrix
		for (int i = 0; i < n; i++)
		{
			Console.WriteLine("Enter the Maximum resources for process:" + i);
			for (int j = 0; j < m; j++)
			{
				Console.WriteLine("enter maximum resource for"+" " + alpha[j]);
				max[i, j] = int.Parse(Console.ReadLine());
			}

		}
		// Available Resources
		for (int i = 0; i < m; i++)
		{
			Console.WriteLine("Enter the Available resources for RESOURCE:" +" "+ alpha[i]);
				avail[i] = int.Parse(Console.ReadLine());
			

		}
	}

	void isSafe()
	{
		int count = 0;

		// visited array to find the
		// already allocated process
		Boolean[] visited = new Boolean[n];
		for (int i = 0; i < n; i++)
		{
			visited[i] = false;
		}

		// work array to store the copy of
		// available resources
		int[] work = new int[m];
		for (int i = 0; i < m; i++)
		{
			work[i] = avail[i];
		}

		while (count < n)
		{
			Boolean flag = false;
			for (int i = 0; i < n; i++)
			{
				if (visited[i] == false)
				{
					int j;
					for (j = 0; j < m; j++)
					{
						if (need[i, j] > work[j])
							break;
					}
					if (j == m)
					{
						safeSequence[count++] = i;
						visited[i] = true;
						flag = true;
						for (j = 0; j < m; j++)
						{
							work[j] = work[j] + alloc[i, j];
						}
					}
				}
			}
			if (flag == false)
			{
				break;
			}
		}
		if (count < n)
		{
			Console.WriteLine("The System is UnSafe!");
		}
		else
		{
			Console.WriteLine("Following is the SAFE Sequence");
			for (int i = 0; i < n; i++)
			{
				Console.Write("P" + safeSequence[i]);
				if (i != n - 1)
					Console.Write(" -> ");
			}
		}
	}

	void calculateNeed()
	{
		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < m; j++)
			{
				need[i, j] = max[i, j] - alloc[i, j];
	
			}
		}
	}


	public static void Main(String[] args)
	{
		GFG gfg = new GFG();

		gfg.initializeValues();

		// Calculate the Need Matrix
		gfg.calculateNeed();

		// Check whether system is in
		// safe state or not
		gfg.isSafe();
	}
}

