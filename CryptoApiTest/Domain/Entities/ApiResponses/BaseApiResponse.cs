﻿using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Entities.ApiResponses
{
    public abstract class BaseApiResponse
    {
        public BaseApiResponse(bool isSuccess, object? data = null, string? message = "")
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
        }

        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
