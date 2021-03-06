﻿using System;
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
                Nombre = "Ejemplo1",
                Puntuacion = 50,
                Puntuacion_Color ="Yellow",
                Sinopsis = "Esto es una prueba",
                Fecha = "21/01/2018",
                Plataforma = "PC"

            };
            
            var todoItem2 = new TodoItem
            {
                ID = "b94afb54-a1cb-4313-8af3-b7511551b33b",
                Nombre = "Ejemplo2",
                Puntuacion = 50,
                Puntuacion_Color = "Yellow",
                Sinopsis = "Esto es una prueba",
                Fecha = "21/01/2018",
                Plataforma = "PC"

            }; 

            var todoItem3 = new TodoItem
            {
                ID = "ecfa6f80-3671-4911-aabe-63cc442c1ecf",
                Nombre = "Ejemplo3",
                Puntuacion = 50,
                Puntuacion_Color = "Yellow",
                Sinopsis = "Esto es una prueba",
                Fecha = "21/02/2018",
                Plataforma = "PC"

            };

            _todoList.Add(todoItem1);
            _todoList.Add(todoItem2);
            _todoList.Add(todoItem3);
        }
    }
}
