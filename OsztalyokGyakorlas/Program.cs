namespace OsztalyokGyakorlas
{
	internal class Program
	{
		static void Main(string[] args)
		{

			Cica cica1 = new("Mici", 3, 5, "bengáli", "barna", 40, 1, "hím");
            Console.WriteLine(cica1.ToString());

            
            cica1.Cicaszin();
            Console.WriteLine();
            cica1.Eves(1);
            Console.WriteLine();
            cica1.Alvas();
            Console.WriteLine();
			cica1.Ebredes();
            Console.WriteLine();
            cica1.Jatek();
            Console.WriteLine();
            cica1.Batman();

        }

        
	}
}
