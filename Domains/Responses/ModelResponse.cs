// <copyright file="ModelResponse.cs" company="El Roso">
// Copyright (c) El Roso. All rights reserved.
// </copyright>

namespace MyMail.Domains.Responses
{
    using Newtonsoft.Json;

    public class ModelResponse
    {
        public bool Status { get; set; }

        public string Menssage { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
