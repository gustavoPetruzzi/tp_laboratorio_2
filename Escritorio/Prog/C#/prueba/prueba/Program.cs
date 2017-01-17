using System;
using System.IO;

namespace prueba
{
	class Program
	{
		
		public static void Main(string[] args)
		{
			/*
			FileStream fichero;
			string archivo = @"I:\Documents and Settings\Gustavo\Escritorio\ground_EA.gif";
			byte unDato;
			try
			{
				fichero = File.OpenRead(archivo);
				
				for(int i = 0; i<2;i++)
				{
					unDato = (byte) fichero.ReadByte();
					Console.WriteLine("El dato leido es {0}", Convert.ToChar(unDato));
				}
				
				fichero.Close();
				Console.Write("Press any key to continue . . . ");
				Console.ReadKey(true);
				
			}
			catch(Exception e)
			{
				Console.WriteLine("Error: "+e.Message);
				Console.Write("Press any key to continue . . . ");
				Console.ReadKey(true);
				return;
			}
			*/
			string nombre = @"I:\Documents and Settings\Gustavo\Escritorio\Csharp\ejemplo.exe";
 			
			BinaryReader fichero = new BinaryReader(File.Open(nombre, FileMode.Open));
 			short dato1 = fichero.ReadByte();
 			short dato2 = fichero.ReadByte();
 			Console.WriteLine("El dato leido es {0}", dato1 + dato2*256);
 			fichero.Close();
 			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
			
		}
	
	}
			
}