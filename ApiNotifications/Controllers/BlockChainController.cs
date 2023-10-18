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
    public class BlockChainController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BlockChainController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<BlockChainDTO>>> Get()
        {
            var block = await _unitOfWork.BlockChains.GetAllAsync();
            return _mapper.Map<List<BlockChainDTO>>(block);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BlockChainDTO>> Get(int id)
        {
            var block = await _unitOfWork.BlockChains.GetByIdAsync(id);

            if (block == null)
            {
                return NotFound();
            }

            return _mapper.Map<BlockChainDTO>(block);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BlockChain>> Post(BlockChainDTO blockChainDTO)
        {
            var block = _mapper.Map<BlockChain>(blockChainDTO);
            if (block.FechaCreacion == DateOnly.MinValue)
            {
                block.FechaCreacion = DateOnly.Parse(DateTime.Now.ToString());
            }

            this._unitOfWork.BlockChains.Add(block);
            await _unitOfWork.SaveAsync();

            if (block == null)
            {
                return BadRequest();
            }
            blockChainDTO.Id = block.Id;
            return CreatedAtAction(nameof(Post), new { id = blockChainDTO.Id }, blockChainDTO);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BlockChainDTO>> Put(int id, [FromBody] BlockChainDTO blockChainDTO)
        {
            if (blockChainDTO.FechaModificacion == DateOnly.Parse("0001-01-01"))
            {
                blockChainDTO.FechaModificacion = DateOnly.Parse(DateTime.Now.ToString());
            }

            if (blockChainDTO.Id == 0)
            {
                blockChainDTO.Id = id;
            }

            if (blockChainDTO.Id != id)
            {
                return BadRequest();
            }

            if (blockChainDTO == null)
            {
                return NotFound();
            }

            var block = _mapper.Map<BlockChain>(blockChainDTO);
            _unitOfWork.BlockChains.Update(block);
            await _unitOfWork.SaveAsync();
            return blockChainDTO;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var block = await _unitOfWork.BlockChains.GetByIdAsync(id);

            if (block == null)
            {
                return NotFound();
            }

            _unitOfWork.BlockChains.Remove(block);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}