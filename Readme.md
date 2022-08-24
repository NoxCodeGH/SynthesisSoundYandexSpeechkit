=== Общее ===
Проект создан для взаимодействия с сервисом Yandex SpeechKit TTS.

=== SynthesisSoundYandexSpeechkit ===
Библиотека основного взаимодействия с сервисом.

=== SynthesisSoundYandexSpeechkitConsole ===
Консольное управление запросами.

=== Быстрый старт ===
1. Скачать архив приложения;
2. В файле "Config.json" указать "IamToken" и "FolderId";
3. В файле "ConfigSynthesis.json" указать параметры синтеза, конвертации (если необходимо) и хранения файлов синтеза.
4. В файле "Texts.txt" указать текст синтеза (каждая строка идёт отдельным запросом);
5. Запустить.

=== Взаимодействие с Yandex Cloud ===
1. Подключиться/зарегистрироваться на https://cloud.yandex.ru/;
2. Получить идентификатор каталога https://cloud.yandex.ru/docs/resource-manager/operations/folder/get-id;
3. Получить OAuth-токен https://cloud.yandex.ru/docs/iam/concepts/authorization/oauth-token;
4. Получить IAM-токен https://cloud.yandex.ru/docs/iam/operations/iam-token/create;
	- получение IAM-токена из командной строки:
		curl -d "{\"yandexPassportOauthToken\":\"<OAuth-токен>\"}" "https://iam.api.cloud.yandex.net/iam/v1/tokens"