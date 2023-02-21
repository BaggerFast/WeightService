# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [0.6.800] - 2022-06-03
### Описание обновления:
- WS-T-228. После закрытия ПЛУ возвращаться в раздел АРМ вместо раздела ПЛУ

## [0.6.790] - 2022-06-02
### Changed
- DataCore.Sql.TableScaleModels.ScaleEntity
- DataCore.Sql.TableScaleModels.ScaleMap
### Описание обновления:
- WS-T-220. Добавить поле счётчика в раздел и страницу АРМ
- WS-T-221. Возможность отвязать АРМ от цеха
- WS-T-222. Отвязать АРМ от цеха
- WS-T-224. Расчёт веса тары ПЛУ

## [0.6.780] - 2022-06-01
### Описание обновления:
- WS-T-215. Системная таблица версий

## [0.6.770] - 2022-05-31
### Описание обновления:
- WS-T-212. Раздел 'АРМы'
- WS-T-213. Замес для АРМ

## [0.6.760] - 2022-05-30
### Описание обновления:
- WS-T-207. Обновить раздел 'Шаблоны'

## [0.6.750] - 2022-05-27
### Описание обновления:
- WS-T-173. Пробросить номер устройства

## [0.6.740] - 2022-05-26
### Описание обновления:
- WS-T-190. Артефакт подсказки на кнопках

## [0.6.730] - 2022-05-25
### Fixed
- Item.ItemHost
### Описание обновления:
- WS-T-184. Исправление сохранения изменений хоста
- WS-T-185. Обновление NuGet пакетов
- WS-T-186. Уведомления операций
- WS-T-187. Устройства с пустыми полями

## [0.6.710] - 2022-05-23
### Fixed
- Section.Measurements.SectionLabels
### Описание обновления:
- Обновление раздела 'Этикетки'
- Исправление сортировки полей разделов справочников

## [0.6.690] - 2022-05-19
### Fixed
- Section.Measurements.SectionWeithingFacts
### Описание обновления:
- Обновление раздела и страница 'Взвешивания'
- Обновление раздела и страница 'Этикетки'
- Обновление раздела и страница 'Шаблоны и ресурсы'

## [0.6.640] - 2022-05-17
### Fixed
- SectionPLus
### Описание обновления:
- Обновлён раздел ПЛУ

## [0.6.610] - 2022-05-12
### Fixed
- SectionAccess
- SectionLabels
- SectionWeithingFactsAggregation
### Описание обновления:
- Обновлён раздел агр. взвешивания
- Обновлён раздел доступа пользователей
- Обновлён раздел этикеток

## [0.6.605] - 2022-05-11
### Fixed
- ItemLogs
- SectionLogs
### Описание обновления:
- Обновлены раздел и страница логов
- Обновлены раздел и страница хостов

## [0.6.580] - 2022-05-05
### Fixed
- Index
### Описание обновления:
- Главная страница: добавлена информация о системе пользователя

## [0.6.550] - 2022-04-27
### Fixed
- DataCore.Files.JsonSettingsEntity
- Section.Logs
### Описание обновления:
- Настройки приложения: параметр "Отображать первые х строк"
- Добавлен раздел: "Логи без типа"
- Добавлен раздел: "Логи инфо"
- Добавлен раздел: "Логи ошибок"
- Добавлен раздел: "Логи вопросов"
- Добавлен раздел: "Логи остановов"
- Добавлен раздел: "Логи предупреждений"
- Регистрация запуска веб-приложения
- Регистрация логов ошибок веб-приложения

## [0.6.520] - 2022-04-21
### Fixed
- Section.SectionScales
### Описание обновления:
- Раздел "АРМы": добавлено поле "Транспортные этикетки"
- Раздел "АРМы": добавлено поле "Транспортный принтер"
- Раздел "АРМы": исправлено поле "Основной принтер"
- Раздел "АРМы": исправлено поле "Хост"
- Раздел "Логи": добавлено поле "Версия приложения"

## [0.6.470] - 2022-04-13
### Fixed
- Item.Measurements.SectionLabels
- Item.Measurements.SectionWeithingFacts
- Item.Measurements.SectionWeithingFactsAggregation
- Section.Measurements.SectionLabels
- Section.Measurements.SectionWeithingFacts
- Section.Measurements.SectionWeithingFactsAggregation
### Описание обновления:
- Раздел и страница "Взвешивания"

## [0.6.450] - 2022-04-13
### Fixed
- ActionsReloadBase
- ActionsReloadItem
- ActionsReloadSection
### Описание обновления:
- Добавлена новая функция разделов: отображать первые 100 записей (включена по-умолчанию)

## [0.6.440] - 2022-04-12
### Fixed
- ItemPrinter
- ItemPrinterResource
- ItemPrinterType
- SectionPrintersResources
- SectionPrinters
- SectionPrinterTypes
### Описание обновления:
- Раздел и страница "АРМы"
- Раздел и страница "Принтеры"
- Раздел и страница "Ресурсы принтера"
- Страница "Принтер": добавил функции "Удалить ресурсы", "Загрузить шрифты", "Загрузить картинки"

## [0.6.420] - 2022-04-07
### Fixed
- MainLayout
- NavMenu
### Описание обновления:
- Новое меню слева

## [0.6.410] - 2022-04-06
### Fixed
- Item PLU page
- MainLayout
- NavMenu
### Описание обновления:
- Страница "ПЛУ": расположение полей
- Выравнивание элементов на галвной странице

## [0.6.400] - 2022-04-05
### Fixed
- Section and item Scale page
### Описание обновления:
- Раздел и страница "Устройства"

## [0.6.390] - 2022-04-01
### Fixed
- Item PLU page
- Item Template page
### Описание обновления:
- Cтраница "ПЛУ": исправлена связь поля "Устройство"
- Раздел и страница "Шаблоны": создание новой записи

## [0.6.370] - 2022-03-30
### Fixed
- Sections pages
- Items pages
### Описание обновления:
- Восстановлено ограничение доступа к приложению для неавторизованных пользователей.
- Права доступа можно редактировать из приложения.
- Добавлены прямые ссылки перехода из разделов в запись.
- Раздел и страница "Устройства": исправлены ошибки изменения и сохранения значений записи.
- Раздел и страница "Принтеры": добавлено поле статуса устройства (доступность по сети).

## [0.6.350] - 2022-03-24
### Fixed
- WS-T-107. DeviceControl. Access rights hotfix

## [0.6.330] - 2022-03-24
### Changed
- Index
- MainLayout

## [0.6.320] - 2022-03-22
### Changed
- Section.Access
- Section.Barcodes
- Section.BarcodeTypes
- Section.Contragents
- Item.Access
- Item.Barcodes
- Item.BarcodeTypes
- Item.Contragents

## [0.6.220] - 2022-02-22
### Changed
- Section.Nomenclatures
- Section.Plus
- Item.Nomenclature
- Item.Plu

## [0.6.210] - 2022-02-21
### Changed
- Section: _locker object
- Item: _locker object

## [0.6.200] - 2022-02-18
### Changed
- Item.Printer
- Item.Scale
- Section.Info

## [0.6.110] - 2022-02-02
### Changed
- Moved system sections and items componennts

## [0.6.080] - 2022-01-28
### Changed
- ActionsButtons
- ActionsFilter
- ActionsLoad
- ActionsReload
- ActionsSave
- RazorItemDates

## [0.6.050] - 2022-01-21
### Added
- WS-T-57. Info DB size

## [0.6.040] - 2022-01-19
### Fixed
- BlazorCore refactoring
### Added
- WS-T-67. Host section edit

## [0.5.930] - 2021-12-14
### Fixed
- MemoryEntity

## [0.5.910] - 2021-12-03
### Changed
- Fixed issues

## [0.5.880] - 2021-11-25
### Changed
- WS-T-32. BlazorDeviceControl. Refactoring

## [0.5.470] - 2021-09-01
### Changed
- Section.Printers

## [0.5.440] - 2021-08-23
### Changed
- BlazorCore.Utils.LocalizationStrings
- Item.Scale
- Sys.Info
- Sys.Logs
- Section.Scales
### Added
- Item.EntityActions
- Section.ActionsButtons

## [0.5.380] - 2021-08-13
### Changed
- Refactoring
- Docs.razor
- Memory optimization
### Added
- Language switch between English and Russian

## [0.2.320] - 2021-07-28
### Changed
- Razor pages

## [0.2.300] - 2021-07-27
### Changed
- Debug DB location

## [0.2.280] - 2021-07-20
### Added
- Authentication

## [0.2.270] - 2021-07-19
### Changed
- Scales section
- Logs section

## [0.2.260] - 2021-07-15
### Added
- Logs section

## [0.2.230] - 2021-07-13
### Changed
- WeithingFacts section
- Scales section
- Hosts section

## [0.2.220] - 2021-07-06
### Added
- WeithingFacts section

## [0.2.200] - 2021-05-25
### Added
- MemorySize control

## [0.2.190] - 2021-05-12
### Changed
- Plu record page

## [0.2.180] - 2021-05-11
### Changed
- Get free hosts
- Get busy hosts
### Added
- Exceptions logging
- drop index if exists [IDX_Scales_HostId] on [db_scales].[Scales]
