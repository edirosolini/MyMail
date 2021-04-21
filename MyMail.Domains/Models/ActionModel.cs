// <copyright file="ActionModel.cs" company="El Roso">
// Copyright (c) El Roso. All rights reserved.
// </copyright>

namespace MyMail.Domains.Models
{
    using System.ComponentModel.DataAnnotations;
    using MyMail.Domains.Enums;

    public class ActionModel
    {
        public string Label { get; set; }

        public TypeActionEnum Type { get; set; } = TypeActionEnum.Basic;

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Url)]
        public string UrlCallback { get; set; }
    }
}
