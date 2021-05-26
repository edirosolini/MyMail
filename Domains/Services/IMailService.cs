// <copyright file="IMailService.cs" company="El Roso">
// Copyright (c) El Roso. All rights reserved.
// </copyright>

namespace MyMail.Domains.Services
{
    using MyMail.Domains.Requests;
    using MyMail.Domains.Responses;

    public interface IMailService
    {
        ModelResponse Send(MailSendRequest request);
    }
}
