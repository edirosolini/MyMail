// <copyright file="SourceModel.cs" company="El Roso">
// Copyright (c) El Roso. All rights reserved.
// </copyright>

namespace MyMail.Domains.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SourceModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} should be minimum 3 characters and a maximum of 50 characters.")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}
