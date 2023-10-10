namespace _6
{
    // ______________ Пользовательские исключения ______________
    public partial class PriceTooSmallException : Exception
    {
        public PriceTooSmallException(string productName) : base("product price soo small") 
        {
            Console.WriteLine($"  -{productName} price soo small");
        }
    }
    public partial class UndefinedNameException : Exception
    {
        public UndefinedNameException() : base("product name is empty") 
        {
            Console.WriteLine($"  -name is empty");
        }
    }
    public partial class MyDivideByZeroException : Exception
    {
        public MyDivideByZeroException() : base("Возникло исключение DivideByZeroException") 
        {
            Console.WriteLine($"  -divide by zero");
        }
    }

}