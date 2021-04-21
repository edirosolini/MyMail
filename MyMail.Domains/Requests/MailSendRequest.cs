// <copyright file="MailSendRequest.cs" company="El Roso">
// Copyright (c) El Roso. All rights reserved.
// </copyright>

namespace MyMail.Domains.Requests
{
    using System.ComponentModel.DataAnnotations;
    using MyMail.Domains.Models;

    public class MailSendRequest
    {
        [Required(ErrorMessage = "{0} is required")]
        public SourceModel Source { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public RecipientModel[] Recipients { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public NotificationModel Notification { get; set; }
    }
}
