using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaMeister.Models;

namespace TriviaMeister.Services
{
    public class TriviaStore : IDataStore<Trivia>
    {
        readonly List<Trivia> _trivias;

        public TriviaStore()
        {
            _trivias = new List<Trivia>()
            {
                new Trivia {
                    Title = "Biology Quiz", 
                    Description = "A basic biology trivia.",
                    Items = new List<TriviaItem>
                    {
                        new TriviaItem 
                        {
                            Prompt = "What fish body part is used for breathing?",
                            Answer = "Gills",
                        },
                        new TriviaItem
                        {
                            Prompt = "What fish is orange?",
                            Answer = "Goldfish"
                        }
                    }
                },
                new Trivia {
                    Title = "Math Quiz",
                    Description = "A basic math trivia.",
                    Items = new List<TriviaItem>
                    {
                        new TriviaItem
                        {
                            Prompt = "1 + 1 = ?",
                            Answer = "2",
                        },
                        new TriviaItem
                        {
                            Prompt = "Who is the creator of Boolean Algebra?",
                            Answer = "George Boole"
                        }
                    }
                },
            };
        }

        public async Task<bool> AddItemAsync(Trivia item)
        {
            _trivias.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var trivia = _trivias.Where((Trivia t) => t.Id == id).FirstOrDefault();
            if (trivia == default(Trivia))
            {
                return await Task.FromResult(false);
            }
            
            _trivias.Remove(trivia);
            return await Task.FromResult(true);
        }

        public async Task<Trivia> GetItemAsync(string id)
        {
            var trivia = _trivias.Where((Trivia t) => t.Id == id).FirstOrDefault();

            return await Task.FromResult(trivia);
        }

        public async Task<IEnumerable<Trivia>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(_trivias);
        }

        public async Task<bool> UpdateItemAsync(Trivia newTrivia)
        {
            var oldTrivia = _trivias.Where((Trivia t) => t.Id == newTrivia.Id).FirstOrDefault();
            if(oldTrivia == default(Trivia))
            {
                return await Task.FromResult(false);
            }
            
            _trivias.Remove(oldTrivia);
            _trivias.Add(newTrivia);

            return await Task.FromResult(true);
        }
    }
}
