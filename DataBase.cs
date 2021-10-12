using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using KursovoiProject.ClassesOfTasks;

namespace KursovoiProject
{
    public static class DataBase
    {
        public static void ReadFromFile()
        {
            using (StreamReader sr = new StreamReader(@"statistics.txt"))
            {
                AccentStatist.statisticsCorrect = 2 * int.Parse(sr.ReadLine());
                AccentStatist.statisticsWrong = 2 * int.Parse(sr.ReadLine());

                LexStatist.statisticsCorrect = int.Parse(sr.ReadLine());
                LexStatist.statisticsWrong = int.Parse(sr.ReadLine());

                MorphStatist.statisticsCorrect = int.Parse(sr.ReadLine());
                MorphStatist.statisticsWrong = int.Parse(sr.ReadLine());

                ParonsStatist.statisticsCorrect = int.Parse(sr.ReadLine());
                ParonsStatist.statisticsWrong = int.Parse(sr.ReadLine());
            };
        }

        public static void WriteInFile()
        {
            using (StreamWriter sw = new StreamWriter(@"statistics.txt", false))
            {
                sw.WriteLine(AccentStatist.statisticsCorrect / 2);
                sw.WriteLine(AccentStatist.statisticsWrong / 2);

                sw.WriteLine(LexStatist.statisticsCorrect);
                sw.WriteLine(LexStatist.statisticsWrong);

                sw.WriteLine(MorphStatist.statisticsCorrect);
                sw.WriteLine(MorphStatist.statisticsWrong);

                sw.WriteLine(ParonsStatist.statisticsCorrect);
                sw.WriteLine(ParonsStatist.statisticsWrong);
            };
        }
    }
}
