using SOLIDHomework.Core.Model;
using SOLIDHomework.Core.Payment;
using SOLIDHomework.Core.Services;
using System;
using System.Configuration;
using System.IO;

namespace SOLIDHomework.Core
{
    //Order - check inventory, charge money for credit card and online payments, 
    //tips:
    //think about SRP, DI, OCP
    //maybe for each type of payment type make sense to have own Order-based class?
    public class OrderService
    {        
        public Inventory Inventory { get; set; }
        public MyLogger Logger { get; set; }
        public NotificationService NotificationService { get; set; }
        public PaymentService PaymentService { get; set; }

        public void Checkout(string username, ShoppingCart shoppingCart, PaymentDetails paymentDetails, bool notifyCustomer)
        {
            var paymentMethodFactory = new PaymentMethodFactory(PaymentService, NotificationService);
            paymentMethodFactory.GetPaymentMethod(paymentDetails, shoppingCart, username, notifyCustomer);           
            Inventory.ReserveInventory(shoppingCart);
            Logger.Write("Success checkout");
        }       
    }

    public class Inventory
    {
        public void ReserveInventory(ShoppingCart cart)
        {
            foreach (OrderItem item in cart.OrderItems)
            {
                try
                {
                    InventoryService inventoryService = new InventoryService();
                    inventoryService.Reserve(item.Code, item.Amount);
                }
                catch (InsufficientInventoryException ex)
                {
                    throw new OrderException("Insufficient inventory for item " + item.Code, ex);
                }
                catch (Exception ex)
                {
                    throw new OrderException("Problem reserving inventory", ex);
                }
            }
        }
    }

    public class MyLogger
    {
        private readonly string filePath;
        public MyLogger()
        {
            filePath = ConfigurationManager.AppSettings["logPath"];
        }
        public void Write(string text)
        {
            using (Stream file = File.OpenWrite(filePath))
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    writer.WriteLine(text);
                }
            }
        }
    }

    public class NotificationService
    {
        public void NotifyCustomer(string username)
        {
            string customerEmail = new UserService().GetByUsername(username).Email;
            if (!String.IsNullOrEmpty(customerEmail))
            {
                try
                {
                    //construct the email message and send it, implementation ignored
                }
                catch (Exception ex)
                {
                    //log the emailing error, implementation ignored
                }
            }
        }
    }

    public class PaymentService
    {
        public void ChargeCard(PaymentDetails paymentDetails, ShoppingCart cart)
        {
            PaymentServiceType paymentServiceType;
            Enum.TryParse(ConfigurationManager.AppSettings["paymentType"], out paymentServiceType);
            try
            {
                IPaymentBase payment = PaymentFactory.GetPaymentService(paymentServiceType);
                string serviceResponse = payment.Charge(cart.TotalAmount(), new CreditCart()
                {
                    CardNumber = paymentDetails.CreditCardNumber,
                    ExpiryDate = paymentDetails.ExpiryDate,
                    NameOnCard = paymentDetails.CardholderName
                });

                if (!serviceResponse.Contains("200OK") && !serviceResponse.Contains("Success"))
                {
                    throw new Exception(String.Format("Error on charge : {0}", serviceResponse));
                }
            }
            catch (AccountBalanceMismatchException ex)
            {
                throw new OrderException("The card gateway rejected the card based on the address provided.", ex);
            }
            catch (Exception ex)
            {
                throw new OrderException("There was a problem with your card.", ex);
            }
        }
    }

    public abstract class PaymentMethodBase
    {
        protected PaymentService _paymentService;
        protected NotificationService _notificationService;
        protected PaymentDetails _paymentDetails;
        protected ShoppingCart _shoppingCart;       
       
        protected PaymentMethodBase(PaymentService paymentService, NotificationService notificationService, PaymentDetails paymentDetails, ShoppingCart shoppingCart)
        {
            _paymentService = paymentService;
            _notificationService = notificationService;
            _paymentDetails = paymentDetails;
            _shoppingCart = shoppingCart;           
        }
       
        public abstract void ProcessPayment();
    }

    public class CreditCardPayment : PaymentMethodBase
    {
        public CreditCardPayment(PaymentService paymentService, NotificationService notificationService, PaymentDetails paymentDetails, ShoppingCart shoppingCart)
        : base(paymentService, notificationService, paymentDetails, shoppingCart) { }

        public override void ProcessPayment()
        {
            _paymentService.ChargeCard(_paymentDetails, _shoppingCart);
        }                
    }

    public class OnlineOrderPayment : PaymentMethodBase
    {
        protected string _username;
        protected bool _notifyCustomer;
        public OnlineOrderPayment(PaymentService paymentService, NotificationService notificationService, PaymentDetails paymentDetails, ShoppingCart shoppingCart, string username, bool notifyCustomer)
        : base(paymentService, notificationService, paymentDetails, shoppingCart) 
        {
            _username = username;
            _notifyCustomer = notifyCustomer;
        }

        public override void ProcessPayment()
        {
            _paymentService.ChargeCard(_paymentDetails, _shoppingCart);
            if (_notifyCustomer)
            {
                _notificationService.NotifyCustomer(_username);
            }
        }
    }    

    public class PaymentMethodFactory
    {
        private NotificationService _notificationService;
        private PaymentService _paymentService;

        public PaymentMethodFactory(PaymentService paymentService, NotificationService notificationService)
        {
            _paymentService = paymentService;
            _notificationService = notificationService;
        }
        public void GetPaymentMethod(PaymentDetails paymentDetails, ShoppingCart shoppingCart, string username, bool notifyCustomer)
        {
            switch (paymentDetails.PaymentMethod)
            {
                case PaymentMethod.CreditCard:
                    new CreditCardPayment(_paymentService, _notificationService, paymentDetails, shoppingCart).ProcessPayment();
                    break;
                    
                case PaymentMethod.OnlineOrder:
                    new OnlineOrderPayment(_paymentService, _notificationService, paymentDetails, shoppingCart, username, notifyCustomer).ProcessPayment();
                    break;

                default:
                    throw new NotSupportedException($"Payment method {paymentDetails.PaymentMethod} is not supported.");
            }
        }
    }      

    public class OrderException : Exception
    {
        public OrderException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    public class AccountBalanceMismatchException : Exception
    {
    }
}
