using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNotifications.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiNotifications.Controllers
{
    public class RadicadosController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RadicadosController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<RadicadosDTO>>> Get()
        {
            var registered = await _unitOfWork.Radicados.GetAllAsync();
            return _mapper.Map<List<RadicadosDTO>>(registered);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RadicadosDTO>> Get(int id)
        {
            var registered = await _unitOfWork.Radicados.GetByIdAsync(id);

            if (registered == null)
            {
                return NotFound();
            }

            return _mapper.Map<RadicadosDTO>(registered);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Radicados>> Post(RadicadosDTO radicadosDTO)
        {
            var registered = _mapper.Map<Radicados>(radicadosDTO);
            if (registered.FechaCreacion == DateOnly.MinValue)
            {
                registered.FechaCreacion = DateOnly.Parse(DateTime.Now.ToString());
            }

            this._unitOfWork.Radicados.Add(registered);
            await _unitOfWork.SaveAsync();

            if (registered == null)
            {
                return BadRequest();
            }
            radicadosDTO.Id = registered.Id;
            return CreatedAtAction(nameof(Post), new { id = radicadosDTO.Id }, radicadosDTO);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RadicadosDTO>> Put(int id, [FromBody] RadicadosDTO radicadosDTO)
        {
            if (radicadosDTO.FechaModificacion == DateOnly.Parse("0001-01-01"))
            {
                radicadosDTO.FechaModificacion = DateOnly.Parse(DateTime.Now.ToString());
            }

            if (radicadosDTO.Id == 0)
            {
                radicadosDTO.Id = id;
            }

            if (radicadosDTO.Id != id)
            {
                return BadRequest();
            }

            if (radicadosDTO == null)
            {
                return NotFound();
            }

            var registered = _mapper.Map<Radicados>(radicadosDTO);
            _unitOfWork.Radicados.Update(registered);
            await _unitOfWork.SaveAsync();
            return radicadosDTO;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var registered = await _unitOfWork.Radicados.GetByIdAsync(id);

            if (registered == null)
            {
                return NotFound();
            }

            _unitOfWork.Radicados.Remove(registered);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}