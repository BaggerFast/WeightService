namespace WsLocalizationCore.Models;

public sealed class LocaleTable : LocalizationBase
{
    #region Public and private fields, properties, constructor

    public string AccessLevel => Lang == EnumLanguage.English ? "Access level" : "Уровень доступа";
    public string Address => Lang == EnumLanguage.English ? "Address" : "Адрес";
    public string App => Lang == EnumLanguage.English ? "Program" : "Программа";
    public string Area => Lang == EnumLanguage.English ? "Area" : "Площадка";
    public string Box => Lang == EnumLanguage.English ? "Box" : "Коробка";
    public string BoxWeight => Lang == EnumLanguage.English ? "Box weight" : "Вес коробки";
    public string Brand => Lang == EnumLanguage.English ? "Brand" : "Бренд";
    public string Bundle => Lang == EnumLanguage.English ? "Bundle" : "Пакет";
    public string BundleFkWeightTare => Lang == EnumLanguage.English ? "Bundle tare weight" : "Вес тары упаковки";
    public string BundleWeight => Lang == EnumLanguage.English ? "Bundle weight" : "Вес пакета";
    public string CategoryName => Lang == EnumLanguage.English ? "Category" : "Категория";
    public string ChangeDt => Lang == EnumLanguage.English ? "Edited" : "Изменено";
    public string CheckWeight => Lang == EnumLanguage.English ? "Weighing products" : "Весовая продукция";
    public string Code => Lang == EnumLanguage.English ? "Code" : "Код";
    public string Count => Lang == EnumLanguage.English ? "Count" : "Кол-во";
    public string Counter => Lang == EnumLanguage.English ? "Counter" : "Счётчик";
    public string CreateDt => Lang == EnumLanguage.English ? "Created" : "Создано";
    public string DayOfWeek => Lang == EnumLanguage.English ? "Weekday" : "День недели";
    public string Description => Lang == EnumLanguage.English ? "Description" : "Описание";
    public string Device => Lang == EnumLanguage.English ? "Device" : "Устройство";
    public string Devices => Lang == EnumLanguage.English ? "Devices" : "Устройства";
    public string Setting => Lang == EnumLanguage.English ? "Setting" : "Настройка";
    public string DeviceComPort => Lang == EnumLanguage.English ? "COM-port" : "COM-порт";
    public string DeviceIp => Lang == EnumLanguage.English ? "IP-address" : "IP-адрес";
    public string DeviceMac => Lang == EnumLanguage.English ? "MAC-address" : "MAC-адрес";
    public string DeviceNumber => Lang == EnumLanguage.English ? "Device number" : "Номер устройства";
    public string DeviceType => Lang == EnumLanguage.English ? "Device type" : "Тип устройства";
    public string Ean13 => Lang == EnumLanguage.English ? "EAN13" : "ШК ЕАН13";
    public string Error => Lang == EnumLanguage.English ? "Failed" : "Неудачно";
    public string ExpirationDt => Lang == EnumLanguage.English ? "Expiration date" : "Срок годности";
    public string FieldEmpty => Lang == EnumLanguage.English ? "<Empty>" : "<Пусто>";
    public string FieldPluIsNotSelected => Lang == EnumLanguage.English ? "PLU is not selected!" : "ПЛУ не выбрана!";
    public string File => Lang == EnumLanguage.English ? "File" : "Файл";
    public string FullName => Lang == EnumLanguage.English ? "Full name" : "Полное наименование";
    public string Gln => Lang == EnumLanguage.English ? "GLN" : "ГЛН";
    public string Gtin => Lang == EnumLanguage.English ? "BC GTIN" : "ШК ГТИН";
    public string Host => Lang == EnumLanguage.English ? "Host" : "Хост";
    public string Id => Lang == EnumLanguage.English ? "ID" : "ИД";
    public string ImageData => Lang == EnumLanguage.English ? "Image data" : "Данные";
    public string IsDefault => Lang == EnumLanguage.English ? "Default" : "По-умолчанию";
    public string IsEnabled => Lang == EnumLanguage.English ? "Is enabled" : "Включено";
    public string IsKneading => Lang == EnumLanguage.English ? "Kneading" : "Замес";
    public string IsMarked => Lang == EnumLanguage.English ? "In the archive" : "В архиве";
    public string IsMarkedShort => Lang == EnumLanguage.English ? "x" : "х";
    public string Itf14 => "ITF14";
    public string Label => Lang == EnumLanguage.English ? "Label" : "Этикетка";
    public string LabelCounter => Lang == EnumLanguage.English ? "Label counter" : "Счётчик этикеток";
    public string Line => Lang == EnumLanguage.English ? "Line" : "Линия";
    public string LoginDt => Lang == EnumLanguage.English ? "Login" : "Залогирован";
    public string LogoutDt => Lang == EnumLanguage.English ? "Logout" : "Разлогирован";
    public string LogType => Lang == EnumLanguage.English ? "Log type" : "Тип лога";
    public string Member => Lang == EnumLanguage.English ? "Method" : "Метод";
    public string Message => Lang == EnumLanguage.English ? "Message" : "Сообщение";
    public string Name => Lang == EnumLanguage.English ? "Name" : "Наименование";
    public string NestingCount => Lang == EnumLanguage.English ? "Nesting count" : "Кол-во вложений";
    public string NestingMeasurement => Lang == EnumLanguage.English ? "pc" : "шт";
    public string NomenclatureCode => Lang == EnumLanguage.English ? "Nomenclature code" : "Код номенклатуры";
    public string Number => Lang == EnumLanguage.English ? "Number" : "Номер";
    public string NumberShort => Lang == EnumLanguage.English ? "#" : "№";
    public string Percents => Lang == EnumLanguage.English ? "Percents" : "Проценты";
    public string Plu => Lang == EnumLanguage.English ? "PLU" : "ПЛУ";
    public string PluBundleFk => Lang == EnumLanguage.English ? "PLU's bundle" : "Пакет ПЛУ";
    public string PluNesting => Lang == EnumLanguage.English ? "PLU's nesting" : "Вложенность ПЛУ";
    public string PluNumber => Lang == EnumLanguage.English ? "# PLU" : "№ ПЛУ";
    public string PluStorage => Lang == EnumLanguage.English ? "Storage PLU" : "Способ хранения ПЛУ";
    public string PrettyName => Lang == EnumLanguage.English ? "Pretty name" : "Красивое наименование";
    public string Printer => Lang == EnumLanguage.English ? "Printer" : "Принтер";
    public string ProductDt => Lang == EnumLanguage.English ? "Product date" : "Дата продукции";
    public string ProductionFacility => Lang == EnumLanguage.English ? "Production facility" : "Производственная площадка";
    public string ReleaseDt => Lang == EnumLanguage.English ? "Release date" : "Дата релиза";
    public string Request => Lang == EnumLanguage.English ? "Request" : "Запрос";
    public string RequestUrl => Lang == EnumLanguage.English ? "Request url" : "Url запроса";
    public string Response => Lang == EnumLanguage.English ? "Response" : "Ответ";
    public string Row => Lang == EnumLanguage.English ? "Row" : "Строка";
    public string RowCount => Lang == EnumLanguage.English ? "Row count" : "Кол-во записей";
    public string Schema => Lang == EnumLanguage.English ? "Schema" : "Схема";
    public string ShelfLifeDays => Lang == EnumLanguage.English ? "Shelf life, days" : "Срок годности, суток";
    public string ShelfLifeDaysShort => Lang == EnumLanguage.English ? "Life" : "Срок";
    public string Size => Lang == EnumLanguage.English ? "Size mb" : "Размер в мб";
    public string Success => Lang == EnumLanguage.English ? "Success" : "Успешно";
    public string Table => Lang == EnumLanguage.English ? "Table" : "Таблица";
    public string TableCount => Lang == EnumLanguage.English ? "Table count" : "Кол-во таблиц";
    public string TableDelete => Lang == EnumLanguage.English ? "Delete record" : "Удалить запись";
    public string TableMark => Lang == EnumLanguage.English ? "Mark record" : "Пометить запись на удаление";
    public string TableNew => Lang == EnumLanguage.English ? "New record" : "Новая запись";
    public string TableSave => Lang == EnumLanguage.English ? "Save record" : "Сохранить запись";
    public string Template => Lang == EnumLanguage.English ? "Template" : "Шаблон";
    public string TemplateLabelary => Lang == EnumLanguage.English ? "Web-site Labelary" : "Веб-сайт Labelary";
    public string TempMaximal => Lang == EnumLanguage.English ? "Maximal weight" : "Максимальная температура";
    public string TempMinimal => Lang == EnumLanguage.English ? "Minimal temperature" : "Минимальная температура";
    public string Title => Lang == EnumLanguage.English ? "Title" : "Заголовок";
    public string Type => Lang == EnumLanguage.English ? "Type" : "Тип";
    public string TypeBottom => Lang == EnumLanguage.English ? "Bottom's type" : "Нижний тип";
    public string TypeRight => Lang == EnumLanguage.English ? "Right's type" : "Правый тип";
    public string TypeTop => Lang == EnumLanguage.English ? "Top's type" : "Верхний тип";
    public string Uid => Lang == EnumLanguage.English ? "UID" : "УИД";
    public string Uid1c => Lang == EnumLanguage.English ? "UID 1C" : "УИД 1C";
    public string User => Lang == EnumLanguage.English ? "User" : "Пользователь";
    public string ValueBottom => Lang == EnumLanguage.English ? "Bottom's value" : "Нижнее значение";
    public string ValueRight => Lang == EnumLanguage.English ? "Right's value" : "Правое значение";
    public string ValueTop => Lang == EnumLanguage.English ? "Top's value" : "Верхнее значение";
    public string Version => Lang == EnumLanguage.English ? "Version" : "Версия";
    public string Weighing => Lang == EnumLanguage.English ? "Weighing" : "Взвешивание";
    public string Weight => Lang == EnumLanguage.English ? "Weight" : "Вес";
    public string Weighted => Lang == EnumLanguage.English ? "Weighted" : "Весовая";
    public string WeightMaximal => Lang == EnumLanguage.English ? "Maximal weight" : "Максимальный вес";
    public string WeightMinimal => Lang == EnumLanguage.English ? "Minimal weight" : "Минимальный вес";
    public string WeightNetto => Lang == EnumLanguage.English ? "Net weight" : "Вес нетто";
    public string WeightNominal => Lang == EnumLanguage.English ? "Nominal weight" : "Номинальный вес";
    public string WeightShort => Lang == EnumLanguage.English ? "Weight" : "Вес";
    public string WeightTare => Lang == EnumLanguage.English ? "Tare weight" : "Вес тары";
    public string WorkShop => Lang == EnumLanguage.English ? "Workshop" : "Цех";
    public string WorkShopName => Lang == EnumLanguage.English ? "Workshop" : "Цех";
    public string WithoutWeightCount => Lang == EnumLanguage.English ? "Count" : "Кол-во шт";
    public string WeightCount => Lang == EnumLanguage.English ? "Count" : "Кол-во вес";
    public string DownloadUrl => "Каталог установки";
    
    #endregion
}