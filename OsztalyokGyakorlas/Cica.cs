using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace OsztalyokGyakorlas
{
	internal class Cica
	{
		Random random = new Random();
		List<string> jatekok = [ "fekvés", "kanapé karmolászása", "bukfencezések", "futkározás", "kiszökés", "kutya megtámadása", "emberek megtámadása", "romlott étel fogyasztása"];


		string nev; //ennyi is elég hogy private legyen, alapból az lesz
		int kor;
		int suly;
		string fajta;
		string szin;
		int rendetlensegSzint;
		int fogyasztas;
		bool ehes;
		string nem;

		

		public Cica(string nev, int kor, int suly, string fajta, string szin, int rendetlensegSzint, int fogyasztas, string nem)
		{
			this.nev = nev;
			this.kor = kor;
			this.suly = suly;
			this.fajta = fajta;
			this.szin = szin;
			this.rendetlensegSzint = rendetlensegSzint;
			this.fogyasztas = fogyasztas;
			this.nem = nem;
			ehes = true;
			
		}

		public string Nev { get => nev; set => nev = value; }
		public int Kor { get => kor; set => kor = value; }
		public int Suly { get => suly; set => suly = value; }
		public string Fajta { get => fajta; set => fajta = value; }
		public string Szin { get => szin; set => szin = value; }
		public int RendetlensegSzint { get => rendetlensegSzint; set => rendetlensegSzint = value; }
		public int Fogyasztas { get => fogyasztas; set => fogyasztas = value; }
		public bool Ehes { get => ehes; set => ehes = value; }
		public string Nem { get => nem; set => nem = value; }


        public void Eves(double kajaSuly) //evés
		{
			
			int esely = random.Next(101);

			ehes = false;

			if (esely <=50)
			{
				szin = "zöld";
				suly -= (int)(suly * (esely / 100.0));
				rendetlensegSzint /= 2;
                Console.WriteLine($"ha véletlen radioaktív, vagy romlott ételt evett a cicád, ilyen  lett ilyen a színe: { szin}");
            }
			else
			{
				suly += (int)Math.Ceiling(fogyasztas * kajaSuly); //minden double int, de nem minden int double
                Console.WriteLine("szerencsére semmi baja nem lett");
			};
            Console.WriteLine($"evés után a cicának ekkora súlya lett: {suly}, és a rendetlenségszintje: {rendetlensegSzint},  ilyen a színe: {szin}");
        }

		public void Alvas()
		{
			rendetlensegSzint = 0;

			if (szin == "zöld")
			{
				szin = "eredeti";
			}
            Console.WriteLine($"alvás közben a rednetlensége: {rendetlensegSzint}, valamint kialudta a radioaktiv betegségét es a szine az {szin} lett");


        }

		public void Ebredes()
		{
			rendetlensegSzint = 100;
			ehes = true;
            Console.WriteLine($"a cicának ekkora éberés után a rendetlenségszintja: {rendetlensegSzint}, éhes e ilyenkor a cica? {ehes}");
        }

		public void Jatek()
		{
            Console.WriteLine("hány éves a cicád?: ");
            int ennyiEves = Convert.ToInt16(Console.ReadLine());

			int rendetlenseg = 0;
            
			if (ennyiEves <= 2)
			{
				rendetlenseg = random.Next(50, 100);
			}
            else if (ennyiEves >= 3 && ennyiEves <= 6)
            {
                rendetlenseg = random.Next(20, 90);
            }
			else if (ennyiEves >= 7 && ennyiEves <= 10)
			{
                rendetlenseg = random.Next(10, 60);
            }
			else
			{
                rendetlenseg = random.Next(1, 30);
            }


            string valasz = "";
			string valasz1 = "";

			if (ennyiEves <= 2)
			{
				if (rendetlenseg == 0)
				{
					Alvas();
				}

                else if (rendetlenseg >= 50 && rendetlenseg <= 70)
                {
                    valasz = jatekok[random.Next(5)];
                    Console.WriteLine($"ilyen tevékenységeket csinál ilyenkor a cica: {valasz}, és ekkora a rendetlenségszintje: {rendetlenseg}");
                }
                else if (rendetlenseg >= 71 && rendetlenseg <= 90)
                {
                    valasz = jatekok[random.Next(5)];
                    valasz1 = jatekok[random.Next(8)];
                    Console.WriteLine($"ilyen tevékenységeket csinál ilyenkor a cica: {valasz} valamint {valasz1} és ekkora a rendetlenségszintje: {rendetlenseg}");
                }
                else if (rendetlenseg >= 91 && rendetlenseg <= 100)
				{
					valasz = jatekok[random.Next(8)];
					valasz1 = jatekok[random.Next(8)];
					if (valasz == valasz1)
					{
						valasz1 = jatekok[random.Next(8)];
					}
					Console.WriteLine($"ilyen tevékenységeket csinál ilyenkor a cica: {valasz} valamint {valasz1}, és ekkora a rendetlenségszintje: {rendetlenseg}");
					if (valasz == "romlott étel fogyasztása" || valasz1 == "romlott étel fogyasztása")
					{
						Eves(2);
					}
				}
			}

			if (ennyiEves >= 3 && ennyiEves <= 6)
			{
                if (rendetlenseg == 0) Alvas();
                else if (rendetlenseg >= 20 && rendetlenseg <= 60)
                {
                    valasz = jatekok[random.Next(5)];
                    Console.WriteLine($"ilyen tevékenységeket csinál ilyenkor a cica: {valasz}, és ekkora a rendetlenségszintje: {rendetlenseg}");
                }
                else if (rendetlenseg >= 61 && rendetlenseg <= 90)
				{
					valasz = jatekok[random.Next(6)];
					valasz1 = jatekok[random.Next(3)];
					if (valasz == valasz1)
					{
						valasz1 = jatekok[random.Next(3)];
					}
					Console.WriteLine($"ilyen tevékenységeket csinál ilyenkor a cica:{valasz} valamint {valasz1}, és ekkora a rendetlenségszintje: {rendetlenseg}");
				}
			}

			if (ennyiEves >= 7 && ennyiEves <= 10)
			{
                if (rendetlenseg == 0) Alvas();
                else if (rendetlenseg >= 10 && rendetlenseg <= 30)
                {
                    valasz= jatekok[random.Next(3)] ;
                    Console.WriteLine($"ilyen tevékenységeket csinál ilyenkor a cica: {valasz}, és ekkora a rendetlenségszintje: {rendetlenseg} ");
                }
                else if (rendetlenseg >= 31 && rendetlenseg <= 60)
                {
                    valasz = jatekok[random.Next(5)];
                    Console.WriteLine($"ilyen tevékenységeket csinál ilyenkor a cica: {valasz}, és ekkora a rendetlenségszintje: {rendetlenseg}");
                }
            }

            if (ennyiEves >= 11 )
            {
                if (rendetlenseg == 0) Alvas();

                valasz = jatekok[random.Next(3)];
                Console.WriteLine($"ilyen tevékenységeket csinál ilyenkor a cica: {valasz}, és ekkora a rendetlenségszintje: {rendetlenseg} ");
            }

			//Végre rájöttem hogy akartam :')
			
		}

		

		public void Batman()
		{
            Console.WriteLine("Harcoltál-e már Batmannel? (igen/nem)");
            string valasz = Console.ReadLine().Trim().ToLower(); // Kisbetűsítés és whitespace eltávolítás

            if (valasz == "igen")
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://youtu.be/dQw4w9WgXcQ?si=yR1KiteyKYbOO6TP",
                    UseShellExecute = true
                });
            }
            else
            {
                Console.WriteLine("Majd legközelebb!");
            }
        }

		//tostring
		public override string? ToString()
		{
			return $"Cica neve: {nev}, kora: {kor}, súlya: {suly} kg, fajta: {fajta}, színe: {szin}, " +
				$"ennyire rendetlen 1-100-ig: {rendetlensegSzint}, " +
				$"ennyit fogyaszt: {fogyasztas}, neme: {nem}, éhes-e : {ehes}";
		}


		








	}
}
