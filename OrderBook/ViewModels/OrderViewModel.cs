using OrderBook.Commands;
using OrderBook.DBRealization;
using OrderBook.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OrderBook.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        public ICommand AddOrder { get; set; }
        public ICommand DeleteOrder { get; set; }

        private Order _selectedOrder;
        public Order SelectedOrder
        {
            get => _selectedOrder;
            set 
            {
                _selectedOrder = value;
                OnPropertyChanged(nameof(SelectedOrder));
            }
        }

        private ObservableCollection<Order> _orders;
        public ObservableCollection<Order> Orders
        {
            get => _orders;
            set 
            { 
                _orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }

        public OrderViewModel()
        {
            AddOrder = new AddOrderCommand(this);
            DeleteOrder = new DeleteOrderCommand(this);
            using (DataContext db = new DataContext())
            {
                Orders = new ObservableCollection<Order>(db.Orders);
            }
        }
    }
}