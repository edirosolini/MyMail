// <copyright file="MailController.cs" company="El Roso">
// Copyright (c) El Roso. All rights reserved.
// </copyright>

namespace MyMail.Web.Controllers
{
    using log4net;
    using Microsoft.AspNetCore.Mvc;
    using MyMail.Domains.Requests;
    using MyMail.Domains.Responses;
    using MyMail.Domains.Services;

    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService service;

        public MailController(IMailService service)
        {
            this.service = service;
        }

        [HttpPost]
        public ModelResponse Post([FromForm] MailSendRequest request) => this.service.Send(request);
    }
}
