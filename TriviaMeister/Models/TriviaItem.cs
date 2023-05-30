using System;

namespace TriviaMeister.Models
{
    public class TriviaItem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Prompt { get; set; }
        public string Answer { get; set; }
    }
}
