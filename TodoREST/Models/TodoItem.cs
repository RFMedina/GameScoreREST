using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TodoREST
{
	public class TodoItem : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] String fecha = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(fecha));
		}
		public string ID { get; set; }
		public string Nombre { get; set; }
		public int Puntuacion { get; set; }
		public string Sinopsis { get; set; }

		private string fecha;
        public string Fecha {
			get { return fecha; }
			set 
			{
				fecha = value;
				OnPropertyChanged();
			}
		}

		public DateTime Valor_fecha
        {
            get
            {
				return Convert.ToDateTime(Fecha);
            }
            set { }
        }
		public string Plataforma { get; set; }
	}
}
