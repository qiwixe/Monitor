namespace hybr.Shared.Services
{
        public class MainClass()
        {
            public required string Title { get; set; }
            public required string ShortTitle { get; set; }
            public required string FullTitle { get; set; }
            public required string Href { get; set; }
            public required List<int> SensorsId { get; set; }
        }
        public class ValueSettings()
        {
            public static readonly Dictionary<int, MainClass> Stations = new Dictionary<int, MainClass>
            {
                [1] = new MainClass
                {
                    Title = "Ветроэнергетическая установка",
                    ShortTitle = "ВУЭ",
                    FullTitle = "Установка №1, Ветроэнергетическая установка",
                    Href = "WindPower",
                    SensorsId = [1,2,3,4,5,6,7,8,9,10,11,12]
                },
                [2] = new MainClass
                {
                    Title = "Фотоэнергетическая установка",
                    ShortTitle = "ФУЭ",
                    FullTitle = "Установка №2, Фотоэнергетическая установка",
                    Href = "Photovoltaic",
                    SensorsId = [21,22,23,24,25,26,27,28,29,30,31,32,33]
                },
                [3] = new MainClass
                {
                    Title = "Солнечный коллектор",
                    ShortTitle = "Коллектор",
                    FullTitle = "Установка №3, Солнечный коллектор",
                    Href = "SolarCollector",
                    SensorsId = [21,22,23,24,25,26,27,28,29,30,31,32,33]
                },
                [4] = new MainClass
                {
                    Title = "Солнечный концентратор",
                    ShortTitle = "Концентратор",
                    FullTitle = "Установка №4, Солнечный концентратор",
                    Href = "SolarСoncentrator",
                    SensorsId = [41,42,43,44,45,46,47]
                },
                [5] = new MainClass
                {
                    Title = "Тепловой насос",
                    ShortTitle = "Тепловой насос",
                    FullTitle = "Установка №5, Тепловой насос",
                    Href = "HeatPump",
                    SensorsId = []
                },
                [6] = new MainClass
                {
                    Title = "Биоустановка",
                    ShortTitle = "Биоустановка",
                    FullTitle = "Установка №6, Биоустановка",
                    Href = "Bioplant",
                    SensorsId = []
                },
                [7] = new MainClass
                {
                    Title = "Метеостанция",
                    ShortTitle = "Метеостанция",
                    FullTitle = "Установка №7, Метеостанция",
                    Href = "Meteorological",
                    SensorsId = [103,104,105,106,107,108]
                }
            };
        }
}