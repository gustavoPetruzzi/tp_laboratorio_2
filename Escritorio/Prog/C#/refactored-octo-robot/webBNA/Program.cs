using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
namespace webBNA
{
    class Program
    {
        static void Main(string[] args)
        {
            String url = "http://www.bna.com.ar/";
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);

            HtmlNode compraNode =  doc.DocumentNode.SelectSingleNode("//*[@id=\"billetes\"]/table/tbody/tr[1]/td[2]");
            HtmlNode ventaNode = doc.DocumentNode.SelectSingleNode("//*[@id=\"billetes\"]/table/tbody/tr[1]/td[3]");
            String compra = compraNode.WriteContentTo();
            String venta = ventaNode.WriteContentTo();
            Console.WriteLine(compra);
            Console.WriteLine(venta);

            Console.ReadLine();
        }
    }
}
