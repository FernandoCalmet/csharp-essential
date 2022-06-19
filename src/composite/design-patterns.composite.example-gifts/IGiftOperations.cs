namespace design_patterns.composite.example_gifts;

public interface IGiftOperations
{
    void Add(GiftBase gift);
    void Remove(GiftBase gift);
}