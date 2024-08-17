using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class JogadorQuests
    {
        public Quest Detalhes { get; set; }
        public bool IsCompleted { get; set; }
        public JogadorQuests(Quest detalhes) 
        {
            Detalhes = detalhes;
            IsCompleted = false;
        }
    }
}
