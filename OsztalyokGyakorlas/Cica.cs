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
                //Console.WriteLine("szerencsére semmi baja nem lett");
			};
            Console.WriteLine($"evés után a cicának ekkora súlya lett: {suly}, és a rendetlenségszintje: {rendetlensegSzint}, de ha idősebb a cicád ez hamar visszaugrik mert ezt a boostot csak az evés adta, " +
				$" ilyen a színe: {szin}");
        }

		public void Alvas()
		{
			rendetlensegSzint = 0;

			if (szin == "zöld")
			{
				szin = "eredeti";
			}
            Console.WriteLine($"alvás közben a rednetlensége: {rendetlensegSzint}, valamint ha volt, kialudta a radioaktiv betegségét és a szine az {szin} lett");


        }

		public void Ebredes()
		{
			rendetlensegSzint = 100;
			ehes = true;
            Console.WriteLine($"a cicának ekkora éberés után a rendetlenségszintje: {rendetlensegSzint}, de ha idősebb a cicád ez hamar visszaugrik, mert ezt a boostot csak az alvás adta, éhes e ilyenkor a cica? {ehes}");
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
                    Console.WriteLine($"ilyen tevékenységeket csinál ilyenkor a cica: {valasz}, mert most ekkora a rendetlenségszintje: {rendetlenseg}");
                }
                else if (rendetlenseg >= 71 && rendetlenseg <= 90)
                {
                    valasz = jatekok[random.Next(5)];
                    valasz1 = jatekok[random.Next(8)];
                    Console.WriteLine($"ilyen tevékenységeket csinál ilyenkor a cica: {valasz} valamint {valasz1} mert most ekkora a rendetlenségszintje: {rendetlenseg}");
                }
                else if (rendetlenseg >= 91 && rendetlenseg <= 100)
				{
					valasz = jatekok[random.Next(8)];
					valasz1 = jatekok[random.Next(8)];
					if (valasz == valasz1)
					{
						valasz1 = jatekok[random.Next(8)];
					}
					Console.WriteLine($"ilyen tevékenységeket csinál ilyenkor a cica: {valasz} valamint {valasz1}, mert most ekkora a rendetlenségszintje: {rendetlenseg}");
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
                    Console.WriteLine($"ilyen tevékenységeket csinál ilyenkor a cica: {valasz}, mert most ekkora a rendetlenségszintje: {rendetlenseg}");
                }
                else if (rendetlenseg >= 61 && rendetlenseg <= 90)
				{
					valasz = jatekok[random.Next(6)];
					valasz1 = jatekok[random.Next(3)];
					if (valasz == valasz1)
					{
						valasz1 = jatekok[random.Next(3)];
					}
					Console.WriteLine($"ilyen tevékenységeket csinál ilyenkor a cica:{valasz} valamint {valasz1}, mert most ekkora a rendetlenségszintje: {rendetlenseg}");
				}
			}

			if (ennyiEves >= 7 && ennyiEves <= 10)
			{
                if (rendetlenseg == 0) Alvas();
                else if (rendetlenseg >= 10 && rendetlenseg <= 30)
                {
                    valasz= jatekok[random.Next(3)] ;
                    Console.WriteLine($"ilyen tevékenységeket csinál ilyenkor a cica: {valasz}, mert most ekkora a rendetlenségszintje: {rendetlenseg} ");
                }
                else if (rendetlenseg >= 31 && rendetlenseg <= 60)
                {
                    valasz = jatekok[random.Next(5)];
                    Console.WriteLine($"ilyen tevékenységeket csinál ilyenkor a cica: {valasz}, mert most ekkora a rendetlenségszintje: {rendetlenseg}");
                }
            }

            if (ennyiEves >= 11 )
            {
                if (rendetlenseg == 0) Alvas();

                valasz = jatekok[random.Next(3)];
                Console.WriteLine($"ilyen tevékenységeket csinál ilyenkor a cica: {valasz}, mert most ekkora a rendetlenségszintje: {rendetlenseg} ");
            }

			//Végre rájöttem hogy akartam :')
			//valamint az az elképzelés hogy a listában egyre durvább tevékenységek vannak, és minél fiatalabb annál több ereje van ezeket megcsinálni,
			//valamint az öreg macska már tudja mikor romlott az étel, azért nem tettem bele
			
		}

		public void Cicaszin()
		{
            Console.WriteLine("Milyen színű a cicád?: fekete/szürke/fehér/narancs/többszínű/barna");
			string szine = Console.ReadLine().Trim().ToLower();
			if (szine == "fekete")
			{
				Console.WriteLine("Elég átlagos szín, szerencsére max csak megijeszt a sötétben néha ");
			}
			else if (szine == "fehér")
			{
				Console.WriteLine(" Jó sokszor fürdetheted meg ezt a cicát ");
			}
			else if (szine == "szürke")
			{
				Console.WriteLine("Szerencsére a szürkén nem látszig meg annyira a kosz, valamint kevésszer látni ilyen cicát ");
			}
			else if (szine == "narancs")
            {
				rendetlensegSzint += 20;
                Console.WriteLine($"Hát, nem irigyellek, lefogadom hogy a cicád fiú, valamint ez a rendetlenségi szintjét is rögtön növeli 20-al, így ennyi lesz: {rendetlensegSzint}");
            }
            else if (szine == "többszínű" || szine == "barna")
            {
                Console.WriteLine("Na, hát neked olyan ritka színű cicád van, hogy az csak na");
            }
			else { Console.WriteLine("minden macskának kéne lennie színének"); }
        }

		

		public void CicaFilm()
		{
            Console.WriteLine("Szereted a cicás filmeket? (igen/nem)");
            string valasz = Console.ReadLine().Trim().ToLower(); // Kisbetűsítés és whitespace eltávolítás

            if (valasz == "igen")
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://funzine.hu/2022/03/27/have-fun/121-tunderi-macskas-film-amitol-menthetetlenul-elolvadsz/",
                    UseShellExecute = true
                });
            }
            else
            {
                Console.WriteLine("Hazudós");
            }
        }

		public void KintVagyBenti()
		{
            Console.WriteLine("Kinti vagy benti a cicád? (kinti/benti): ");
            string valasz = Console.ReadLine().Trim().ToLower();

			if (valasz == "kinti")
			{
                Console.WriteLine("nem félsz attól, hogy elszökik? (de/nem): ");
                string elszokike = Console.ReadLine().Trim().ToLower();
				if (elszokike == "nem")
				{
                    Console.WriteLine("miért?: ");
                    string miert = Console.ReadLine().Trim().ToLower();
					if (miert != "")
					{
                        Console.WriteLine("szuper, reméljük akkor tényleg nem fog soha elszökni");
					}
				}
				else
				{
					Console.WriteLine("akkor vagy tegyél valamit, vagy tartsd bent a cicád");
				}
			}
            else if (valasz == "benti")
            {
				Console.WriteLine("Mindenhova felmászhat? (igen/nem)");
				string felmaszhat = Console.ReadLine().Trim().ToLower(); 
				if (felmaszhat == "igen")
				{
                    Console.WriteLine("még az asztalra is? (igen/nem)");
                    string asztalrais = Console.ReadLine().Trim().ToLower();
					if(asztalrais == "igen")
					{
                        Console.WriteLine("why? just... why");
					}
					else
					{
                        Console.WriteLine("hál istennek");
					}
				}
				else
				{
                    Console.WriteLine("huhh, megijedtem hogy még az asztalra is felmászik");
				}
			}
        }



		//tostring
		public override string? ToString()
		{
			return $"Cica neve: {nev}, súlya: {suly} kg, fajta: {fajta}, általában a rendetlenségszintje:{rendetlensegSzint},  ennyit fogyaszt: {fogyasztas}, neme: {nem}, éhes-e : {ehes}";
			//ha nem írjuk ki akkor nincs is :)
		}


		








	}
}
