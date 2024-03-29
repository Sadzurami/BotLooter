## Описание

Софт позволяет передать предметы от нескольких Steam аккаунтов на один.
Кратко - Лутать ботов.

## Функционал

- Лутание любых инвентарей, например стим, кс, дота, тф2 и т.д.
- Многопоточное или однопоточного лутание.
- Использование прокси.

## Конфиг

BotLooter.Config.json

```json
{
 "LootThreadCount": 1,
 "ProxiesFilePath": "proxies.txt",

 "AskForApproval": true,
 "ExitOnFinish": false,

 "LootTradeOfferUrl": "",

 "AccountsFilePath": "",
 "IgnoreAccountsFilePath": "",
 "SecretsDirectoryPath": "",
 "SteamSessionsDirectoryPath": "",

 "SuccessfulLootsExportFilePath": "",

 "DelayBetweenAccountsSeconds": 30,
 "DelayInventoryEmptySeconds": 10,

 "Inventories": ["440/2", "753/6", "730/2"],

 "MaxItemsPerTrade": 5000,
 "MaxItemsPerAllTrades": 100000,

 "IgnoreMarketable": false,
 "IgnoreNotMarketable": false,

 "LootOnlyItemsWithNames": ["Mann Co. Supply Crate Key"],
 "IgnoreItemsWithNames": ["The Frying Pan"],

 "LootOnlyItemsWithAppIds": [351940],
 "IgnoreItemsWithAppIds": [12345],

 "LootOnlyItemsWithTags": ["Trading Card", "Booster Pack"],
 "IgnoreItemsWithTags": ["Profile Background"]
}
```

---

### `"LootTradeOfferUrl"`

Cсылка на трейд оффер, на который будут отправляться предметы.
\
Для работы необходимо скопировать полную актуальную ссылку. Пример.

- `"https://steamcommunity.com/tradeoffer/new/?partner=9639579492&token=2ix22Ruv2"`

---

### `"SecretsDirectoryPath"`

Путь к папке с МаФайлами.

---

### `"AccountsFilePath"`

Путь к файлу с аккаунтами формата login:password

---

### `"SteamSessionsDirectoryPath"`

Путь к папке с файлами .steamsession.
\
Так же можно часть аккаунтов загружать из МаФайлов, а часть из .steamsession файлов.
\
Создать такие файлы можно с помощью <https://github.com/Sadzurami/steam-sessions-creator>

---

### `"IgnoreAccountsFilePath"`

Путь к папке с логинами, которые будут игнорироваться при загрузке аккаунтов.

- При значении `""` файл не используется
- Если указать одинаковое значение для этого параметра и `"SuccessfulLootsExportFilePath"` - это поможет избежать повторного лутания одних и тех же аккаунтов.

---

### `"ProxiesFilePath"`

Путь к файлу с прокси. Пример.

- `"http://username:password@192.168.1.80:25565"`
- `"http://192.168.1.80:8080"`

---

### `"SuccessfulLootsExportFilePath"`

Путь к файлу, в который будут записываться логины ботов, которые были успешно залутаны.

- При значении `""` файл не используется

---

### `"DelayBetweenAccountsSeconds"`

Задержка при успешном и ошибочном лутаниях.
\
Указывается в секундах.

---

### `"DelayInventoryEmptySeconds"`

Задержка при пустом инвентаре.
\
Указывается в секундах.

---

### `"AskForApproval"`

- `true` - Будет требоваться подтверждение нажатием любой клавиши.
- `false` - 5 секундное ожидание без подтверждения начала работы.

---

### `"ExitOnFinish"`

- `true` - Программа сама закроется через 5 секунд после завершения работы.
- `false` - Программа будет ждать нажатия `ctrl + c` для закрытия.

---

### `"LootThreadCount"`

Максимальное количество потоков для лутания.
\
Не может быть больше количества прокси.
\
Без прокси может быть только `1`

---

### `"Inventories"`

Список инвентарей для лутания. Можно указывать один или несколько.
\
Формат `"appId/contextId"`

Некоторые известные инвентари:

- `"730/2"` - CS:GO
- `"753/6"` - Steam Community
- `"440/2"` - TF2

Пример, который будет лутать все 3 вышеперчисленные инвентаря.

```json
"Inventories": [
  "730/2",
  "753/6",
  "440/2"
]
```

---

### `"MaxItemsPerTrade"`

Максимальное количество предметов, которые нужно передать за один раз.

---

### `"MaxItemsPerAllTrades"`

Максимальное количество предметов, которые нужно передать за все время работы приложения.
По достижению этого значения приложение завершит работу.

Если вы работаете в несколько потоков, рекомендуется указывать значение немного меньше, чем предметов вам необходимо,
так как нету гарантии, что все потоки завершат работу одновременно и предметы будут подсчитаны верно.

---

### `"IgnoreNotMarketable"`

- `true` - Предметы, которые невозможно продать будут игнорироваться.
- `false` - Значение по умолчанию.

---

### `"IgnoreMarketable"`

- `true` - Предметы, которые возможно продать будут игнорироваться.
- `false` - Значение по умолчанию.

---

### `"LootOnlyItemsWithNames"`

Список предметов, которые будут лутаться, отфильтрованные по имени.
Если список пустой, то будут лутаться все предметы.

Пример, который будет лутать только TF2 ключи и билеты.

```json
"LootOnlyItemsWithNames": [
    "Mann Co. Supply Crate Key",
    "Tour of Duty Ticket",
]
```

---

### `"IgnoreItemsWithNames"`

Список предметов, которые будут игнорироваться, отфильтрованные по имени.

Пример, который будет игнорировать только сковородки.

```json
"IgnoreItemsWithNames": [
    "The Frying Pan"
]
```

---

### `"LootOnlyItemsWithAppIds"`

**Применяется только к инвентарям Steam Community (`753/6`)**

Список предметов, которые будут лутаться, отфильтрованные по appId.

Пример, который будет лутать только предметы из игры The Descendant.

```json
"LootOnlyItemsWithAppIds": [
    351940
]
```

---

### `"IgnoreItemsWithAppIds"`

**Применяется только к инвентарям Steam Community (`753/6`)**

Список предметов, которые будут игнорироваться, отфильтрованные по appId.

Пример, который будет игнорировать предметы из игры The Descendant.

```json
"IgnoreItemsWithAppIds": [
    351940
]
```

---

### `"LootOnlyItemsWithTags"`

Список предметов, которые будут лутаться, отфильтрованные по тегу.

Пример, который будет лутать только карточки, бустеры и гемы.

```json
"LootOnlyItemsWithTags": [
    "Trading Card",
    "Booster Pack",
    "Gems"
]
```

---

### `"IgnoreItemsWithTags"`

Список предметов, которые будут игнорироваться, отфильтрованные по тегу.

Пример, который будет игнорировать фоны профиля.

```json

"IgnoreItemsWithTags": [
    "Profile Background"
]
```

---

## Коммандная строка

### `--config-file-path (-c)`

Указывает путь к конфигу, если требуется использовать не стандартный путь.

Пример:

- `BotLooter.exe -c "C:/Users/BestUser/Desktop/BotLooter.Config.json"`
- `BotLooter.exe --config-file-path "C:/Users/BestUser/Desktop/BotLooter.Config.json"`

---

## Замечания

Особенности работы, подсказки и ответы на некоторые вопросы.

### Пути

Пути в конфиге можно указать как локальные, так и полные.
\
В случае написания с бекслешем необходимо заменять `\` на `\\` примеры:

- `"C:\\Users\\BestUser\\Desktop\\SSF\\secrets"`
- `".\\secrets"`
- `"secrets"`
- `"accounts.txt"`
- `"./accounts.txt"`

### Названия предметов для фильтров

Название предметов необходимо указывать на английском языке.
Если предмет был переименован, нужно указывать его основное название.

### Теги

Название тегов необходимо указывать на английском языке.
Найти теги можно нажав на предмет в инвентаре, они будут в самом низу.

## Примеры

![Скриншот работы софта](Assets/Screenshot.png)
