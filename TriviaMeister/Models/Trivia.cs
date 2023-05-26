using System;
using System.Collections.Generic;

namespace TriviaMeister.Models
{
    class Trivia
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public string Description { get; set; }
        public List<TriviaItem> Items { get; set; }
    }
}
