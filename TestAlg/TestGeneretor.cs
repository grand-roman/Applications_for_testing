using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAlg
{
    class TestGeneretor
    {
        public static List<Question> Generate(QuestionBlank bank)
        {

            return bank.Questions;
        }
    }
}
