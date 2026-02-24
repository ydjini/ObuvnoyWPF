using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using ObuvnoyWPF.Database;
using ObuvnoyWPF.Models;
using ObuvnoyWPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObuvnoyWPF.Controllers
{
    public class OrderController
    {
        private DatabaseContext _dbContext = new();
        private MessageManager _message = new();

        public int GetLastOrderId() 
        {
            return _dbContext.Orders.Last().Id;
        }

        public void AddNewOrder(int CurrentUser, DateTime orderDeliveryDate, int orderPickUpPointId, string orderCode, int orderStatusId)
        {
            if (orderDeliveryDate == DateTime.Today)
            {
                var newOrder = new Order
                {
                    UserId = CurrentUser,
                    DeliveryDate = orderDeliveryDate,
                    PickUpPointId = orderPickUpPointId,
                    OrderCode = orderCode,
                    OrderStatusId = orderStatusId
                };
                _dbContext.Orders.Add(newOrder);
                _dbContext.SaveChanges();
                _message.Success("Успешно добавлено!");
            }
            else
            {
                _message.Error("Время доставки введено неверно");
            }
        }

        public List<Order> GetAllOrders()
        {
            return _dbContext.Orders
                .Include(o => o.OrderStatus)
                .ToList();
        }

        public Order GetOrderById(int orderId)
        {
            var order = _dbContext.Orders.Find(orderId);
            if (order == null)
            {
                _message.Error("Не найдено.");
            }
            return order;
        }

        public void RemoveOrderById(int orderId) 
        {
            var order = GetOrderById(orderId);
            if (order != null)
            {
                _dbContext.Orders.Remove(order);
                _dbContext.SaveChanges();
                _message.Success("Успешно удалено.");
            }
        }

        public void UpdateOrderById(Order updatedOrder)
        {
            var existingOrder = GetOrderById(updatedOrder.Id);
            if (existingOrder != null)
            {
                _dbContext.Entry(existingOrder).CurrentValues.SetValues(updatedOrder);
                _dbContext.SaveChanges();
                _message.Success("Заказ успешно обновлен.");
            }
        }
    }
}
