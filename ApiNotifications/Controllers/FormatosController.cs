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
    public class FormatosController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FormatosController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<FormatosDTO>>> Get()
        {
            var formats = await _unitOfWork.Formatos.GetAllAsync();
            return _mapper.Map<List<FormatosDTO>>(formats);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FormatosDTO>> Get(int id)
        {
            var formats = await _unitOfWork.Formatos.GetByIdAsync(id);

            if (formats == null)
            {
                return NotFound();
            }

            return _mapper.Map<FormatosDTO>(formats);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Formatos>> Post(FormatosDTO formatosDTO)
        {
            var formats = _mapper.Map<Formatos>(formatosDTO);
            if (formats.FechaCreacion == DateOnly.MinValue)
            {
                formats.FechaCreacion = DateOnly.Parse(DateTime.Now.ToString());
            }

            this._unitOfWork.Formatos.Add(formats);
            await _unitOfWork.SaveAsync();

            if (formats == null)
            {
                return BadRequest();
            }
            formatosDTO.Id = formats.Id;
            return CreatedAtAction(nameof(Post), new { id = formatosDTO.Id }, formatosDTO);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FormatosDTO>> Put(int id, [FromBody] FormatosDTO formatosDTO)
        {
            if (formatosDTO.FechaModificacion == DateOnly.Parse("0001-01-01"))
            {
                formatosDTO.FechaModificacion = DateOnly.Parse(DateTime.Now.ToString());
            }

            if (formatosDTO.Id == 0)
            {
                formatosDTO.Id = id;
            }

            if (formatosDTO.Id != id)
            {
                return BadRequest();
            }

            if (formatosDTO == null)
            {
                return NotFound();
            }

            var formats = _mapper.Map<Formatos>(formatosDTO);
            _unitOfWork.Formatos.Update(formats);
            await _unitOfWork.SaveAsync();
            return formatosDTO;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var formats = await _unitOfWork.Formatos.GetByIdAsync(id);

            if (formats == null)
            {
                return NotFound();
            }

            _unitOfWork.Formatos.Remove(formats);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}