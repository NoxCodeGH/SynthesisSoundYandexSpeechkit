#### Описание <br/>
- Проект создан для взаимодействия с сервисом Yandex SpeechKit TTS.

#### SynthesisSoundYandexSpeechkit <br/>
- Библиотека основного взаимодействия с сервисом.

#### SynthesisSoundYandexSpeechkitConsole <br/>
- Консольное управление запросами.

#### Быстрый старт <br/>
1. Скачать архив приложения;
2. В файле _"Config.json"_ указать _"IamToken"_ и _"FolderId"_;
3. В файле _"ConfigSynthesis.json"_ указать параметры синтеза, конвертации (если необходимо) и хранения файлов синтеза.
4. В файле _"Texts.txt"_ указать текст синтеза (каждая строка идёт отдельным запросом);
5. Запустить.

#### Взаимодействие с Yandex Cloud <br/>
1. Подключиться/зарегистрироваться: https://cloud.yandex.ru/;
2. Получить идентификатор каталога: https://cloud.yandex.ru/docs/resource-manager/operations/folder/get-id;
3. Получить OAuth-токен: https://cloud.yandex.ru/docs/iam/concepts/authorization/oauth-token;
4. Получить IAM-токен: https://cloud.yandex.ru/docs/iam/operations/iam-token/create;
	- получение IAM-токена из командной строки:<br/>
		_curl -d "{\"yandexPassportOauthToken\":\"<OAuth-токен>\"}" "https://iam.api.cloud.yandex.net/iam/v1/tokens"_
