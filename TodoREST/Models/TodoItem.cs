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

		private int puntuacion;
		public int Puntuacion {
			get { return puntuacion; }
			set 
			{
				puntuacion = value;
				OnPropertyChanged();
			} 
		}

		public double Puntuacion_Double
        {
            get { return Convert.ToDouble(Puntuacion); }
            set { }
        }
		private string color;
		public string Puntuacion_Color { 
			get { return color; }
			set 
			{
				color = value;
				OnPropertyChanged();
			} 
		}
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

		public string Plataforma_Img { get; set; }
	}
}
