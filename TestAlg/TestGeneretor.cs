using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAlg
{
    class TestGeneretor
    {
        public static TestViewModel Generate(QuestionBlank bank, Action onDone)
        {
            var p = new List<Probe>();
            foreach (var ques in bank.Questions)
            {
                var probe = new Probe();
                probe.Question = ques;
                p.Add(probe);
            }

            var k = new TestViewModel(p, onDone);
            
            return k;
            
        }
    }
}
