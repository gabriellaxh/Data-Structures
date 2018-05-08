public class Program
{
    public static void Main(string[] args)
    {
        ArrayList<int> list = new ArrayList<int>();
        list.Add(5);
        list.Add(4);
        list.Add(3);
        list.Add(2);
        list.Add(1);
        list[0] = list[0] + 1;
        System.Console.WriteLine(list.RemoveAt(3));
    }
}
