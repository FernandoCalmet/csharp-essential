namespace solid_principles.srp.example_files;

public interface IEntryManager<T>
{
    void AddEntry(T entry);
    void RemoveEntryAt(int index);
}