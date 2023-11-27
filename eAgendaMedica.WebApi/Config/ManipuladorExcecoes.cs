﻿using System.Text.Json;

namespace eAgendaMedica.WebApi.Config
{
    public class ManipuladorExcecoes
    {
        private readonly RequestDelegate requestDelegate;

        public ManipuladorExcecoes(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext ctx)
        {
            try
            {
                await requestDelegate(ctx);
            }
            catch (Exception ex)
            {
                ctx.Response.StatusCode = 500;
                ctx.Response.ContentType = "application/json";

                var problema = new
                {
                    Sucesso = false,
                    Erros = new List<string>
                        { ex.Message }
                };

                ctx.Response.WriteAsync(JsonSerializer.Serialize(problema));
            }
        }
    }
}

