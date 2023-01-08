﻿using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * 
 * Autores do projecto: Luis Esteves/16960 || João Riberio/17214;
 * Disciplina: Integração de Sistemas de Informação;
 * Projecto II;
 * Propósito do trabalho: Criar uma API REST Full de gerência de utilizadores e de entrega de livros;
 *
 */
namespace DAL.Operations.OrderDt
{
    interface IOrderRepo
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrder(int id);

        bool CreateOrder(Order o);

        bool UpdateOrder(Order o);

        bool DeleteOrder(int id);

    }
}
