using System;
using System.Collections.Generic;

public class AStar
{
    public char[,] Map { get; private set; }

    public AStar(char[,] map)
    {
        this.Map = map;
    }

    public static int GetH(Node current, Node goal)
    {
        var deltaX = Math.Abs(current.Col - goal.Col);
        var deltaY = Math.Abs(current.Row - goal.Row);

        return deltaX + deltaY;
    }

    public IEnumerable<Node> GetPath(Node start, Node goal)
    {
        PriorityQueue<Node> queue = new PriorityQueue<Node>();

        Dictionary<Node, Node> child_parent = new Dictionary<Node, Node>();
        child_parent[start] = null;

        Dictionary<Node, int> cost = new Dictionary<Node, int>();
        cost[start] = 0;

        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();

            if (current.Row == goal.Row && current.Col == goal.Col)
                break;

            List<Node> neighbours = this.GetNeighbours(current);
            foreach (var neighbour in neighbours)
            {
                int newCost = cost[current] + 1;

                if (!cost.ContainsKey(neighbour) || newCost < cost[neighbour])
                {
                    cost[neighbour] = newCost;
                    neighbour.F = newCost + GetH(neighbour, goal);
                    queue.Enqueue(neighbour);
                    child_parent[neighbour] = current;
                }
            }
        }
        return GetPath(child_parent, start, goal);
    }

    private IEnumerable<Node> GetPath(Dictionary<Node, Node> child_parent, Node start, Node goal)
    {
        Stack<Node> result = new Stack<Node>();

        if (!child_parent.ContainsKey(goal))
        {
            result.Push(start);
            return result;
        }

        result.Push(goal);
        Node current = child_parent[goal];
        while (current != null)
        {
            result.Push(current);
            current = child_parent[current];
        }
        return result;
    }

    private List<Node> GetNeighbours(Node current)
    {
        List<Node> neighbours = new List<Node>();

        AddNeighbour(current.Col - 1, current.Row, neighbours);
        AddNeighbour(current.Col + 1, current.Row, neighbours);
        AddNeighbour(current.Col, current.Row - 1, neighbours);
        AddNeighbour(current.Col, current.Row + 1, neighbours);

        return neighbours;
    }

    private void AddNeighbour(int col, int row, List<Node> neighbours)
    {
        if (col >= 0 && col < this.Map.GetLength(1) && 
            row >= 0 && row < this.Map.GetLength(0) &&
            NotAWall(row,col))
        {
            Node node = new Node(row, col);
            neighbours.Add(node);
        }
    }

    private bool NotAWall(int row, int col)
    {
        return this.Map[row, col] != 'W';
    }
}

