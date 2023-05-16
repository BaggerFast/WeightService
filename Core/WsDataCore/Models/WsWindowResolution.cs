// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace WsDataCore.Models;

public class WsWindowResolution
{
	#region Public methods

	public ObservableCollection<string> GetItems() =>
        new()
        {
            "Максимальное",
            "800x600",
            "1024х768",
            "1366х768",
            "1920х1080"
        };

    #endregion
}