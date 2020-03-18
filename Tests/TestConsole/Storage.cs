using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestConsole
{
    abstract class Storage<TItem>
    {
        protected readonly List<TItem> _Items = new List<TItem>();

        public void Add(TItem Item)
        {
            if (_Items.Contains(Item)) return;
            _Items.Add(Item);
        }

        public bool Remove(TItem Item)
        {
            return _Items.Remove(Item);
        }


        public abstract void SaveToFile(String FileName);

    }

    class Dekanat : Storage<Student>
    {
        public override void SaveToFile(string FileName)
        {
            //using (var file_stream = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None))
            //using (var writer = new StreamWriter(file_stream))
            //{
            //    //Работа с файлами на запись
            //}


            using (var file_writer = File.CreateText(FileName))
            {
                foreach (var student in _Items)
                {
                    file_writer.Write(student.Name);
                    if (student.Ratings.Count > 0)
                    {
                        var ratings_stream = string.Join(",", student.Ratings);
                        file_writer.Write($",{ratings_stream}");
                    }

                    file_writer.WriteLine();
                }

            }
        }
    }
}
