using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bot
{
    [Serializable]
    [Table("Phrases")]
    public class Phrase
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public string Answer { get; set; }
    }
}
