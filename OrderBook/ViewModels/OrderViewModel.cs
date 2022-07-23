using OrderBook.Commands;
using OrderBook.DBRealization;
using OrderBook.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace OrderBook.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        #region Commands
        public ICommand AddOrder { get; set; }
        public ICommand DeleteOrder { get; set; }
        public ICommand EditOrder { get; set; }
        public ICommand SaveOrder { get; set; }
        #endregion

        #region Orders
        private ObservableCollection<Order>? _orders;
        public ObservableCollection<Order>? Orders
        {
            get => _orders;
            set
            {
                _orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }
        #endregion

        #region SelectedOrder
        private Order? _selectedOrder;
        public Order? SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                _selectedOrder = value;
                OnPropertyChanged(nameof(SelectedOrder));
            }
        }
        #endregion

        #region OrderProperties
        private string? _name;
        public string? Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string? _date;
        public string? Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        private string? _price;
        public string? Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        private string? _amount;
        public string? Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }

        private string? _discription;
        public string? Discription
        {
            get => _discription;
            set
            {
                _discription = value;
                OnPropertyChanged(nameof(Discription));
            }
        }

        private bool _editable = false;
        public bool Editable
        {
            get => _editable;
            set
            {
                _editable = value;
                OnPropertyChanged(nameof(Editable));
            }
        }
        #endregion

        #region Constructor
        public OrderViewModel()
        {
            AddOrder = new AddOrderCommand(this);
            DeleteOrder = new DeleteOrderCommand(this);
            EditOrder = new EditOrderCommand(this);
            SaveOrder = new SaveOrderCommand(this);
            using (DataContext db = new DataContext())
            {
                if (db.Orders != null)
                {
                    Orders = new ObservableCollection<Order>(db.Orders);
                }
                else
                {
                    Orders = new ObservableCollection<Order>();
                }
            }
        }
        #endregion
    }
}