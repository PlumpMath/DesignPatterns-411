using System;

namespace StructuralPatterns.RealWorldCodes
{
    interface ILanguage
    {
        void Build();
        void Execute();
    }

    class CppLanguage : ILanguage
    {
        public void Build()
        {
            Console.WriteLine("Using the C ++ compiler, the program is compiled into binary code");
        }

        public void Execute()
        {
            Console.WriteLine("Run the executable file of the program");
        }
    }

    class CSharpLanguage : ILanguage
    {
        public void Build()
        {
            Console.WriteLine("Using the Roslyn compiler, the source code is compiled into an exe file");
        }

        public void Execute()
        {
            Console.WriteLine("The JIT compiles a binary code");
            Console.WriteLine("The CLR executes the compiled binary code");
        }
    }

    abstract class Programmer
    {
        protected ILanguage language;
        public ILanguage Language
        {
            set { language = value; }
        }
        protected Programmer(ILanguage lang)
        {
            language = lang;
        }
        public virtual void DoWork()
        {
            language.Build();
            language.Execute();
        }
        public abstract void EarnMoney();
    }

    class FreelanceProgrammer : Programmer
    {
        public FreelanceProgrammer(ILanguage lang) : base(lang)
        {
        }
        public override void EarnMoney()
        {
            Console.WriteLine("You receive payment for the executed order");
        }
    }
    class CorporateProgrammer : Programmer
    {
        public CorporateProgrammer(ILanguage lang)
            : base(lang)
        {
        }
        public override void EarnMoney()
        {
            Console.WriteLine("You get a salary at the end of the month");
        }
    }
}