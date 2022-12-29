﻿using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Operations.OrderDt
{
    interface IOrderRepo
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrder(int id);
    }
}
