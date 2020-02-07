using System.Threading.Tasks;

namespace RxWebDemo.Hubs
{
    public interface INotifyHub
    {
        Task SendUpdateUrl(int index, int size);
    }
}