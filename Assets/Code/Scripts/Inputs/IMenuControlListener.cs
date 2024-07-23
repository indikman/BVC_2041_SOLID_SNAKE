namespace Code.Scripts.Inputs
{
    public interface IMenuControlListener
    {
        void Open();
        void Closer();
        void ScrollMenu();
        void SelectItem();
    }
}