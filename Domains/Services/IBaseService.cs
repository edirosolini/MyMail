// <copyright file="IBaseService.cs" company="El Roso">
// Copyright (c) El Roso. All rights reserved.
// </copyright>

namespace MyMail.Domains.Services
{
    using System;
    using MyMail.Domains.Responses;

    public interface IBaseService<T>
        where T : class
    {
        object GetList(int since, int limit);

        object GetById(Guid id);

        ModelResponse Delete(Guid id);

        ModelResponse Insert(T entity);

        ModelResponse Update(T entity);
    }
}
