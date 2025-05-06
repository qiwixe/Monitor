using BlazorBootstrap;
using Microsoft.AspNetCore.Components;

namespace hybr.Shared.Services
{
    public class SharedFunction
    {
        // Переход по ссылке
        public static void GoToURL(NavigationManager _navManager, string _url) => _navManager.NavigateTo(_url, false);

    }
}
