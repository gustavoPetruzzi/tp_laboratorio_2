using System;

public class Ejemplo
{
    public static void Main()
    {
        Titulo t = new Titulo(38,5, "Hola");
        t.Escribir();
    }
}


public class Titulo
{
    private int x;
    private int y;
    private string texto;
    
    public Titulo(int x, int y, string texto)
    {
        this.x = x;
        this.y = y;
        this.texto = texto;
    }
    public void Escribir()
    {
        Console.SetCursorPosition(x,y);
        Console.Writeline(texto);
    }
}