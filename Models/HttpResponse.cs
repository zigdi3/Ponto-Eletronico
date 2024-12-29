﻿namespace PontoEletronico.Models
{
    public class HttpResponse<T>
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public T Data { get; set; }

            public HttpResponse(bool success, string message, T data)
            {
                Success = success;
                Message = message;
                Data = data;
            }
        }
    }
