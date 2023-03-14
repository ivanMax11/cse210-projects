public class Word
{
    private string _word;
    private bool _visibility;

    public Word(string word, bool visibility)
    {
        _word = word;
        _visibility = visibility;
    }

    public string GetWord()
    {
        return _word;
    }

    public void SetWord(string word)
    {
        _word = word;
    }

    public string Underscore()
    {
        return new string('_', _word.Length);
    }

    public void Hide()
    {
        _visibility = false;
    }

    public void Show()
    {
        _visibility = true;
    }

    public bool IsVisible()
    {
        return _visibility;
    }
}