using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VariacaoAtivos.Domain.Entities;
using VariacaoAtivos.Domain.Interfaces;

namespace VariacaoAtivos.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtivoController : ControllerBase
    {
        private readonly ILogger<AtivoController> logger;
        private readonly IServicoAPI<Ativo> service;

        public AtivoController(ILogger<AtivoController> logger, IServicoAPI<Ativo> service)
        {
            this.logger = logger;
            this.service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var consultAtivo = this.service.Get();

            return Ok(consultAtivo);
        }

    }
}
