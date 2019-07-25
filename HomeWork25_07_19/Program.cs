using System;
using System.Collections.Generic;

namespace HomeWork25_07_19
{
    //Chain of responsibility
    public interface IProblemSolver
    {
        IProblemSolver SetNext(IProblemSolver problemSolver);
        string Solve(object problem);
    }

    public abstract class ProblemSolver : IProblemSolver
    {
        private IProblemSolver _nextProblemSolver;

        public IProblemSolver SetNext(IProblemSolver problemSolver)
        {
            _nextProblemSolver = problemSolver;
            return problemSolver;
        }

        public virtual string Solve(object problem)
        {
            if (_nextProblemSolver != null)
            {
                return _nextProblemSolver.Solve(problem);
            }
            else
            {
                throw new Exception();
            }
        }
    }

    public class MathProblemSolver : ProblemSolver
    {
        public override string Solve(object problem)
        {
            if(problem.ToString().ToLower() == "math")
            {
                return "MathProblemSolver is able to solve this problem";
            }
            else
            {
                return base.Solve(problem);
            }
        }
    }

    public class LinguisticProblemSolver : ProblemSolver
    {
        public override string Solve(object problem)
        {
            if (problem.ToString().ToLower() == "linguist")
            {
                return "LinguisticProblemSolver is able to solve this problem";
            }
            else
            {
                return base.Solve(problem);
            }
        }
    }

    public class TechnicProblemSolver : ProblemSolver
    {
        public override string Solve(object problem)
        {
            if (problem.ToString().ToLower() == "technic")
            {
                return "TechnicProblemSolver is able to solve this problem";
            }
            else
            {
                return base.Solve(problem);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MathProblemSolver mathProblemSolver = new MathProblemSolver();
            LinguisticProblemSolver linguisticProblemSolver = new LinguisticProblemSolver();
            TechnicProblemSolver technicProblemSolver = new TechnicProblemSolver();

            linguisticProblemSolver.SetNext(mathProblemSolver).SetNext(technicProblemSolver);

            List<string> problems = new List<string> { "linguist", "math", "technic" };

            foreach(string problem in problems)
            {
                Console.WriteLine(linguisticProblemSolver.Solve(problem));
            }
        }
    }
}
