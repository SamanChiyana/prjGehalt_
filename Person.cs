using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace prjGehalt
{
    public class Person
    {
        private static int idAutowert = 0;


        private int Id;
        private string Name;
        private int Alter;
        private int Gehalt;

        public Person(string name, int alter, int gehalt)
        {
            this.Id = idAutowert;
            this.Name = name;
            this.Alter = alter;
            this.Gehalt = gehalt;
            idAutowert++;
        }

        public int id { get => Id; set => Id = value; }
        public string name { get => Name; set => Name = value; }
        public int alter { get => Alter; set => Alter = value; }
        public int gehalt { get => Gehalt; set => Gehalt = value; }
    }
}
