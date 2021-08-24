using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BingoSentencesController : ControllerBase
    {
        private readonly IBingoSentenceService _bingoSentenceService;

        public BingoSentencesController(IBingoSentenceService bingoSentenceService)
        {
            _bingoSentenceService = bingoSentenceService;
        }

        [HttpGet]
        public ActionResult<List<BingoSentenceDto>> GetAllBingoSentences()
        {
            var sentences = _bingoSentenceService.GetAllBingoSentences();
            if (sentences == null)
                    return NotFound();
            return Ok(sentences);
        }

        [HttpGet("{id:int}", Name="GetBingoSentenceById")]
        public ActionResult<BingoSentenceDto> GetBingoSentenceById([FromRoute] int id)
        {
            var sentence = _bingoSentenceService.GetBingoSentenceById(id);
            if(sentence == null)
                return NotFound();
            
            return Ok(sentence);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSentence(BingoSentenceDto sentence)
        {
            if(sentence == null)
                return BadRequest();
            var createdSentence = await _bingoSentenceService.CreateBingoSentence(sentence);
            
            return CreatedAtRoute(nameof(GetBingoSentenceById), new {id = createdSentence.Id}, createdSentence);
        }
    }
}