using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosRest
{
    public class Horario
    {
        public string horaCierre { get; set; }
        public string horaApertura { get; set; }
        public string dia { get; set; }
    }

    public class Museo
    {
        public string _id { get; set; }
        public string nombre { get; set; }
        public string categoria { get; set; }
        public string id { get; set; }
        public string imagen { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public List<Horario> horarios { get; set; }
        public string descripcionCorta { get; set; }
        public string facebook { get; set; }
        public string facebookid { get; set; }
        public string twitter { get; set; }
        public string twitterId { get; set; }
        public string instagram { get; set; }
        public string web { get; set; }
    }
}
