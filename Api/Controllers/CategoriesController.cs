using System.Collections.Generic;
using Application.Dtos;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IBingoSentenceService _bingoSentenceService;

        public CategoriesController(IBingoSentenceService bingoSentenceService)
        {
            _bingoSentenceService = bingoSentenceService;
        }

        [HttpGet]
        public ActionResult<List<string>> GetAllCategories()
        {
            return _bingoSentenceService.GetAllBingoSentencesCategories();
        }

        [HttpGet]
        [Route("{category}/sentences")]
        public ActionResult<List<BingoSentenceDto>> GetAllBingoSentences([FromRoute] string category)
        {
            List<BingoSentenceDto> sentences;
            if(string.IsNullOrWhiteSpace(category))
                sentences = _bingoSentenceService.GetAllBingoSentences();
            else
                sentences = _bingoSentenceService.GetAllBingoSentencesByCategory(category);
            if (sentences == null)
                    return NotFound();
            return Ok(sentences);
        }
    }
}