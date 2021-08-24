using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dtos;

namespace Application.Services.Interfaces
{
    public interface IBingoSentenceService
    {
        public Task<BingoSentenceDto> CreateBingoSentence(BingoSentenceDto sentence);

        public BingoSentenceDto GetBingoSentenceById(int id);
        public List<BingoSentenceDto> GetAllBingoSentences();
        public List<BingoSentenceDto> GetAllBingoSentencesByCategory(string category);
        public List<string> GetAllBingoSentencesCategories();
    }
}