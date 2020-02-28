namespace ChatWithSignalRAndWinServMVC.Web.Common.ViewModels
{
    public class GenericResponseView<T>
    {
        public T Model { get; set; }
        public string Error { get; set; }
    }
}
