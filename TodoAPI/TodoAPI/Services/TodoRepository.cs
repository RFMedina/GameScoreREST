using System;
using System.Collections.Generic;
using System.Linq;
using TodoAPI.Interfaces;
using TodoAPI.Models;

namespace TodoAPI.Services
{
    public class TodoRepository : ITodoRepository
    {
        private List<TodoItem> _todoList;

        public TodoRepository()
        {
            InitializeData();
        }

        public IEnumerable<TodoItem> All
        {
            get { return _todoList; }
        }

        public bool DoesItemExist(string id)
        {
            return _todoList.Any(item => item.ID == id);
        }

        public TodoItem Find(string id)
        {
            return _todoList.FirstOrDefault(item => item.ID == id);
        }

        public void Insert(TodoItem item)
        {
            _todoList.Add(item);
        }

        public void Update(TodoItem item)
        {
            var todoItem = this.Find(item.ID);
            var index = _todoList.IndexOf(todoItem);
            _todoList.RemoveAt(index);
            _todoList.Insert(index, item);
        }

        public void Delete(string id)
        {
            _todoList.Remove(this.Find(id));
        }

        private void InitializeData()
        {
            _todoList = new List<TodoItem>();

            var todoItem1 = new TodoItem
            {
                ID = "6bb8a868-dba1-4f1a-93b7-24ebce87e243",
                Nombre = "Hello Neighbor",
                Puntuacion = 38,
                Puntuacion_Color ="Red",
                Sinopsis = "Un juego de terror y sigilo sobre irrumpir en la casa de un vecino. Juega contra una IA avanzada que aprende de tus acciones y las contrarresta. Descubra los horribles secretos que esconde su vecino dentro de su sótano. ",
                Fecha = "08/12/2017",
                Plataforma = "PC",
                Plataforma_Img = "PClogo.png"

            };
            
            var todoItem2 = new TodoItem
            {
                ID = "b94afb54-a1cb-4313-8af3-b7511551b33b",
                Nombre = "The Last of Us II",
                Puntuacion = 93,
                Puntuacion_Color = "Green",
                Sinopsis = "Cinco años después de su peligroso viaje a través de los Estados Unidos después de la pandemia, Ellie y Joel se establecieron en Jackson, Wyoming. Vivir entre una próspera comunidad de supervivientes ha permitido ... ",
                Fecha = "19/06/2020",
                Plataforma = "PlayStation",
                Plataforma_Img = "PSLogo.png"

            }; 

            var todoItem3 = new TodoItem
            {
                ID = "ecfa6f80-3671-4911-aabe-63cc442c1ecf",
                Nombre = "The Medium",
                Puntuacion = 71,
                Puntuacion_Color = "Orange",
                Sinopsis = "Conviértete en un médium que vive en dos mundos diferentes: el real y el espiritual. Perseguido por la visión del asesinato de un niño, viajas a un complejo hotelero abandonado, que hace muchos años ... ",
                Fecha = "28/01/2021",
                Plataforma = "Xbox",
                Plataforma_Img = "XboxLogo.png"

            };

            _todoList.Add(todoItem1);
            _todoList.Add(todoItem2);
            _todoList.Add(todoItem3);
        }
    }
}
