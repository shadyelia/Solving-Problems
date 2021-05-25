using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
	public static void Main()
	{
		Node node = new Node(4);
		node.left = new Node(2);
		node.left.left = new Node(1);
		node.left.right = new Node(3);
		node.right = new Node(6);
		node.right.left = new Node(5);
		node.right.right = new Node(8);

		BstSequence bstSequence = new BstSequence();
		List<List<int>> answer = bstSequence.GetList(node);
		bstSequence.DisplaySequences(answer);
	}
}

public class BstSequence
{
	public void DisplaySequences(List<List<int>> sequences)
	{
		Console.WriteLine("Sequences are : ");

		for(int i=0;i<sequences.Count;i++)
		{
			string a = i+": ";
			foreach (int s in sequences[i])
			{
				a += s + " => ";
			}
			Console.WriteLine(a);
		}
	}

	public List<List<int>> GetList(Node root)
	{
		List<List<int>> results = new List<List<int>>();

		if (root == null)
		{
			results.Add(new List<int>());
			return results;
		}

		List<int> prefix = new List<int>();

		prefix.Add(root.data);
		Console.WriteLine(root.data);
		List<List<int>> leftSeq = GetList(root.left);
		List<List<int>> rightSeq = GetList(root.right);

		foreach (List<int> first in leftSeq)
			foreach (List<int> second in rightSeq)
			{
				List<List<int>> weaved = new List<List<int>>();
				Weave(first, second, prefix, weaved);
				results.AddRange(weaved);
			}
		return results;
	}

	private void Weave(List<int> first, List<int> second, List<int> prefix, List<List<int>> weaved)
	{
		if (first.Count == 0 || second.Count == 0)
		{
			List<int> result = prefix.GetRange(0, prefix.Count);
			result.AddRange(first);
			result.AddRange(second);

			weaved.Add(result);
			return;
		}

		int headFirst = first.First();
		first.Remove(headFirst);
		prefix.Add(headFirst);
		Weave(first, second, prefix, weaved);
		first.Add(headFirst);
		prefix.Remove(headFirst);

		int headSecond = second.First();
		second.Remove(headSecond);
		prefix.Add(headSecond);
		Weave(first, second, prefix, weaved);
		second.Add(headSecond);
		prefix.Remove(headSecond);
	}
}

public class Node
{
	public int data;
	public Node left;
	public Node right;

	public Node(int d)
	{
		data = d;
	}
}