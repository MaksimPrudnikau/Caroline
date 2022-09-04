namespace Caroline.Models;

public enum SearchOptions
{
    English,
    Japan
}

public class SymbolViewModel
{
    public Symbol Symbol { get; set; }
    public SearchOptions? Option { get; set; }
}