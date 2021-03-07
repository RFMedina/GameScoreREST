using System;
using System.Globalization;
using Xamarin.Forms;

namespace TodoREST
{
	public partial class TodoItemPage : ContentPage
	{
		bool isNewItem;

        public TodoItemPage (bool isNew = false)
		{
			InitializeComponent ();
			isNewItem = isNew;
		}

		async void OnSaveButtonClicked (object sender, EventArgs e)
		{
			var todoItem = (TodoItem)BindingContext;
			await App.TodoManager.SaveTaskAsync (todoItem, isNewItem);
			await Navigation.PopAsync ();

			if (todoItem.Nombre != null && todoItem.Puntuacion != null)
			{
				string mensaje = "Se ha guardado con éxito";
				DependencyService.Get<IMessage>().ShortAlert(mensaje);
            }
            else
            {
				string mensaje = "No se ha guardado el registro";
				DependencyService.Get<IMessage>().ShortAlert(mensaje);
			}
		}

		async void OnDeleteButtonClicked (object sender, EventArgs e)
		{
			var todoItem = (TodoItem)BindingContext;

			bool res = await DisplayAlert("Atención", "¿Seguro que desea borrar el registro?", "Si", "No");

			if (res == true)
            {
				await App.TodoManager.DeleteTaskAsync(todoItem);
				await Navigation.PopAsync();

				if (todoItem.Nombre != null && todoItem.Puntuacion != null)
				{
					string mensaje = "Se ha borrado con éxito";
					DependencyService.Get<IMessage>().ShortAlert(mensaje);
				}
			}

		}

        private void CovertirFecha(object sender, DateChangedEventArgs e)
        {
			var selector = sender as DatePicker;

			DateTime fecha = selector.Date;

			var todoItem = (TodoItem)BindingContext;

			//Recogemos la fecha dependiendo del idioma del dispositivo
			if (CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "en")
            {
				todoItem.Fecha = fecha.ToString("MM/dd/yyyy");
			}

			if (CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "es")
            {
				todoItem.Fecha = fecha.ToString("dd/MM/yyyy");
			}

			
        }

        private void RegPuntucion(object sender, ValueChangedEventArgs e)
        {
			var slider = sender as Slider;

			int puntuacion = (int)slider.Value;

			var todoItem = (TodoItem)BindingContext;

			todoItem.Puntuacion = puntuacion;

			Color(puntuacion, todoItem);


        }

		private void Color(int puntuacion, TodoItem todoItem)
        {
			if(puntuacion < 50)
            {
				todoItem.Puntuacion_Color = "Red";
            }
            else
            {
				if(puntuacion < 75)
                {
					todoItem.Puntuacion_Color = "Orange";
                }
                else
                {
					todoItem.Puntuacion_Color = "Green";
                }
            }

        }

        private void PlataformaSelec(object sender, EventArgs e)
        {
			var selector = sender as Picker;

			int indice = selector.SelectedIndex;

			var todoItem = (TodoItem)BindingContext;

			//Para PC
			if(indice == 0)
            {
				todoItem.Plataforma_Img = "PClogo.png";

			}

			//Para Xbox
			if (indice == 1)
			{
				todoItem.Plataforma_Img = "XboxLogo.png";

			}
			//Para PlayStation
			if (indice == 2)
			{
				todoItem.Plataforma_Img = "PSLogo.png";

			}

			//Para Switch
			if (indice == 3)
			{
				todoItem.Plataforma_Img = "NSLogo.png";

			}
		}
    }
}
