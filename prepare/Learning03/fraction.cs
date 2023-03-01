class Fraction
{
    private int _numerator;
    private int _denominator;
    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    public Fraction(int numerator)
    {
        _numerator = numerator;
        _denominator = 1;
    }

    public Fraction(int numerator, int denominator)
    {
        _numerator = numerator;
        _denominator = denominator;
    }

    public int getNumerator()
    {
        return _numerator;
    }

    public int getDenominator()
    {
        return _denominator;
    }

    public void setNumerator(int numerator)
    {
        _numerator = numerator;
    }

    public void setDenominator(int denominator)
    {
        _denominator = denominator;
    }

    public string GetFractionString()
    {
        string stringified;

        stringified = _numerator.ToString() + "/" + _denominator.ToString();
        return stringified;
        //Console.WriteLine($"{getNumerator()}/{getDenominator()}");
    }

    public double GetDecimalValue()
    {
        double numerator = _numerator;
        double denominator = _denominator;
        double point = numerator / denominator;
        return point;
    }
}