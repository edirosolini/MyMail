// <copyright file="NotificationModel.cs" company="El Roso">
// Copyright (c) El Roso. All rights reserved.
// </copyright>

namespace MyMail.Domains.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;

    public class NotificationModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} should be minimum 3 characters and a maximum of 50 characters.")]
        [DataType(DataType.Text)]
        public string Subject { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(2500, MinimumLength = 3, ErrorMessage = "{0} should be minimum 3 characters and a maximum of 50 characters.")]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        public IFormFile[] Attachments { get; set; }

        // public ActionModel[] Actions { get; set; }
    }
}
