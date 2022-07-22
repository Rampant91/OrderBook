using OrderBook.DBRealization;
using OrderBook.Models;
using OrderBook.ViewModels;
using System.ComponentModel;

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
            Order order = new Order { Name = "test" };
            using (DataContext db = new DataContext())
            {
                var orders = db.Orders;
                orders.Add(order);
                _orderViewModel.Orders.Add(order);
                db.SaveChanges();
            }
        }
    }
}
