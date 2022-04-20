using Delegates;

    Calculator calculator = new Calculator();

    Console.WriteLine("Введите выражение");
    string expression = Console.ReadLine();
    char sign = ' ';        // Знак
    foreach (char item in expression)
{
    if (item == '+' || item == '-' || item == '*' || item == '/')
    {
        sign = item;
        break;
    }
}

try
{
    string[] numbers = expression.Split(sign);
    CalcDelegate del = null;
    switch (sign)
    {
        case '+': 
            del = new CalcDelegate(calculator.Add);
            break;
        case '-':
            del = new CalcDelegate(calculator.Sub);
            break;
        case '*':
            del = calculator.Mult;
            break;
        case '/':
            del = calculator.Div;
            break;
        default:
            throw new InvalidOperationException();
    }
    Console.WriteLine($"Result:{del(double.Parse(numbers[0]),double.Parse(numbers[1]))}");
    CalcDelegate delAll = null;    //Делегает для всех
    CalcDelegate dellDiv = calculator.Div;
    delAll += dellDiv;
    delAll -= dellDiv;
    delAll += calculator.Mult;
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString);
}