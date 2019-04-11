using ConsoleApp6;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
namespace Exam
{
  class Program
  {
    static void Main(string[] args)
    {
      Game game = new Game();
      Console.WriteLine("Введите название игры ");
      game.GameName = Console.ReadLine();
      Console.WriteLine("Введите цену игры ");
      game.GamePrice = Console.ReadLine();   

      var keyinfo = Console.ReadKey();
      if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
      {
        using (FileStream fstream = new FileStream(@"Z:\Game\gameinfo.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite))
        {
          XmlSerializer xmlSerializer = new XmlSerializer(typeof(Game),
           new Type[]{typeof (string), typeof (DateTime), typeof (List<string>),
                         typeof(List<string>), typeof(List<string>), typeof(string)});
          xmlSerializer.Serialize(fstream, game);
        }
        Console.WriteLine("Нажмите на пробел для закрытия и сохранения запеси");
      }
      else
        Console.WriteLine("Нажата неверная клавиша");
    }
  }
}