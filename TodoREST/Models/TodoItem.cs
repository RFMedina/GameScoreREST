using System;

namespace TodoREST
{
	public class TodoItem
	{
		public string ID { get; set; }
		public string Nombre { get; set; }
		public int Puntuacion { get; set; }
		public string Sinopsis { get; set; }

        private DateTime valor_fecha;
        public string Fecha
        {
            get
            {
                return valor_fecha.ToString("dd/MM/yyyy");
            }
            set
            {
                this.valor_fecha = Convert.ToDateTime(Fecha);

            }
        }
        public string Plataforma { get; set; }
	}
}
