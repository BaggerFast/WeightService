// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace WsLocalizationCore.Models;

public sealed class WsLocaleTable : WsLocalizationBase
{
    #region Public and private fields, properties, constructor

    public string AccessLevel => Lang == WsEnumLanguage.English ? "Access level" : "Уровень доступа";
    public string Active => Lang == WsEnumLanguage.English ? "Active" : "Активно";
    public string ActiveShort => Lang == WsEnumLanguage.English ? "Act" : "Акт";
    public string Address => Lang == WsEnumLanguage.English ? "Address" : "Адрес";
    public string App => Lang == WsEnumLanguage.English ? "Program" : "Программа";
    public string Area => Lang == WsEnumLanguage.English ? "Area" : "Площадка";
    public string Arm => Lang == WsEnumLanguage.English ? "ARM" : "АРМ";
    public string BarcodeType => Lang == WsEnumLanguage.English ? "Barcode type" : "Тип штрихкода";
    public string BarCodeTypeId => Lang == WsEnumLanguage.English ? "Barcode type ID" : "ИД типа ШК";
    public string Box => Lang == WsEnumLanguage.English ? "Box" : "Коробка";
    public string BoxWeight => Lang == WsEnumLanguage.English ? "Box weight" : "Вес коробки";
    public string Brand => Lang == WsEnumLanguage.English ? "Brand" : "Бренд";
    public string Bundle => Lang == WsEnumLanguage.English ? "Bundle" : "Пакет";
    public string BundleCount => Lang == WsEnumLanguage.English ? "Bundle count" : "Кол-во пакетов";
    public string BundleFkWeightTare => Lang == WsEnumLanguage.English ? "Bundle tare weight" : "Вес тары упаковки";
    public string BundleFkWeightTareDescription => Lang == WsEnumLanguage.English ? "Tare weight = weight of package * count of inserts + weight of box" : "Вес тары = вес пакета * кол. вложений + вес коробки";
    public string BundleFkWeightTareKg => Lang == WsEnumLanguage.English ? "Tare weight, kg" : "Вес тары, кг";
    public string BundleFkWeightTareShort => Lang == WsEnumLanguage.English ? "Weight" : "Вес";
    public string BundleWeight => Lang == WsEnumLanguage.English ? "Bundle weight" : "Вес пакета";
    public string CategoryId => Lang == WsEnumLanguage.English ? "Category ID" : "ИД категории";
    public string CategoryName => Lang == WsEnumLanguage.English ? "Category" : "Категория";
    public string ChangeDt => Lang == WsEnumLanguage.English ? "Edited" : "Изменено";
    public string CheckGtin => Lang == WsEnumLanguage.English ? "GTIN" : "ГТИН";
    public string CheckWeight => Lang == WsEnumLanguage.English ? "Weighing products" : "Весовая продукция";
    public string Code => Lang == WsEnumLanguage.English ? "Code" : "Код";
    public string Comment => Lang == WsEnumLanguage.English ? "Comment" : "Комментарий";
    public string Consumer => Lang == WsEnumLanguage.English ? "Consumer" : "Потребитель";
    public string Contragent => Lang == WsEnumLanguage.English ? "Contragent" : "Контрагент";
    public string ContragentId => Lang == WsEnumLanguage.English ? "Contragent ID" : "ИД контрагента";
    public string Count => Lang == WsEnumLanguage.English ? "Count" : "Кол-во";
    public string Counter => Lang == WsEnumLanguage.English ? "Counter" : "Счётчик";
    public string CreateDt => Lang == WsEnumLanguage.English ? "Created" : "Создано";
    public string Date => Lang == WsEnumLanguage.English ? "Date" : "Дата";
    public string DayOfWeek => Lang == WsEnumLanguage.English ? "Weekday" : "День недели";
    public string Deactive => Lang == WsEnumLanguage.English ? "Deactivate" : "Деактивировано";
    public string DeactiveShort => Lang == WsEnumLanguage.English ? "Deact" : "Деакт";
    public string Description => Lang == WsEnumLanguage.English ? "Description" : "Описание";
    public string Device => Lang == WsEnumLanguage.English ? "Device" : "Устройство";
    public string DeviceComPort => Lang == WsEnumLanguage.English ? "COM-port" : "COM-порт";
    public string DeviceIp => Lang == WsEnumLanguage.English ? "IP-address" : "IP-адрес";
    public string DeviceMac => Lang == WsEnumLanguage.English ? "MAC-address" : "MAC-адрес";
    public string DeviceNumber => Lang == WsEnumLanguage.English ? "Device number" : "Номер устройства";
    public string DevicePort => Lang == WsEnumLanguage.English ? "Device port" : "Порт устройства";
    public string DeviceReceiveTimeout => Lang == WsEnumLanguage.English ? "Receive timeout" : "Таймаут приёма";
    public string DeviceSendTimeout => Lang == WsEnumLanguage.English ? "Send timeout" : "Таймаут отправки";
    public string DeviceType => Lang == WsEnumLanguage.English ? "Device type" : "Тип устройства";
    public string Ean13 => Lang == WsEnumLanguage.English ? "EAN13" : "ШК ЕАН13";
    public string Enabled => Lang == WsEnumLanguage.English ? "Enabled" : "Активно";
    public string Error => Lang == WsEnumLanguage.English ? "Failed" : "Неудачно";
    public string Exception => Lang == WsEnumLanguage.English ? "Exception" : "Исключение";
    public string ExpirationDt => Lang == WsEnumLanguage.English ? "Expiration date" : "Срок годности";
    public string FieldCategory => Lang == WsEnumLanguage.English ? "Category" : "Категория";
    public string FieldCount => Lang == WsEnumLanguage.English ? "Count" : "Количество";
    public string FieldCreated => Lang == WsEnumLanguage.English ? "Created" : "Создано";
    public string FieldDescription => Lang == WsEnumLanguage.English ? "Description" : "Описание";
    public string FieldEmpty => Lang == WsEnumLanguage.English ? "<Empty>" : "<Пусто>";
    public string FieldIdRRef => Lang == WsEnumLanguage.English ? "ID 1C" : "ИД 1С";
    public string FieldIpAddress => Lang == WsEnumLanguage.English ? "Ip-address" : "ИП-адрес";
    public string FieldIsEmpty => Lang == WsEnumLanguage.English ? "Empty field" : "Пустое поле";
    public string FieldIsNotInRange => Lang == WsEnumLanguage.English ? "Field is not in the range" : "Поле не находится в диапазоне";
    public string FieldLabel => Lang == WsEnumLanguage.English ? "Label" : "Этикетка";
    public string FieldModified => Lang == WsEnumLanguage.English ? "Modified" : "Изменено";
    public string FieldName => Lang == WsEnumLanguage.English ? "Name" : "Наименование";
    public string FieldNotFound => Lang == WsEnumLanguage.English ? "<Not found>" : "<Не найдено>";
    public string FieldPackageIsNotSelected => Lang == WsEnumLanguage.English ? "Nesting of the PLU is not selected" : "Вложенность ПЛУ не выбрана";
    public string FieldPackageMustBeSelected => Lang == WsEnumLanguage.English ? "Select the Nesting of the PLU" : "Выберите вложенность ПЛУ";
    public string FieldPluIsNotSelected => Lang == WsEnumLanguage.English ? "PLU is not selected!" : "ПЛУ не выбрана!";
    public string FieldPluMustBeSelected => Lang == WsEnumLanguage.English ? "Select the PLU" : "Выберите ПЛУ";
    public string FieldTitle => Lang == WsEnumLanguage.English ? "Title" : "Заголовок";
    public string FieldUser => Lang == WsEnumLanguage.English ? "User" : "Пользователь";
    public string File => Lang == WsEnumLanguage.English ? "File" : "Файл";
    public string FilePath => Lang == WsEnumLanguage.English ? "File path" : "Путь к файлу";
    public string FullName => Lang == WsEnumLanguage.English ? "Full name" : "Полное наименование";
    public string Gln => Lang == WsEnumLanguage.English ? "GLN" : "ГЛН";
    public string GoodsBruttoWeight => Lang == WsEnumLanguage.English ? "Gross weight" : "Вес брутто";
    public string GoodsBundleCount => Lang == WsEnumLanguage.English ? "Attaches" : "Вложений";
    public string GoodsBundleCountShort => Lang == WsEnumLanguage.English ? "Attach" : "Влож";
    public string GoodsDescription => Lang == WsEnumLanguage.English ? "Good description" : "Описание товара";
    public string GoodsName => Lang == WsEnumLanguage.English ? "Product" : "Товар";
    public string Group => Lang == WsEnumLanguage.English ? "Group" : "Группа";
    public string Gtin => Lang == WsEnumLanguage.English ? "BC GTIN" : "ШК ГТИН";
    public string GuidMercury => Lang == WsEnumLanguage.English ? "GUID Mercury" : "ГУИД Меркурий";
    public string Host => Lang == WsEnumLanguage.English ? "Host" : "Хост";
    public string HttpStatusCode => Lang == WsEnumLanguage.English ? "Status" : "Статус";
    public string HttpStatusException => Lang == WsEnumLanguage.English ? "Exception" : "Ошибка";
    public string HttpStatusNoException => Lang == WsEnumLanguage.English ? "No exceptions" : "Ошибок нет";
    public string Icon => Lang == WsEnumLanguage.English ? "Icon" : "Иконка";
    public string Id => Lang == WsEnumLanguage.English ? "ID" : "ИД";
    public string IdDwh => Lang == WsEnumLanguage.English ? "ID DWH" : "ИД ДВХ";
    public string Identity => Lang == WsEnumLanguage.English ? "Identity" : "Идентификатор";
    public string IdentityId => Lang == WsEnumLanguage.English ? "ID" : "ИД";
    public string IdentityUid => Lang == WsEnumLanguage.English ? "UID" : "УИД";
    public string IdRRef => Lang == WsEnumLanguage.English ? "ID 1C" : "ИД 1С";
    public string ImageData => Lang == WsEnumLanguage.English ? "Image data" : "Данные";
    public string ImageDataInfo => Lang == WsEnumLanguage.English ? "Info" : "Информация";
    public string ImportFrom1C => Lang == WsEnumLanguage.English ? "Import from 1C" : "Импорт из 1С";
    public string InnerException => Lang == WsEnumLanguage.English ? "Inner exception" : "Вложенное исключение";
    public string IsActive => Lang == WsEnumLanguage.English ? "Active" : "Активно";
    public string IsClose => Lang == WsEnumLanguage.English ? "Is close" : "Закрыто";
    public string IsDefault => Lang == WsEnumLanguage.English ? "Default" : "По-умолчанию";
    public string IsEnabled => Lang == WsEnumLanguage.English ? "Is enabled" : "Включено";
    public string IsKneading => Lang == WsEnumLanguage.English ? "Kneading" : "Замес";
    public string IsMarked => Lang == WsEnumLanguage.English ? "In the archive" : "В архиве";
    public string IsMarkedShort => Lang == WsEnumLanguage.English ? "x" : "х";
    public string IsOrder => Lang == WsEnumLanguage.English ? "Use order" : "Использовать заказ";
    public string IsShipping => Lang == WsEnumLanguage.English ? "Shipping labels" : "Транспортные этикетки";
    public string IsShippingLength => Lang == WsEnumLanguage.English ? "Count of labels in a box" : "Количество этикеток в коробе";
    public string IsShippingShort => Lang == WsEnumLanguage.English ? "Shipping" : "Трансп.";
    public string Itf14 => "ITF14";
    public string Label => Lang == WsEnumLanguage.English ? "Label" : "Этикетка";
    public string LabelCounter => Lang == WsEnumLanguage.English ? "Label counter" : "Счётчик этикеток";
    public string LabelTemplate => Lang == WsEnumLanguage.English ? "Label template" : "Шаблон этикетки";
    public string Level => Lang == WsEnumLanguage.English ? "Level" : "Уровень";
    public string Line => Lang == WsEnumLanguage.English ? "Line" : "Линия";
    public string Link => Lang == WsEnumLanguage.English ? "Link" : "Ссылка";
    public string LoginDt => Lang == WsEnumLanguage.English ? "Login" : "Залогирован";
    public string LogoutDt => Lang == WsEnumLanguage.English ? "Logout" : "Разлогирован";
    public string LogType => Lang == WsEnumLanguage.English ? "Log type" : "Тип лога";
    public string LowerWeightThreshold => Lang == WsEnumLanguage.English ? "Lower value of the box weight, kg" : "Нижнее значение веса короба, кг";
    public string MaxSize => Lang == WsEnumLanguage.English ? "Max Size mb" : "Макс.размер в мб";
    public string Member => Lang == WsEnumLanguage.English ? "Method" : "Метод";
    public string Message => Lang == WsEnumLanguage.English ? "Message" : "Сообщение";
    public string Name => Lang == WsEnumLanguage.English ? "Name" : "Наименование";
    public string NameFull => Lang == WsEnumLanguage.English ? "Full name" : "Полное наименование";
    public string NestingCount => Lang == WsEnumLanguage.English ? "Nesting count" : "Кол-во вложений";
    public string NestingMeasurement => Lang == WsEnumLanguage.English ? "pc" : "шт";
    public string Nomenclature => Lang == WsEnumLanguage.English ? "Nomenclature" : "Номенклатура";
    public string NomenclatureCode => Lang == WsEnumLanguage.English ? "Nomenclature code" : "Код номенклатуры";
    public string NomenclatureId => Lang == WsEnumLanguage.English ? "Nomenclature ID" : "ID номенклатуры";
    public string NomenclatureType => Lang == WsEnumLanguage.English ? "Type of nomenclature" : "Тип номенклатуры";
    public string NomenclatureUnitId => Lang == WsEnumLanguage.English ? "Nomenclature unit ID" : "ID юнита номенклатуры";
    public string Number => Lang == WsEnumLanguage.English ? "Number" : "Номер";
    public string NumberShort => Lang == WsEnumLanguage.English ? "#" : "№";
    public string Order => Lang == WsEnumLanguage.English ? "Order" : "Заказ";
    public string PackQuantly => Lang == WsEnumLanguage.English ? "Pack quantly" : "Быстрота упаковки";
    public string PackTypeId => Lang == WsEnumLanguage.English ? "Package type ID" : "ID типа упаковки";
    public string Parent => Lang == WsEnumLanguage.English ? "Parent" : "Родитель";
    public string ParentGroup => Lang == WsEnumLanguage.English ? "Parent group" : "Родительская группа";
    public string Percents => Lang == WsEnumLanguage.English ? "Percents" : "Проценты";
    public string Plu => Lang == WsEnumLanguage.English ? "PLU" : "ПЛУ";
    public string PluBundleFk => Lang == WsEnumLanguage.English ? "PLU's bundle" : "Пакет ПЛУ";
    public string PluDescription => Lang == WsEnumLanguage.English ? "Use the `|` symbol to move the line." : "Для переноса строки используйте символ `|`";
    public string PluId => Lang == WsEnumLanguage.English ? "ID PLU" : "ИД ПЛУ";
    public string PluNesting => Lang == WsEnumLanguage.English ? "PLU's nesting" : "Вложенность ПЛУ";
    public string PluNumber => Lang == WsEnumLanguage.English ? "# PLU" : "№ ПЛУ";
    public string PluPackage => Lang == WsEnumLanguage.English ? "PLU's package" : "Тара ПЛУ";
    public string PluScale => Lang == WsEnumLanguage.English ? "Device PLU" : "ПЛУ устройства";
    public string PluStorage => Lang == WsEnumLanguage.English ? "Storage PLU" : "Способ хранения ПЛУ";
    public string PrettyName => Lang == WsEnumLanguage.English ? "Pretty name" : "Красивое наименование";
    public string Printer => Lang == WsEnumLanguage.English ? "Printer" : "Принтер";
    public string PrinterResource => Lang == WsEnumLanguage.English ? "Printer resource" : "Ресурс принтера";
    public string PrinterType => Lang == WsEnumLanguage.English ? "Printer type" : "Тип принтера";
    public string Product => Lang == WsEnumLanguage.English ? "Product" : "Продукт";
    public string ProductDt => Lang == WsEnumLanguage.English ? "Product date" : "Дата продукции";
    public string ProductionFacility => Lang == WsEnumLanguage.English ? "Production facility" : "Производственная площадка";
    public string ProductSeries => Lang == WsEnumLanguage.English ? "Product series" : "Серия продукта";
    public string RegNum => Lang == WsEnumLanguage.English ? "# reg" : "№ регистрации";
    public string ReleaseDt => Lang == WsEnumLanguage.English ? "Release date" : "Дата релиза";
    public string Request => Lang == WsEnumLanguage.English ? "Request" : "Запрос";
    public string RequestUrl => Lang == WsEnumLanguage.English ? "Request url" : "Url запроса";
    public string Resource => Lang == WsEnumLanguage.English ? "Resource" : "Ресурс";
    public string Response => Lang == WsEnumLanguage.English ? "Response" : "Ответ";
    public string Row => Lang == WsEnumLanguage.English ? "Row" : "Строка";
    public string RowCount => Lang == WsEnumLanguage.English ? "Row count" : "Кол-во записей";
    public string ScaleFactor => Lang == WsEnumLanguage.English ? "Scale factor" : "Коэф. масштабирования";
    public string ScaleId => Lang == WsEnumLanguage.English ? "Scale ID" : "ID весов";
    public string Schema => Lang == WsEnumLanguage.English ? "Schema" : "Схема";
    public string ScreenShot => Lang == WsEnumLanguage.English ? "Screenshot" : "Скриншот";
    public string ShelfLifeDays => Lang == WsEnumLanguage.English ? "Shelf life, days" : "Срок годности, суток";
    public string ShelfLifeDaysShort => Lang == WsEnumLanguage.English ? "Life" : "Срок";
    public string Size => Lang == WsEnumLanguage.English ? "Size mb" : "Размер в мб";
    public string Sscc => Lang == WsEnumLanguage.English ? "Transport packing code (SSCC)" : "Код транспортной упаковки (SSCC)";
    public string State => Lang == WsEnumLanguage.English ? "Status" : "Статус";
    public string Status => Lang == WsEnumLanguage.English ? "Status" : "Статус";
    public string Storage => Lang == WsEnumLanguage.English ? "Storage" : "Склад";
    public string Success => Lang == WsEnumLanguage.English ? "Success" : "Успешно";
    public string Table => Lang == WsEnumLanguage.English ? "Table" : "Таблица";
    public string TableCalc => Lang == WsEnumLanguage.English ? "Calculate" : "Рассчитать";
    public string TableCancel => Lang == WsEnumLanguage.English ? "Close record" : "Закрыть запись";
    public string TableClear => Lang == WsEnumLanguage.English ? "Deactivate active record" : "Деактивировать активную запись";
    public string TableCopy => Lang == WsEnumLanguage.English ? "Cope record" : "Копировать запись";
    public string TableCount => Lang == WsEnumLanguage.English ? "Table count" : "Кол-во таблиц";
    public string TableCreate => Lang == WsEnumLanguage.English ? "Create record" : "Создать запись";
    public string TableDelete => Lang == WsEnumLanguage.English ? "Delete record" : "Удалить запись";
    public string TableEdit => Lang == WsEnumLanguage.English ? "Edit record" : "Редактировать запись";
    public string TableIncludes => Lang == WsEnumLanguage.English ? "Included records" : "Вложенные записи";
    public string TableMark => Lang == WsEnumLanguage.English ? "Mark record" : "Пометить запись на удаление";
    public string TableNew => Lang == WsEnumLanguage.English ? "New record" : "Новая запись";
    public string TablePluHavingPlu => Lang == WsEnumLanguage.English ? "The PLU table already has this number" : "Таблица PLU уже имеет такой номер";
    public string TableRead => Lang == WsEnumLanguage.English ? "Read data" : "Прочитать данные";
    public string TableReadCancel => Lang == WsEnumLanguage.English ? "Cancel data reading" : "Отмена чтения данных";
    public string TableRereadFromDb => Lang == WsEnumLanguage.English ? "Reread from the database" : "Перечитать из БД";
    public string TableSave => Lang == WsEnumLanguage.English ? "Save record" : "Сохранить запись";
    public string TableSelect => Lang == WsEnumLanguage.English ? "Highlight record" : "Выделить запись";
    public string TableTab => Lang == WsEnumLanguage.English ? "Switch between panels" : "Переключиться между панелями";
    public string TaskModule => Lang == WsEnumLanguage.English ? "Task module" : "Модуль задачи";
    public string TaskModuleType => Lang == WsEnumLanguage.English ? "Task module type" : "Тип модуля задачи";
    public string TaskType => Lang == WsEnumLanguage.English ? "Task type" : "Тип задачи";
    public string Template => Lang == WsEnumLanguage.English ? "Template" : "Шаблон";
    public string TemplateDefault => Lang == WsEnumLanguage.English ? "Default template" : "Шаблон по-умолчанию";
    public string TemplateId => Lang == WsEnumLanguage.English ? "Template ID" : "ID шаблона";
    public string TemplateIdDefault => Lang == WsEnumLanguage.English ? "Default template ID" : "ID шаблона по-умолчанию";
    public string TemplateIdSeries => Lang == WsEnumLanguage.English ? "Series ID" : "ID серии";
    public string TemplateLabelary => Lang == WsEnumLanguage.English ? "Web-site Labelary" : "Веб-сайт Labelary";
    public string TemplateResource => Lang == WsEnumLanguage.English ? "Template resource" : "Ресурс шаблона";
    public string TemplateSeries => Lang == WsEnumLanguage.English ? "Summary label template" : "Шаблон суммарной этикетки";
    public string TempMaximal => Lang == WsEnumLanguage.English ? "Maximal weight" : "Максимальная температура";
    public string TempMinimal => Lang == WsEnumLanguage.English ? "Minimal temperature" : "Минимальная температура";
    public string Title => Lang == WsEnumLanguage.English ? "Title" : "Заголовок";
    public string Type => Lang == WsEnumLanguage.English ? "Type" : "Тип";
    public string TypeBottom => Lang == WsEnumLanguage.English ? "Bottom's type" : "Нижний тип";
    public string TypeRight => Lang == WsEnumLanguage.English ? "Right's type" : "Правый тип";
    public string TypeTop => Lang == WsEnumLanguage.English ? "Top's type" : "Верхний тип";
    public string Uid => Lang == WsEnumLanguage.English ? "UID" : "УИД";
    public string Uid1c => Lang == WsEnumLanguage.English ? "UID 1C" : "УИД 1C";
    public string UpperWeightThreshold => Lang == WsEnumLanguage.English ? "Upper value of the box weight, kg" : "Верхнее значение веса короба, кг";
    public string User => Lang == WsEnumLanguage.English ? "User" : "Пользователь";
    public string Value => Lang == WsEnumLanguage.English ? "Value" : "Значение";
    public string ValueBottom => Lang == WsEnumLanguage.English ? "Bottom's value" : "Нижнее значение";
    public string ValueRight => Lang == WsEnumLanguage.English ? "Right's value" : "Правое значение";
    public string ValueTop => Lang == WsEnumLanguage.English ? "Top's value" : "Верхнее значение";
    public string VatRate => Lang == WsEnumLanguage.English ? "VAT rate" : "Ставка НДС";
    public string Version => Lang == WsEnumLanguage.English ? "Version" : "Версия";
    public string WebServiceExchange => Lang == WsEnumLanguage.English ? "Exchange between 1C and web service" : "Обмен между 1С и веб-сервисом";
    public string WeighDt => Lang == WsEnumLanguage.English ? "Weighing date" : "Дата взвешивания";
    public string Weighing => Lang == WsEnumLanguage.English ? "Weighing" : "Взвешивание";
    public string Weight => Lang == WsEnumLanguage.English ? "Weight" : "Вес";
    public string Weighted => Lang == WsEnumLanguage.English ? "Weighted" : "Весовая";
    public string WeightMaximal => Lang == WsEnumLanguage.English ? "Maximal weight" : "Максимальный вес";
    public string WeightMinimal => Lang == WsEnumLanguage.English ? "Minimal weight" : "Минимальный вес";
    public string WeightNetto => Lang == WsEnumLanguage.English ? "Net weight" : "Вес нетто";
    public string WeightNominal => Lang == WsEnumLanguage.English ? "Nominal weight" : "Номинальный вес";
    public string WeightShort => Lang == WsEnumLanguage.English ? "Weight" : "Вес";
    public string WeightTare => Lang == WsEnumLanguage.English ? "Tare weight" : "Вес тары";
    public string WorkShop => Lang == WsEnumLanguage.English ? "Workshop" : "Цех";
    public string WorkShopId => Lang == WsEnumLanguage.English ? "Workshop ID" : "ИД цеха";
    public string WorkShopName => Lang == WsEnumLanguage.English ? "Workshop" : "Цех";
    public string Xml => Lang == WsEnumLanguage.English ? "XML" : "Поле XML";
    public string XmlPretty => Lang == WsEnumLanguage.English ? "Pretty XML" : "Красивый XML";
    public string Zpl => Lang == WsEnumLanguage.English ? "ZPL" : "ЗПЛ";
    public string СurrentMemory => Lang == WsEnumLanguage.English ? "Current ram mb" : "Текущая озу мб";
    public string MaxMemory => Lang == WsEnumLanguage.English ? "Максимальная ram mb" : "Максимальная озу мб";
    
    #endregion
}