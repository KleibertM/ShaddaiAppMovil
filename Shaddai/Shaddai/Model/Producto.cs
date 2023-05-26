using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shaddai.Model
{
    public class Producto
    {
        [PrimaryKey, AutoIncrement]
        public int IdItem { get; set; }
        [MaxLength(50)]

        public string Nom { get; set; }
        [MaxLength(50)]

        public string Version { get; set; }
        [MaxLength(50)]
        public int Precio { get; set; }
        [MaxLength(50)]
        public string Descrip { get; set; }

        public string Categoria { get; set; }
        public string Letra { get; set; }
    }
}
