using System;

namespace SOLIDHomework.Core.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IUserService _userService;

        public NotificationService(IUserService userService)
        {
            _userService = userService;
        }

        public void NotifyCustomer()
        {
            // Update to same approach: either return a user and use it's properties or separate methods for each property
            string customerEmail = _userService.GetRegisteredUser().Email;
            if (!string.IsNullOrEmpty(customerEmail))
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
}
