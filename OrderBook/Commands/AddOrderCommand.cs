using OrderBook.DBRealization;
using OrderBook.Models;
using OrderBook.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBook.Commands
{
    public class AddOrderCommand : BaseCommand
    {
        private OrderViewModel _orderViewModel;

        public AddOrderCommand(OrderViewModel orderViewModel)
        {
            _orderViewModel = orderViewModel;
            _orderViewModel.PropertyChanged += OrderViewModelPropertyChanged;
        }

        private void OrderViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(OrderViewModel.Orders))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            using (DataContext db = new DataContext())
            {
                Order order = new Order();
                db.Orders.Add(order);
                _orderViewModel.Orders.Add(order);
                db.SaveChanges();
            }
        }
    }
}
