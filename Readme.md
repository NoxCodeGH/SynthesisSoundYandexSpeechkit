=== ����� ===
������ ������ ��� �������������� � �������� Yandex SpeechKit TTS.

=== SynthesisSoundYandexSpeechkit ===
���������� ��������� �������������� � ��������.

=== SynthesisSoundYandexSpeechkitConsole ===
���������� ���������� ���������.

=== ������� ����� ===
1. ������� ����� ����������;
2. � ����� "Config.json" ������� "IamToken" � "FolderId";
3. � ����� "ConfigSynthesis.json" ������� ��������� �������, ����������� (���� ����������) � �������� ������ �������.
4. � ����� "Texts.txt" ������� ����� ������� (������ ������ ��� ��������� ��������);
5. ���������.

=== �������������� � Yandex Cloud ===
1. ������������/������������������ �� https://cloud.yandex.ru/;
2. �������� ������������� �������� https://cloud.yandex.ru/docs/resource-manager/operations/folder/get-id;
3. �������� OAuth-����� https://cloud.yandex.ru/docs/iam/concepts/authorization/oauth-token;
4. �������� IAM-����� https://cloud.yandex.ru/docs/iam/operations/iam-token/create;
	- ��������� IAM-������ �� ��������� ������:
		curl -d "{\"yandexPassportOauthToken\":\"<OAuth-�����>\"}" "https://iam.api.cloud.yandex.net/iam/v1/tokens"