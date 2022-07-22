using OrderBook.DBRealization;
using OrderBook.Models;
using OrderBook.ViewModels;
using System.ComponentModel;
using System.Linq;

namespace OrderBook.Commands
{
    public class DeleteOrderCommand : BaseCommand
    {
        private OrderViewModel _orderViewModel;

        public DeleteOrderCommand(OrderViewModel orderViewModel)
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
            if (e.PropertyName == nameof(OrderViewModel.SelectedOrder))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return _orderViewModel.SelectedOrder != null;
        }

        public override void Execute(object? parameter)
        {
            Order order = _orderViewModel.SelectedOrder;
            using (DataContext db = new DataContext())
            {
                var orderDb = db.Orders.FirstOrDefault(x=> x.Id == order.Id);
                if (orderDb != null)
                {
                    db.Orders.Remove(orderDb);
                    _orderViewModel.Orders.Remove(order);
                    db.SaveChanges();
                }
            }
        }
    }
}