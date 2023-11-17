﻿using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace eAgendaMedica.WebApi.Controllers
{
    public class ApiControllerBase : ControllerBase
    {
        public override OkObjectResult Ok(object? value)
        {
            return base.Ok(new
            {
                Sucesso = true,
                Dados = value
            });
        }

        public override NotFoundObjectResult NotFound(object? erros)
        {
            var mensagensDeErro = ((IList<IError>)erros).Select(x => x.Message);

            return base.NotFound(new
            {
                Sucesso = false,
                Erros = mensagensDeErro
            });
        }

        public override BadRequestObjectResult BadRequest(object? erros)
        {
            var mensagensDeErro = ((IList<IError>)erros).Select(x => x.Message);

            return base.BadRequest(new
            {
                Sucesso = false,
                Erros = mensagensDeErro
            });
        }
    }
}

