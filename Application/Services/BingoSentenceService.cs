using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Interfaces;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Models;

namespace Application.Services
{
    public class BingoSentenceService : IBingoSentenceService
    {
        private readonly IBingoContext _bingoContext;
        private readonly IMapper _mapper;

        public BingoSentenceService(IBingoContext bingoContext, IMapper mapper)
        {
            _bingoContext = bingoContext;
            _mapper = mapper;
        }
        
        public async Task<BingoSentenceDto> CreateBingoSentence(BingoSentenceDto sentence)
        {
            if(string.IsNullOrWhiteSpace(sentence.Category) || string.IsNullOrWhiteSpace(sentence.Sentence))
                throw new ArgumentException("Given sentence is not correct...");
            
            var bingoSentence = _mapper.Map<BingoSentence>(sentence);
            
            _bingoContext.BingoSentences.Add(bingoSentence);
            await _bingoContext.SaveChangesAsync(new CancellationToken()); //TODO sprawdzic cancellationToken
            return _mapper.Map<BingoSentenceDto>(bingoSentence);
        }

        public List<BingoSentenceDto> GetAllBingoSentences()
        {
            return _mapper.Map<List<BingoSentenceDto>>(_bingoContext.BingoSentences.ToList());
        }

        public List<BingoSentenceDto> GetAllBingoSentencesByCategory(string category)
        {
            var sentences = _bingoContext.BingoSentences.Where(s => s.Category.Equals(category)).ToList();
            return _mapper.Map<List<BingoSentenceDto>>(sentences);
        }

        public List<string> GetAllBingoSentencesCategories()
        {
            return _bingoContext.BingoSentences.Select(b => b.Category).Distinct().ToList();
        }

        public BingoSentenceDto GetBingoSentenceById(int id)
        {
            var sentence = _bingoContext.BingoSentences.Where(s => s.Id.Equals(id)).FirstOrDefault();
            return _mapper.Map<BingoSentenceDto>(sentence);
        }
    }
}