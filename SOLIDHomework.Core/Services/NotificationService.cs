﻿using System;

namespace SOLIDHomework.Core.Services
{
    public class NotificationService: INotificationService
    {
        private readonly IUserService _userService;

        public NotificationService(IUserService userService)
        {
            _userService = userService;
        }

        public void NotifyCustomer()
        {
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
